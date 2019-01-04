using System;

namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number, number2, number3;
                write divisible = new write();
                number = divisible.Validation();
                divisible.FizzBuzz(number);
                MakeFolders aaa = new MakeFolders();
                number2 = aaa.Validation("How many nested folders do you want to create? The limit is 5.");
                aaa.DeepDive(number2);
                number3 = aaa.Validation("At what level you want to place an empty file");
                aaa.DrownItDown(number3);                                                  //tworzymy plik
                number3 = aaa.Validation("At what level you want to place an empty file");
                aaa.DrownItDown(number3);                                                  //drugie wywołanie mające na celu nadpisanie pierwszego pliku
                                                                                           //Console.WriteLine(aaa.Levels);
                aaa.Exit();
            }
            catch (FormatException EX)
            {
                Console.WriteLine(EX.Message);
            }
            catch (Exception EX2)
            {
                Console.WriteLine(EX2.Message);
            }
        }

    }

}
