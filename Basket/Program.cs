namespace Basket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<Product>
            {
                new Product("Latte", 2.50m),
                new Product("Pane", 1.00m),
                new Product("Pizza", 5.00m),
                new Product("Pasta", 1.00m),
                new Product("Piadine", 2.50m),
                new Product("Prosciutto", 3.00m),
                new Product("Salame", 3.00m),
                new Product("Formaggio", 2.00m),
                new Product("Patatine", 1.00m),
                new Product("Acqua", 1.00m)
            };
               
            var myBasket = new Basket();
            bool isEnd = false;

            Console.WriteLine("Benvenuto nella tua lista della spesa!\n");

            Console.WriteLine(
                "Cosa vuoi Fare?\n" +
                "-'a' Aggiungere un prodotto\n" +
                "-'r' Rimuovere un prodotto\n" +
                "-'e' Terminare la lista e vedere il totale"
                );
            
            while (!isEnd)
            {
                var input = (Console.ReadLine() ?? String.Empty).ToLower().Trim();

                if (!string.IsNullOrEmpty(input) )
                {
                    if (input == "a")
                    {
                        Console.WriteLine("Aggiungi un prodotto dalla lista utilizzando il suo codice:");

                        for (int i = 0; i < productList.Count; i++)
                        {
                            var product = productList[i];   
                            Console.WriteLine($"[{i}] {product.Name} - {product.Price}");
                        }

                        var index = productList.Count;

                        while (index >= productList.Count) 
                        {
                            var prodotto = Console.ReadLine();

                            if (Int32.TryParse(prodotto, out int numero))
                            {
                                index = numero;
                            }
                        };

                        myBasket.Add(productList[index]);

                        foreach (var item in myBasket)
                        {
                            Console.WriteLine(item.Name);
                        }
                    }
                    else
                        isEnd = true;
                }
            }

            




        }
    }
}
