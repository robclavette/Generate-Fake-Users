using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Users_and_Leads
{
    class User
    {
        public int User_Id { get; set; }
        public int User_NumLeadsAdded { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public string User_Email { get; set; }
        public int User_IsPremium { get; set; }


        public override string ToString()
        {
            return "('" + User_FirstName + "','" + User_LastName + "','" + User_Email + "'," + User_IsPremium + "," + User_NumLeadsAdded + "),";
        }

    }
}
