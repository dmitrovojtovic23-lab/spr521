using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess1
{
    public class SportShopDb : IDisposable
    {
        private SqlConnection sqlConnection;

        public SportShopDb(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }
        //C       R    U       D 
        //Create Read Update Delede
        public void Create_As_Insert(Product product)
        {
            string cmdText = $@"INSERT INTO Products
                              VALUES ('{product.Name}', 
                                      '{product.Type}',
                                       {product.Quantity}, 
                                       {product.Cost}, 
                                      '{product.Producer}', 
                                       {product.Price})";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            command.CommandTimeout = 5; // default - 30sec

            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
        }
        public List<Product> Read_Get_All()
        {
            string cmdText = $@"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(
                    new Product()
                    {
                        Id = (int)reader[0],
                        Name = (string)reader[1],
                        Type = (string)reader[2],
                        Quantity = (int)reader[3],
                        Cost = (int)reader[4],
                        Producer = (string)reader[5],
                        Price = (int)reader[6]
                    });


            }

            reader.Close();
            return products;
        }
        public List<Salles> Read_Get_AllSalles()
        {
            string cmdText = $@"select * from Salles";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            List<Salles> salles = new List<Salles>();

            while (reader.Read())
            {
                salles.Add(
                    new Salles()
                    {
                        Id = (int)reader[0],
                        Quantity = (int)reader[3],
                        Price = (int)reader[6]
                    });


            }

            reader.Close();
            return salles;
        }
        public void PrintSalles()
        {
            string cmdText = $@"select * from Salles";

        }
        public Product GetOne(int id)
        {
            string cmdText = "SELECT * FROM Products WHERE Id = @Id";
            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            Product product = new Product();
            while (reader.Read())
            {
                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.Cost = (int)reader[4];
                product.Producer = (string)reader[5];
                product.Price = (int)reader[6];

            }

            reader.Close();
            return product;
        }
        public void Update(Product product)
        {
            string cmdText = $@"UPDATE Products
                              SET Name ='{product.Name}', 
                                  TypeProduct ='{product.Type}', 
                                  Quantity ={product.Quantity}, 
                                  CostPrice ={product.Cost}, 
                                  Producer ='{product.Producer}', 
                                  Price ={product.Price}
                                  where Id = {product.Id}";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            command.CommandTimeout = 5; // default - 30sec

            command.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            string cmdText = $@"delete Products where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            command.ExecuteNonQuery();
        }
        public void DeleteSalles(int id)
        {
            string cmdText = $@"delete Salles where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
        public void ShowTopSeller()
        {
            string cmdText = @"
                SELECT TOP 1 e.Name, e.Surname, SUM(s.Price * s.Quantity) AS TotalSales
                FROM Salles s
                JOIN Employees e ON s.EmployeeId = e.Id
                GROUP BY e.Name, e.Surname
                ORDER BY TotalSales DESC";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Найкращий продавець: {reader["Name"]} {reader["Surname"]}, " +
                                  $"Сума продаж: {reader["TotalSales"]}");
            }
            else
            {
                Console.WriteLine("Продажів ще немає.");
            }
            reader.Close();
        }

    }
}
