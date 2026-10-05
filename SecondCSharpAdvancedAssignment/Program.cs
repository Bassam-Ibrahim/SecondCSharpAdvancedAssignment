using SecondCSharpAdvancedAssignment;

class Program
{
    public static List<Product> SearchProducts(
        List<Product> products,
        Func<Product, bool> x)
    {
        List<Product> filteredProducts = new();

        foreach (var product in products)
        {
            if (x(product))
            {
                filteredProducts.Add(product);
            }
        }

        return filteredProducts;
    }
    public static void PrintRepo(List<Product> products, Action<Product> y)
    {
        foreach (var product in products)
        {
            y(product);
        }
    }
    public static List<T> TransformProducts<T>(List<Product> products, Func<Product, T> y)
    {
        List<T> transformedProducts = new();
        foreach (var product in products)
        {
            transformedProducts.Add(y(product));
        }
        return transformedProducts;
    }
    public static void Main(string[] args)
    {
        List<Product> catalog = new()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
            new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
            new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
            new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
            new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
            new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
            new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
            new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
            new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 }
        };

        var electronics = SearchProducts(
            catalog,
            p => p.Category == "Electronics"
        );

        var under50 = SearchProducts(
            catalog,
            p => p.Price < 50
        );

        var inStock = SearchProducts(
            catalog,
            p => p.Stock > 0
        );

        var clothingUnder100 = SearchProducts(
            catalog,
            p => p.Category == "Clothing" && p.Price < 100
        );
        //Console.WriteLine("--- Electronics ---");

        //foreach (var product in electronics)
        //{
        //    Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
        //}


        //Console.WriteLine("\n--- Under $50 ---");

        //foreach (var product in under50)
        //{
        //    Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
        //}


        //Console.WriteLine("\n--- In Stock ---");

        //foreach (var product in inStock)
        //{
        //    Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
        //}


        //Console.WriteLine("\n--- Clothing Under $100 ---");

        //foreach (var product in clothingUnder100)
        //{
        //    Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
        //}


        //Console.WriteLine("--- Short Report ---");

        //PrintRepo(catalog, p =>
        //{
        //    Console.WriteLine($"{p.Name} - ${p.Price}");
        //});


        //Console.WriteLine("\n--- Detailed Report ---");

        //PrintRepo(catalog, p =>
        //{
        //    Console.WriteLine(
        //        $"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"
        //    );
        //});

        Console.WriteLine("--- Summary List ---");

        var summaryList = TransformProducts(
            catalog,
            p => $"{p.Name} (${p.Price})"
        );

        foreach (var item in summaryList)
        {
            Console.WriteLine(item);
        }


        Console.WriteLine("\n--- Price Labels ---");

        var priceLabels = TransformProducts(
            catalog,
            p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}"
        );

        foreach (var item in priceLabels)
        {
            Console.WriteLine(item);
        }
    }


}
