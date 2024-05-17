using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Application.Models
{
    public class Location
    {
        public long LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }

        public Location(long locationID, string locationName, string address)
        {
            LocationID = locationID;
            LocationName = locationName;
            Address = address;
        }
    }
}