// Exceed requirements: Allow users to input customer and product information dynamically

using System;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        Console.Write("How many orders do you want to process? ");
        int orderCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < orderCount; i++)
        {
            Console.WriteLine($"\n--- Order {i + 1} ---");

            // Customer info
            Console.WriteLine("Enter your billing address .....");
            Console.Write("Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Street Address: ");
            string street = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State/Province: ");
            string state = Console.ReadLine();

            Console.Write("Country: ");
            string country = Console.ReadLine();

            Address address = new Address(street, city, state, country);
            Customer customer = new Customer(name, address);

            Order order = new Order(customer);

            // Products
            Console.Write("How many products in this order? ");
            int productCount = int.Parse(Console.ReadLine());

            for (int j = 0; j < productCount; j++)
            {
                Console.WriteLine($"\nProduct {j + 1}");

                Console.Write("Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Product ID: ");
                string productId = Console.ReadLine();

                Console.Write("Price (Only the price): ");
                double price = double.Parse(Console.ReadLine());

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productId, price, quantity);
                order.AddProduct(product);
            }

            orders.Add(order);
        }

        // Display Orders
        Console.WriteLine("\n========== ORDER SUMMARY ==========\n");

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():C}");
            Console.WriteLine();
        }
    }
}
