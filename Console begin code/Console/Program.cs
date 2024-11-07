using System;
using System.Diagnostics;
using System.Security.Cryptography;
using Backend;
using Backend.Bedrag;
using Backend.Bedrag.function;
using Backend.Item;

class Program
{
    static void Main(string[] args)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());

        string input;
        int inputInt;

        WishList wishList = new WishList();

        Console.Clear();

        do
        {
            Console.WriteLine("kies 1 van de opties:");
            Console.WriteLine("1. bedrag");
            Console.WriteLine("2. item");
            Console.WriteLine("0. om te stoppen");

            Console.WriteLine("\nWat wilt u doen?");
            input = Console.ReadLine();

             try
            {
                inputInt = Int32.Parse(input);
            }
            catch
            {
                inputInt = -1;
            }

             switch(inputInt)
            {
                case 0:
                    break;
                case 1:
                    // bedrag
                    bedrag(wishList);
                    break;
                case 2:
                    // item
                    item(wishList);
                    break;
            }


        }while(inputInt !=0);
       

    }

    public static void bedrag(WishList wishList)
    {
        string input;
        int inputInt;
        do
        {
            Console.WriteLine("kies 1 van de opties:");
            Console.WriteLine("1. bedrag toevoegen");
            Console.WriteLine("2. bedrag wissen");
            Console.WriteLine("3. bedragen bekijken");
            Console.WriteLine("4. totaal bedarg bekijken");
            Console.WriteLine("0. om te stoppen");

            Console.WriteLine("\nWat wilt u doen?");
            input = Console.ReadLine();
            
            try
            {
                inputInt = Int32.Parse(input);
            }
            catch
            {
                inputInt = -1;
            }


            switch(inputInt)
            {
                case 0:
                    break;
                case 1:
                    // bedrag toevoegen
                    Console.Clear();
                    Bedrag newbedrag = new Bedrag();
                    wishList.Bedragen.Add(newbedrag);
                    break;
                case 2:
                    // bedrag wissen
                    int wisInputInt = -1;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Kies een bedrag dat u wilt verwijderen:");
                        BedragFunction.readAllBedragen(wishList.Bedragen);
                        Console.WriteLine("Geef het bedrag nummer:");
                        string wisInput = Console.ReadLine();
                        try
                        {
                            wisInputInt = Int32.Parse(wisInput);
                        }
                        catch
                        {
                            wisInputInt = -1;
                        }
                    } while (!(wisInputInt >= 0 && wisInputInt < (wishList.Bedragen.Count - 1)));

                    wishList.Bedragen = BedragFunction.DelBedrag(wishList.Bedragen, wisInputInt);

                    break;
                case 3:
                    // bedragen bekijken
                    Console.Clear();
                    BedragFunction.readAllBedragen(wishList.Bedragen);
                    do
                    {
                        Console.WriteLine("\n\n0. om er uit te gaan");
                        input = Console.ReadLine();
                    }while(input != "0");
                    break;
                case 4:
                    // totaal bedarg bekijken
                    Console.Clear();
                    float totaalBedrag = BedragFunction.getTotaalBedrag(wishList.Bedragen);
                    Console.WriteLine("Het totaal bedrag = €" + totaalBedrag);

                    do
                    {
                        Console.WriteLine("\n\n0. om er uit te gaan");
                        input = Console.ReadLine();
                    }while(input != "0");
                    break;
                default:
                    Trace.WriteLine("Incorect input", "ERROR");
                    break;
            }
        }while(inputInt != 0);
    }

    public static void item (WishList wishList)
    {
        string input;
        int inputInt;
        do
        {
            Console.WriteLine("kies 1 van de opties:");
            Console.WriteLine("1. item toevoegen");
            Console.WriteLine("2. item wissen");
            Console.WriteLine("3. items bekijken");
            Console.WriteLine("4. item kopen");
            Console.WriteLine("0. om te stoppen");

            Console.WriteLine("\nWat wilt u doen?");
            input = Console.ReadLine();
            
            try
            {
                inputInt = Int32.Parse(input);
            }
            catch
            {
                inputInt = -1;
            }


            switch(inputInt)
            {
                case 0:
                    break;
                case 1:
                    // item toevoegen
                    Console.Clear();
                    Item item = new Item();
                    wishList.items.Add(item);
                    break;
                case 2:
                    // item wissen
                     int wisInputInt = -1;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Kies een item dat u wilt verwijderen:");
                        wishList.readAllItems();
                        Console.WriteLine("Geef het item nummer:");
                        string wisInput = Console.ReadLine();
                        try
                        {
                            wisInputInt = Int32.Parse(wisInput);
                        }
                        catch
                        {
                            wisInputInt = -1;
                        }
                    } while (!(wisInputInt >= 0 && wisInputInt < (wishList.items.Count - 1)));

                    wishList.DelItems(wisInputInt);
                    break;
                case 3:
                    // item bekijken
                    wishList.readAllItems();
                    do
                    {
                        Console.WriteLine("\n\n0. om er uit te gaan");
                        input = Console.ReadLine();
                    }while(input != "0");
                    break;
                case 4:
                    // item kopen
                    Console.Clear();
                    int koopInputInt = -1;
                    Console.WriteLine("Kies een item dat u wilt kopen:");
                    wishList.readAllItems();
                    Console.WriteLine("Geef het item nummer:");
                    string koopInput = Console.ReadLine();
                    try
                    {
                        koopInputInt = Int32.Parse(koopInput);
                    }
                    catch
                    {
                        koopInputInt = -1;
                    }
                    wishList.koopItem(koopInputInt);
                    break;
                default:
                    Trace.WriteLine("Incorect input", "ERROR");
                    break;
            }
        }while(inputInt != 0);
    }
}
