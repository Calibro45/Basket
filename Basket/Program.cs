namespace Basket
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ListaSpesa();


            int CheckIsNum(List<Product> list)
            // controlla che input inserito sia un numero e sia compreso nel range della lista
            {
                var index = list.Count;

                while (index >= list.Count)
                {
                    var prodotto = Console.ReadLine();
                    var isNumero = Int32.TryParse(prodotto, out int numero);

                    if (isNumero && numero < list.Count)
                    {
                        index = numero;
                    }
                    else
                        Console.WriteLine("Inserisci un numero compreso nella lista.");
                };

                return index;
            }

            void ListaSpesa()
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
                        "\t- [U]scire dalla lista\n" +
                        "\t- [A]ggiungere un prodotto"
                        );

                    if (myBasket.Count > 0)
                    {
                        Console.WriteLine(
                            "\t- [R]imuovere un prodotto\n" +
                            "\t- [T]otale del carrello"
                        );
                    }

                    var input = (Console.ReadLine() ?? String.Empty).ToLower().Trim();

                    Console.Clear();

                    if (!string.IsNullOrEmpty(input))
                    {
                        if (input == "a")
                        {
                            Console.WriteLine("Aggiungi un prodotto dalla lista utilizzando il suo codice:");

                            for (int i = 0; i < productList.Count; i++)
                            {
                                var product = productList[i];
                                Console.WriteLine($"\t[{i}] {product.Name} - {product.Price}$");
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
                                Console.WriteLine($"[{i}] {basketP.Name} - {basketP.Price}$");
                            }

                            var indexRemove = CheckIsNum(myBasket);
                            var productToRemove = myBasket[indexRemove];

                            myBasket.RemoveAt(indexRemove);

                            Console.WriteLine($"Hai rimosso {productToRemove.Name}.");
                        }
                        else if (input == "t")
                        {
                            Console.WriteLine($"Ecco il tuo Carrello:\n");

                            foreach (var product in myBasket)
                            {
                                var prLength = product.Name.Length;
                                var pad = (15 - prLength) + prLength;

                                Console.WriteLine($"- {product.Name.PadRight(pad)} | {product.Price}$");
                            }

                            myBasket.TotalPrice();

                            Console.WriteLine(
                                $"______________________________\n\n" +
                                $"- Totale prodotti | {myBasket.Total}$\n"
                                );
                        }
                        else if (input == "u")
                        {
                            Console.WriteLine($"Vuoi uscire dal programma? (y/n)");

                            var answer = (Console.ReadLine() ?? string.Empty).ToLower().Trim();

                            while (string.IsNullOrEmpty(answer) && answer != "y" && answer != "n")
                            {
                                Console.WriteLine("Inserisci un valore valido! (y/n)");
                                answer = Console.ReadLine();
                            }

                            answer = answer.ToLower().Trim();

                            if (answer == "n")
                            {
                                Console.Clear();
                                ListaSpesa();
                            }
                            else
                                isEnd = true;
                        }
                    }
                    else
                        Console.WriteLine("Inserisci un input valido relativo alle opzioni.\n");
                }
            }
        }
    }
}