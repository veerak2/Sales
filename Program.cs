using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Sales
{
    class Product
    {
        public int Id { get; set; }
        public string name { get; set; }

        public int price { get; set;  }

        public List<Order> ProductOrders { get; set; }
    }

    class Store
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string location { get; set; }

        public List<Order> StoreOrders { get; set; }
    }

    class Order
    {
        public int Id { get; set; }
        public Product OrderedProduct { get; set; }
        public Store OrderedFrom { get; set; }
        public int quantity { get; set; }
    }

    class StoreSalesContext :  DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Order> Orders { get; set; }

        string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=Sales;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (StoreSalesContext context = new StoreSalesContext())
            {
                context.Database.EnsureCreated();

                Product product1 = new Product { name = "Milk" , price = 4 };
                Product product2 = new Product { name = "Chicken", price = 5 };
                Product product3 = new Product { name = "Bread", price = 3 };
                Product product4 = new Product { name = "Butter", price = 4 };

                Store store1 = new Store { name = "Publix" };
                Store store2 = new Store { name = "Walmart" };
                Order order1 = new Order
                {
                    OrderedProduct = product1,
                    OrderedFrom = store1,
                    quantity = 1

                };
                Order order2 = new Order
                {
                    OrderedProduct = product2,
                    OrderedFrom = store1,
                    quantity = 2

                };
                Order order3 = new Order
                {
                    OrderedProduct = product1,
                    OrderedFrom = store1,
                    quantity = 2

                };

                Order order4 = new Order
                {
                    OrderedProduct = product1,
                    OrderedFrom = store2,
                    quantity = 2

                };

                Order order5 = new Order
                {
                    OrderedProduct = product2,
                    OrderedFrom = store2,
                    quantity = 1

                };

                context.products.Add(product1);
                context.products.Add(product2);
                context.products.Add(product3);
                context.products.Add(product4);
                context.Stores.Add(store1);
                context.Stores.Add(store2);
                context.Orders.Add(order1);
                context.Orders.Add(order2);
                context.Orders.Add(order3);
                context.Orders.Add(order4);
                context.Orders.Add(order5);

                context.SaveChanges();

                DbContext.Orders.
            }

        }
    }
}
