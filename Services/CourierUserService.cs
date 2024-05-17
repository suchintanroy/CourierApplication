using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courier_Application.Models;
using Courier_Application.Repositories;

namespace Courier_Application.Services
{
    internal class CourierUserService : ICourierUserService
    {
        readonly ICourierUserRepository courierUserRepo;

        public CourierUserService()
        {
            courierUserRepo = new CourierUserRepository();
        }

        public void PlaceOrder()
        {
            Console.WriteLine("Enter the CourierID: ");
            int courierId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the sender name: ");
            string senderName = Console.ReadLine();
            Console.WriteLine("Enter the  sender address: ");
            string senderAddress = Console.ReadLine();
            Console.WriteLine("Enter the receiver name: ");
            string receiverName = Console.ReadLine();
            Console.WriteLine("Enter the receiver address: ");
            string receiverAddress = Console.ReadLine();
            Console.WriteLine("Enter the weight: ");
            decimal weight = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the status: ");
            string status = Console.ReadLine();
            Console.WriteLine("Enter the delivery date: ");
            DateTime deliveryDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the user id: ");
            long userId = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the employee id: ");
            long employeeId = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the service id: ");
            long serviceId = long.Parse(Console.ReadLine());

            Courier newOrder = new Courier(courierId, senderName, senderAddress, receiverName, receiverAddress, weight, status, deliveryDate, userId, employeeId, serviceId);

            string trackingNumber = courierUserRepo.PlaceOrder(newOrder);

            if (trackingNumber.Length> 0)
            {
                Console.WriteLine($"Placed the order Successfully, Your tracking number is{trackingNumber}");
            }
            else
            {
                Console.WriteLine("Failed to place the order");
            }
        }
        public void GetOrderStatus()
        {
            Console.WriteLine("Enter the tracking number:");
            int trackingNumber = int.Parse(Console.ReadLine());
            string orderStatus = courierUserRepo.GetOrderStatus(trackingNumber);
            Console.WriteLine($"Your order status:{orderStatus}");
        }
        public void CancelOrder()
        {
            Console.WriteLine("Enter the tracking number:");
            int trackingNumber = int.Parse(Console.ReadLine());
            bool status = courierUserRepo.CancelOrder(trackingNumber);
            Console.WriteLine($"Your order status:{status}");
        }
        public void GetAssignedOrder()
        {
            Console.WriteLine("Enter the staff id:");
            long? staffId = long.Parse(Console.ReadLine());
            List<Courier> couriers = courierUserRepo.GetAssignedOrder(staffId);

            if (couriers.Count > 0)
            {
                foreach (Courier c in couriers)
                {
                    Console.WriteLine(c.CourierID + " " + c.EmployeeId + " " + c.DeliveryDate);
                }
            }
            else
            {
                Console.WriteLine("There is no order assigned to this staff");
            }
        }
    }
}
