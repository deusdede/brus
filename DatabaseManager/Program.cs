using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = @"Data Source=DESKTOP-DFVSDBV\SQLEXPRESS;Initial Catalog=agendamento;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                Console.WriteLine("\nTabela Usuário:");
                Console.WriteLine("=========================================\n");

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP 20 u.nome ");
                sb.Append("FROM [dbo].[Usuario] u ");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader.GetString(0));
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
