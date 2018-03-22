using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Users_and_Leads
{
    class Business
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int BusinessTypeId { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }



        public override string ToString()
        {
            return "('" + Name + "','" + PhoneNumber + "'," + BusinessTypeId + ",'" + Street + "','" + State + "','" + ZipCode + "'),";
        }
    }
}
