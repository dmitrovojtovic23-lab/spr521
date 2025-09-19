using DataAccess1;

namespace DataAccessSportShopDb
{
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
                Name = "Кроси",
                Type = "Взуття",
                Quantity = 4,
                Cost = 40000,
                Producer = "Італія",
                Price = 30000
            };
            // product.Cost = 5000;
            using (SportShopDb shopDb = new SportShopDb(connectionString))
            {
                //shopDb.Create_As_Insert(product);

                var products = shopDb.Read_Get_All();
                foreach (var p in products)
                {
                    Console.WriteLine(p.ToString());
                }

                Product p1 = shopDb.GetOne(56);
                Console.WriteLine(p1.Name + "   " + p1.Cost);
                p1.Cost -= 15000;
                Console.WriteLine(p1.Name + "   " + p1.Cost);

                shopDb.Update(p1);

                products = shopDb.Read_Get_All();
                foreach (var p in products)
                {
                    Console.WriteLine(p.ToString());
                }




            }//shopDb.Dispose()





        }
    }
}
