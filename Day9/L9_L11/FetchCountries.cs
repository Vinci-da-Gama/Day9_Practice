using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Day9.Shared;

namespace Day9.L9_L11
{
    class FetchCountries
    {
        private string SpCmd { get; set; }
        public FetchCountries(string c)
        {
            SpCmd = c;
        }
        public string[] SetCountriesArr()
        {
            string[] Countries = {};

            // Server Name: DESKTOP-N6LPCB1\SQLEXP2014
            SqlConnection Cconn = new SqlConnection("Data Source=DESKTOP-N6LPCB1\\SQLEXP2014;Initial Catalog=Day9;Integrated Security=True");
            Cconn.Open();

            SqlCommand CountriesCmd = Cconn.CreateCommand();
            CountriesCmd.CommandType = CommandType.StoredProcedure;
            CountriesCmd.CommandText = SpCmd;

            SqlDataAdapter AllCountriesAdapter = new SqlDataAdapter(CountriesCmd);
            DataSet AllCountriesDs = new DataSet();
            AllCountriesAdapter.Fill(AllCountriesDs);

            Return_Data GrabData = new Return_Data(AllCountriesDs);
            Countries = GrabData.ReadAllCountries();

            Console.WriteLine("How many Countries: {0}.", Countries.Length);

            return Countries;
        }
    }
}
