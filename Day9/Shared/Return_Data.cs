using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Day9.L12_L13;

namespace Day9.Shared
{
    class Return_Data
    {
        private String ReaderSp { get; set; }
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
        public Return_Data(string sp)
        {
            ReaderSp = sp;
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
        public List<Product> ReadAllProducts()
        {
            SqlConnection pconn = new SqlConnection("Data Source=DESKTOP-N6LPCB1\\SQLEXP2014;Initial Catalog=Day9;Integrated Security=True");
            pconn.Open();

            SqlCommand pcmd = pconn.CreateCommand();
            pcmd.CommandType = CommandType.StoredProcedure;
            pcmd.CommandText = ReaderSp;

            SqlDataReader drd = pcmd.ExecuteReader();
            List<Product> Pl = new List<Product>();

            // loop
            while(drd.Read())
            {
                // Console.WriteLine("\n57 -- pid is: {0}.", drd[0]);
                // Pl.Add(new Product { pid = int.Parse(drd[0]), pname = drd[1], pqty = drd[2], pdate = drd[3], oid = drd[4] });
                Pl.Add(new Product {
                    pid = drd.GetInt32(0),
                    pname = drd.GetString(1),
                    pqty = drd.GetInt16(2),
                    pdate = drd.GetDateTime(3),
                    oid = drd.GetInt32(4)
                });

            }

            pconn.Close();

            return Pl;
        }
    }
}
