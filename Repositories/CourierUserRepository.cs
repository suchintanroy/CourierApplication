using System;
using Courier_Application.Utility;
using Courier_Application.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Courier_Application.Repositories
{
    public class CourierUserRepository : ICourierUserRepository
    {
        SqlConnection sqlConnection = null;       
        SqlCommand cmd = null;


        public CourierUserRepository()
        {
            sqlConnection = new SqlConnection(ConnectionUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public string PlaceOrder(Courier courier)
        {
            sqlConnection.Open();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "Insert into Courier OUTPUT INSERTED.TrackingNumber values(@CourierId , @SenderName,@SenderAddress,@ReceiverName,@ReceiverAddress,@Weight,@Status,@TrackingNumber,@DeliveryDate,@userId,@employeeId,@serviceId)";
            cmd.Parameters.AddWithValue("@CourierId", courier.CourierID);
            cmd.Parameters.AddWithValue("@SenderName", courier.SenderName);
            cmd.Parameters.AddWithValue("@SenderAddress", courier.SenderAddress);
            cmd.Parameters.AddWithValue("@ReceiverName", courier.ReceiverName);
            cmd.Parameters.AddWithValue("@ReceiverAddress", courier.ReceiverAddress);
            cmd.Parameters.AddWithValue("@Weight", courier.Weight);
            cmd.Parameters.AddWithValue("@Status", courier.Status);
            cmd.Parameters.AddWithValue("@TrackingNumber", Convert.ToString(courier.TrackingNumber));
            cmd.Parameters.AddWithValue("@DeliveryDate", courier.DeliveryDate);
            cmd.Parameters.AddWithValue("@employeeId", courier.EmployeeId);
            cmd.Parameters.AddWithValue("@userId", courier.UserId);
            cmd.Parameters.AddWithValue("@serviceId", courier.ServiceId);
            string TrackingNumber = Convert.ToString(cmd.ExecuteScalar());
            sqlConnection.Close();
            return TrackingNumber;

        }

        public string GetOrderStatus(int trackingNumber)
        {
            string status = "";


            sqlConnection.Open();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "SELECT Status FROM Courier WHERE TrackingNumber = @TrackingNumber";
            cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                status = reader["Status"].ToString();
            }

            reader.Close();
            sqlConnection.Close();
            return status;
        }

        public bool CancelOrder(int trackingNumber)
        {
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandText = "delete from courier where trackingNumber=@trackingNumber";
            cmd.Parameters.AddWithValue("@trackingNumber", trackingNumber);
            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return status > 0 ? true : false;
        }

        public List<Courier> GetAssignedOrder(long? StaffID)
        {

            sqlConnection.Open();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "SELECT * FROM Courier WHERE employeeId  = @staffID";
            cmd.Parameters.AddWithValue("@staffID", StaffID);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Courier> couriers = new List<Courier>();


            while (reader.Read())
            {
                Courier courier = new Courier();
                courier.CourierID = (int)reader["CourierId"];
                courier.EmployeeId = (int)reader["EmployeeId"];
                courier.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]);
                couriers.Add(courier);
            }

            reader.Close();
            sqlConnection.Close();
            return couriers;
        }

    }
}
