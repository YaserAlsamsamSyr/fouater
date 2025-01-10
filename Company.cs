using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fouater
{
    internal class Company
    {
        static public int id { get; set; }
        static public string companyName { get; set; }

        static public string branchName { get; set; }
        static public double box { get; set; }
        static public double visa { get; set; }
        static public double cash { get; set; }
        static public string date { get; set; }

        static public string typeMonye { get; set; }
        static public string unitMonye { get; set; }
        static public string vat { get; set; }
        public static string databasePath { get; set; }

    }
}
