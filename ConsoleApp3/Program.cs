using ConsoleApp2;
using System.Data.SqlClient;
using System.Text;

class SportShopDb : IDisposable
{
    private SqlConnection sqlConnection;

    public SportShopDb(string connectionString)
    {
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
    }
    public void Create_As_Insert(Product product)
    {
        string cmdText = @"INSERT INTO Products (Name, TypeProduct, Quantity, CostPrice, Producer, Price)
                           VALUES (@Name, @Type, @Quantity, @Cost, @Producer, @Price)";

        using (SqlCommand command = new SqlCommand(cmdText, sqlConnection))
        {
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Type", product.Type);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@Cost", product.Cost);
            command.Parameters.AddWithValue("@Producer", product.Producer);
            command.Parameters.AddWithValue("@Price", product.Price);

            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
        }
    }
    public List<Product> Read_Get_All()
    {
        string cmdText = @"SELECT * FROM Products";

        SqlCommand command = new SqlCommand(cmdText, sqlConnection);
        SqlDataReader reader = command.ExecuteReader();
        Console.OutputEncoding = Encoding.UTF8;

        List<Product> products = new List<Product>();

        while (reader.Read())
        {
            products.Add(new Product()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Type = (string)reader["TypeProduct"],
                Quantity = (int)reader["Quantity"],
                Cost = Convert.ToSingle(reader["CostPrice"]),
                Producer = (string)reader["Producer"],
                Price = Convert.ToSingle(reader["Price"])
            });
        }

        reader.Close();
        return products;
    }
    public List<Salles> Read_Get_AllSalles()
    {
        string cmdText = @"SELECT * FROM Salles";

        SqlCommand command = new SqlCommand(cmdText, sqlConnection);
        SqlDataReader reader = command.ExecuteReader();
        Console.OutputEncoding = Encoding.UTF8;

        List<Salles> salles = new List<Salles>();

        while (reader.Read())
        {
            salles.Add(new Salles()
            {
                Id = (int)reader["Id"],
                Quantity = (int)reader["Quantity"],
                Price = Convert.ToSingle(reader["Price"])
            });
        }

        reader.Close();
        return salles;
    }
    public Product GetOne(int id)
    {
        string cmdText = "SELECT * FROM Products WHERE Id = @Id";
        SqlCommand command = new SqlCommand(cmdText, sqlConnection);
        command.Parameters.AddWithValue("@Id", id);

        SqlDataReader reader = command.ExecuteReader();
        Console.OutputEncoding = Encoding.UTF8;

        Product product = null;
        if (reader.Read())
        {
            product = new Product()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Type = (string)reader["TypeProduct"],
                Quantity = (int)reader["Quantity"],
                Cost = Convert.ToSingle(reader["CostPrice"]),
                Producer = (string)reader["Producer"],
                Price = Convert.ToSingle(reader["Price"])
            };
        }

        reader.Close();
        return product;
    }
    public void Update(Product product)
    {
        string cmdText = @"UPDATE Products
                           SET Name = @Name, 
                               TypeProduct = @Type, 
                               Quantity = @Quantity, 
                               CostPrice = @Cost, 
                               Producer = @Producer, 
                               Price = @Price
                           WHERE Id = @Id";

        using (SqlCommand command = new SqlCommand(cmdText, sqlConnection))
        {
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Type", product.Type);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@Cost", product.Cost);
            command.Parameters.AddWithValue("@Producer", product.Producer);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Id", product.Id);

            command.ExecuteNonQuery();
        }
    }
    public void Delete(int id)
    {
        string cmdText = @"DELETE FROM Products WHERE Id = @Id";

        using (SqlCommand command = new SqlCommand(cmdText, sqlConnection))
        {
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
    public void DeleteSalles(int id)
    {
        string cmdText = @"DELETE FROM Salles WHERE Id = @Id";

        using (SqlCommand command = new SqlCommand(cmdText, sqlConnection))
        {
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
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

    public void Dispose()
    {
        sqlConnection.Close();
        sqlConnection.Dispose();

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = (localDB)\MSSQLLocalDb; 
                                        Initial Catalog = SportShop;
                                        Integrated Security = true; 
                                        TrustServerCertificate=True;";
            Product product = new Product()
            {
                Name = "Кросівки",
                Type = "Взуття",
                Quantity = 5,
                Cost = 2500,
                Producer = "Nike",
                Price = 4000
            };

            using (SportShopDb shopDb = new SportShopDb(connectionString))
            {
                Console.OutputEncoding = Encoding.UTF8;

                Console.WriteLine("=== INSERT ===");
                shopDb.Create_As_Insert(product);

                Console.WriteLine("\n=== ALL PRODUCTS ===");
                var products = shopDb.Read_Get_All();
                foreach (var p in products)
                {
                    Console.WriteLine(p);
                }

                Console.WriteLine("\n=== GET ONE PRODUCT (Id = 1) ===");
                var one = shopDb.GetOne(1);
                if (one != null)
                    Console.WriteLine($"Знайдено: {one.Name}, Ціна: {one.Price}");

                Console.WriteLine("\n=== UPDATE PRODUCT (Id = 1) ===");
                if (one != null)
                {
                    one.Price -= 500;
                    shopDb.Update(one);
                }

                Console.WriteLine("\n=== PRODUCTS AFTER UPDATE ===");
                products = shopDb.Read_Get_All();
                foreach (var p in products)
                {
                    Console.WriteLine(p);
                }

                Console.WriteLine("\n=== DELETE PRODUCT (Id = 1) ===");
                shopDb.Delete(1);

                Console.WriteLine("\n=== PRODUCTS AFTER DELETE ===");
                products = shopDb.Read_Get_All();
                foreach (var p in products)
                {
                    Console.WriteLine(p);
                }

                Console.WriteLine("\n=== TOP SELLER ===");
                shopDb.ShowTopSeller();

            }

            Console.WriteLine("\nГотово!");
        }
    }
}