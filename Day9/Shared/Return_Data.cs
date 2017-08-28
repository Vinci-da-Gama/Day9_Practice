using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Day9.Shared
{
    class Return_Data
    {
        private SqlDataReader DataReader { get; set; }
        private DataSet Ds { get; set; }
        public Return_Data(SqlDataReader sdr)
        {
            DataReader = sdr;
        }
        public Return_Data(DataSet ds)
        {
            Ds = ds;
        }

        public string[] ReadAllCountries()
        {
            List<string> Strs = new List<string>();
            foreach (DataRow cRow in Ds.Tables[0].Rows)
            {
                Console.WriteLine(String.Format("28 -- Country is: {0}.", cRow["Countries"]));
                Strs.Add(cRow["Countries"].ToString());
            }
            return Strs.ToArray();
        }
    }
}
