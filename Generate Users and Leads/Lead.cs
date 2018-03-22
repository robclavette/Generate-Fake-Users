using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Users_and_Leads
{
    class Lead
    {
        //public int Lead_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeNumber { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public int BusinessId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int ReferrerId { get; set; }

        public override string ToString()
        {
            return "('" + FirstName + "','" + LastName + "','" + HomeNumber + "','" + MobilePhone + "','" + WorkPhone + "','" + Email + "'," + BusinessId + ",'" + City + "','" + State + "','" + ZipCode + "'," + ReferrerId + "),";
        }
    }
}
