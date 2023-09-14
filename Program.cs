using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerUnit { get; set; }
    public decimal Discount { get; set; }

    public Product(string name, int quantity, decimal pricePerUnit, decimal discount = 0)
    {
        Name = name;
        Quantity = quantity;
        PricePerUnit = pricePerUnit;
        Discount = discount;
    }
}

class Receipt
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += (product.PricePerUnit * product.Quantity) * (1 - product.Discount / 100);
        }
        return total;
    }

    public void PrintReceipt()
    {
        Console.WriteLine("********** Кассовый чек **********");
        Console.WriteLine("Наименование\tКоличество\tЦена за единицу\tСкидка (%)");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name}\t{product.Quantity}\t{product.PricePerUnit}\t{product.Discount}");
        }
        Console.WriteLine($"\nИтого: {CalculateTotal():F2} грн");
        Console.WriteLine("**********************************");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Receipt receipt = new Receipt();

        
        Product product1 = new Product("Шоколад", 2, 50.0m, 10);
        Product product2 = new Product("Молоко", 3, 60.0m);
        Product product3 = new Product("Кофе", 1, 120.0m, 5);

        receipt.AddProduct(product1);
        receipt.AddProduct(product2);
        receipt.AddProduct(product3);

        
        receipt.PrintReceipt();
    }
}
