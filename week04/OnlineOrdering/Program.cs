using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Test St", "Crystal River", "FL", "USA");
        Customer customer1 = new Customer("Princess Dog", address1);
        Order order1 = new rder(customer1);

        order1.NewProduct(new Product("Dog Treat", "A100", 15.99, 2));
        order1.NewProduct(new Product("Chew Toy", "A101", 9.99, 1));

        Address address2 = new Address("15 Jump St", "Crystal River", "FL", "USA");
        Customer customer2 = new Customer("Neighbor Dog", address2);
        Order order2 = new Order(customer2);

        order2.NewProduct(new Product("Flea Medicine", "A102", 50.99, 1));
        order2.NewProduct(new Product("Large Cone", "A103", 7.99, 1));

        List<Order> orders = new List<Order>() { order1, order2 };

        foreach (Order o in orders)
        {
            Console.WriteLine("PACKING LABEL:");
            Console.WriteLine(o.GetPacking());

            Console.WriteLine("SHIPPING LABEL:");
            Console.WriteLine(o.GetShipping());

            Console.WriteLine($"TOTAL PRICE: ${o.GetTotalPrice():0.00}");
            Console.WriteLine();
        }
    }
}