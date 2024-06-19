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
            
            while (!isEnd)
            {
                Console.WriteLine(
                    "Cosa vuoi Fare?\n" +
                    "-'a' Aggiungere un prodotto" 
                    );

                if (myBasket.Count > 0)
                {
                    Console.WriteLine(
                        "-'r' Rimuovere un prodotto\n" +
                        "-'e' Terminare la lista e vedere il totale"
                    );
                }

                var input = (Console.ReadLine() ?? String.Empty).ToLower().Trim();

                Console.Clear();

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

                        var index = CheckIsNum(productList);

                        myBasket.Add(productList[index]);

                        Console.WriteLine($"Hai aggiunto {productList[index].Name} alla lista.\n");
                    }
                    else if (input == "r")
                    {
                        Console.WriteLine($"Che prodotto vuoi rimuovere?");

                        for (int i = 0; i < myBasket.Count; i++)
                        {
                            var basketP = myBasket[i];
                            Console.WriteLine($"[{i}] {basketP.Name} - {basketP.Price}");
                        }

                        var indexRemove = CheckIsNum(myBasket);
                        var productToRemove = myBasket[indexRemove];

                        myBasket.RemoveAt(indexRemove);

                        Console.WriteLine($"Hai rimosso {productToRemove.Name}.");
                        
                    }
                    else
                        isEnd = true;
                }
            }
            
        }

        private static int CheckIsNum(List<Product> list)
        // controlla che input inserito sia un numero e sia compreso nel range della lista
        {
            var index = list.Count;

            while (index >= list.Count)
            {
                var prodotto = Console.ReadLine();

                if (Int32.TryParse(prodotto, out int numero))
                {
                    index = numero;

                    if (index >= list.Count)
                        Console.WriteLine("Inserisci un numero compreso nella lista.");
                }
            };

            return index;
        }
    }
}
