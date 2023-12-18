using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAss8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("server=DESKTOP-G2EN09F; database=Exercise8Db; trusted_connection=true;"))
                {
                    connection.Open();

                    string query = "SELECT TOP 5 * FROM Products  ORDER BY ProductName DESC";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Top 5 Records in Descending Order of PName:");
                            Console.WriteLine("ProductId\tProductName\tProductPrice\tExpDate\tMnfDate");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["ProductId"]}\t{reader["ProductName"]}\t{reader["ProductPrice"]}\t{reader["ExpDate"]}\t{reader["MnfDate"]}");
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error!!!!" + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}