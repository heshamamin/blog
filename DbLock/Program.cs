using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace DbLock
{
    class Program
	{
		static void Main(string[] args)
		{
            using (DbConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2014;Integrated Security=True;Application Name=""My DbLock App"""))
            {
                var command = connection.CreateCommand();
                command.CommandText = @"
                        Begin transaction
                        update Person.EmailAddress
                        set EmailAddress = '-'+EmailAddress";
                command.CommandType = System.Data.CommandType.Text;

                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                    Console.ReadLine();
                }
            }
               
        }
	}
}
