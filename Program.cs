using LINQ_SESSION_1.DataSources;
using LINQ_SESSION_1.Models;

namespace LINQ_SESSION_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Q1
            var SeafoodCat = Source.ProductList
          .Where(p => p.Category == "Seafood")
          .OrderBy(p => p.ProductName)
          .Select(p => new { p.ProductName, p.UnitPrice });

            foreach (var item in SeafoodCat)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
            }

            //Q2
            Console.WriteLine("--------------------------------------------------------------------------");
            var ProductsNames =Source.ProductList.OrderBy(p => p.ProductName).Select(p => p.ProductName);
            foreach (var item in ProductsNames)
            {
                Console.WriteLine(item);    
            }


            //Q3
            Console.WriteLine("--------------------------------------------------------------------------");
            var ProductsNamesWithPrices = Source.ProductList.OrderBy(p => p.UnitPrice).Select(p => new { p.ProductName, p.UnitPrice });
            foreach (var item in ProductsNamesWithPrices)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
            }

            //Q4
            Console.WriteLine("--------------------------------------------------------------------------");
            var FilterdProductPrices = Source.ProductList.Where(p => p.UnitPrice >10 && p.UnitPrice< 30).Select(p => new {p.ProductName , p.UnitPrice });
            foreach (var item in FilterdProductPrices)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
            }


            //Q5
            Console.WriteLine("--------------------------------------------------------------------------");

            var CondimentsCategory = Source.ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Spices & Condiments").Select(p => new { p.ProductName, p.UnitsInStock ,p.Category });
            foreach (var item in CondimentsCategory)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitsInStock} - {item.Category}");
            }
            // Q6
            Console.WriteLine("--------------------------------------------------------------------------");
            var ProductStatus = Source.ProductList
                .Select(p => new
                {
                    Name = p.ProductName,
                    Price = p.UnitPrice,
                    StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
                });

            foreach (var item in ProductStatus)
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.StockStatus}");
            }

            // Q7
            Console.WriteLine("--------------------------------------------------------------------------");
            var ProductWithIndex = Source.ProductList
                .Select((p, index) => new
                {
                    Position = index + 1,
                    Name = p.ProductName
                });

            foreach (var item in ProductWithIndex)
            {
                Console.WriteLine($"{item.Position}. {item.Name}");
            }


            //Q8
            Console.WriteLine("--------------------------------------------------------------------------");

            var SortedProducts = Source.ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var item in SortedProducts)
            {
                Console.WriteLine($"{item.Category} - {item.ProductName} - {item.UnitPrice}");
            }

            //Q9
            Console.WriteLine("--------------------------------------------------------------------------");

            var SortedProducts_Q9= Source.ProductList.Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock).Select(p => new {p.ProductName, p.UnitsInStock });

            foreach (var item in SortedProducts_Q9)
            {
                Console.WriteLine($" {item.ProductName} - {item.UnitsInStock}");
            }


            //Q10
            Console.WriteLine("--------------------------------------------------------------------------");
            var Orders1997 =
                from customer in Source.CustomerList
                from order in customer.Orders
                where order.OrderDate.Year >= 1997
                select new
                {
                    customer.CustomerID,
                    order.OrderDate
                };

            foreach (var item in Orders1997)
            {
                Console.WriteLine($"{item.CustomerID} - {item.OrderDate:d}");
            }

            // Q11
            var ProductsWithPosition = Source.ProductList
                .Select((p, index) => new
                {
                    Position = index + 1,
                    p.ProductName
                });

            foreach (var item in ProductsWithPosition)
            {
                Console.WriteLine($"{item.Position}. {item.ProductName}");
            }

            // Q12
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var SortedWords = Arr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var word in SortedWords)
            {
                Console.WriteLine(word);
            }



        }
    }
}
