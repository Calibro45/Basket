namespace Basket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myBasket = new Basket
            {
                new Product("Latte", 2.50m),
                new Product("Pane", 1),
                new Product("Pizza", 5),
                new Product("Pasta", 1),
                new Product("Piadine", 2.50m),
                new Product("Prosciutto", 3),
                new Product("Salame", 3),
                new Product("Formaggio", 2),
                new Product("Patatine", 1),
                new Product("Acqua", 1)
            };

            foreach (var item in myBasket)
            {
                Console.WriteLine($"{item.Name}, {item.Price}");
            }

            myBasket.TotalPrice();
            Console.WriteLine(myBasket.Total);


        }
    }
}
