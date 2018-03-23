using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Users_and_Leads
{
    class Program
    {

        public static string statetxtfilepath = string.Empty;
        public static string leadstxtfilepathoutput = string.Empty;
        public static string userstxtfilepathoutput = string.Empty;
        public static string nounstxtpath = string.Empty;
        public static string businessoutputpath = string.Empty;
        public static string firstnamestxtpath = string.Empty;
        public static string lastnamestxtpath = string.Empty;
        public static string phonetxtpath = string.Empty;


        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to generate insert statements.");
            Console.ReadKey();

            string[] firstNames = GetFirstNames();
            string[] lastNames = GetLastNames();
            string[] phoneNumbers = GetPhoneNumbers();

            GenerateLeads(firstNames, lastNames, phoneNumbers);
            //GenerateUsers(firstNames, lastNames, phoneNumbers);
           // GetBusinessNames(firstNames,lastNames,phoneNumbers);
        }



        private static void GenerateLeads(string[] firstnames, string[] lastnames,string[] phonenumbers)
        {
            Random ranNamesAndPhone = new Random();

            List<Lead> leads = new List<Lead>();
            string rawstates = string.Empty;

            using (StreamReader sr = new StreamReader(statetxtfilepath))
            {
                rawstates = sr.ReadToEnd();
            }
            string[] parsedstates = rawstates.Split(',');

            


            for (int i = 0; i < 4000; i++)
            {

                int firstNameRanNum = ranNamesAndPhone.Next(0, 999);
                int lastNameRanNum = ranNamesAndPhone.Next(0, 999);
                char firstNameFirstLetter = firstnames[firstNameRanNum].ToArray().First();

                StringBuilder sb = new StringBuilder();
                sb.Append(firstNameFirstLetter + lastnames[lastNameRanNum] + "@gmail.com");


                leads.Add(new Lead
                {
                    FirstName = firstnames[firstNameRanNum],
                    LastName = lastnames[lastNameRanNum],
                    HomeNumber = phonenumbers[ranNamesAndPhone.Next(0, 999)],
                    MobilePhone = phonenumbers[ranNamesAndPhone.Next(0, 999)],
                    WorkPhone = phonenumbers[ranNamesAndPhone.Next(0, 999)],
                    Email = sb.ToString(),
                    BusinessId = ranNamesAndPhone.Next(1,149),
                    City = " ",
                    State = parsedstates[ranNamesAndPhone.Next(0,49)],
                    ZipCode = ranNamesAndPhone.Next(10000,99999).ToString(),
                    ReferrerId = ranNamesAndPhone.Next(1,400),

                });
            }
            using (StreamWriter sw = new StreamWriter(leadstxtfilepathoutput))
            {
                foreach (var item in leads)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }

        private static void GenerateUsers(string[] firstnames, string[] lastnames, string[] phonenumbers)
        {
            Random ranNamesAndPhone = new Random();
            Random isPremium = new Random();

            List<User> users = new List<User>();

            for (int i = 0; i < 200; i++)
            {
                int firstNameRanNum = ranNamesAndPhone.Next(0, 999);
                int lastNameRanNum = ranNamesAndPhone.Next(0, 999);
                char firstNameFirstLetter = firstnames[firstNameRanNum].ToArray().First();

                StringBuilder sb = new StringBuilder();
                sb.Append(firstNameFirstLetter + lastnames[lastNameRanNum] + "@gmail.com");

                users.Add(new User
                {
                    User_NumLeadsAdded = 0,
                    User_FirstName = firstnames[firstNameRanNum],
                    User_LastName = lastnames[lastNameRanNum],
                    User_Email = sb.ToString().ToLower(),
                    User_IsPremium = 1,
                });
            }

            using(StreamWriter sw = new StreamWriter(userstxtfilepathoutput))
            {
                foreach(var item in users)
                {
                    sw.WriteLine(item.ToString());
                }
            }


        }

        

        private static void GetBusinessNames(string[] firstnames, string[] lastnames, string[] phonenums)
        {
            Random randomNounPicker = new Random();
            Random randomSuffixPicker = new Random();
            string generatedBusinessName = string.Empty;

            string rawnames = string.Empty;
            string rawstates = string.Empty;

            if (!File.Exists(nounstxtpath))
            {
                File.Create(nounstxtpath);
            }

            using (StreamReader sr = new StreamReader(nounstxtpath))
            {
                rawnames = sr.ReadToEnd();
            }
            using(StreamReader sr = new StreamReader(statetxtfilepath))
            {
                rawstates = sr.ReadToEnd();
            }

            string[] parsedstates = rawstates.Split(',');

            string[] suffixes = { "Enterprises", "Incorporated", "LLC", "Development", "GmbH", "Limited" };

            string[] parsedname = rawnames.Split(',');

            string[] businessNames = new string[150];

            for (int i = 0; i < 149; i++)
            {
                generatedBusinessName = parsedname[randomNounPicker.Next(0, 4554)] + " " + suffixes[randomSuffixPicker.Next(0, 5)];
                generatedBusinessName = generatedBusinessName.First().ToString().ToUpper() + generatedBusinessName.Substring(1);
                businessNames[i] = generatedBusinessName;
            }

            List<Business> businesses = new List<Business>();

            foreach(var item in businessNames)
            {
                businesses.Add(new Business
                {
                    Name = item,
                    PhoneNumber = phonenums[randomNounPicker.Next(0, 999)],
                    BusinessTypeId = randomNounPicker.Next(1, 8),
                    Street = randomNounPicker.Next(1000, 9999).ToString() + " Fake Street",
                    State = parsedstates[randomNounPicker.Next(0,49)],
                    ZipCode = randomNounPicker.Next(10000,99999).ToString(),
                });
            }


            

            using (StreamWriter sw = new StreamWriter(businessoutputpath))
            {
                foreach (var item in businesses)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }

        private static string[] GetFirstNames()
        {
            string rawnames = string.Empty;
            using(StreamReader sr =  new StreamReader(firstnamestxtpath))
            {
                rawnames = sr.ReadToEnd();
            }
            string[] parsedname = rawnames.Split(',');
            return parsedname;
        }

        private static string[] GetLastNames()
        {
            string rawnames = string.Empty;
            using (StreamReader sr = new StreamReader(lastnamestxtpath))
            {
                rawnames = sr.ReadToEnd();
            }
            string[] parsedname = rawnames.Split(',');
            return parsedname;
        }

        private static string[] GetPhoneNumbers()
        {
            string rawnumbers = string.Empty;
            using (StreamReader sr = new StreamReader(phonetxtpath))
            {
                rawnumbers = sr.ReadToEnd();
            }
            string[] parsednumbers = rawnumbers.Split(',');
            return parsednumbers;
        }


        public static void GeneratePhoneNumbers()
        {
            Random rangen = new Random();

            string numbers = string.Empty;

            for(int i = 0;i < 1000; i++)
            {
                numbers = numbers + rangen.Next(1000000000,2000000000) + ',';
            }

            using(StreamWriter sw = new StreamWriter(phonetxtpath))
            {
                sw.Write(numbers);
            }
        }
    }
}
