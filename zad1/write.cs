using System;
using System.IO;

namespace zad1
{
    class write
    {
        int numericParametr;
        string divisible2;
        string divisible3;

        public write()
        {
            numericParametr = -1;
            divisible2 = "Fizz";
            divisible3 = "Buzz";
        }
        public int Validation()
        {
            string temporary;
            int parametr = -1;
            Console.WriteLine("Choose number between 0 and 1000");
            while (parametr < 0 || parametr > 1000)
            {

                try
                {
                    temporary = Console.ReadLine();
                    parametr = int.Parse(temporary);
                }
                catch (FormatException EX)
                {
                    Console.WriteLine(EX.Message);
                }
                catch (OverflowException EX1)
                {
                    Console.WriteLine(EX1.Message);
                }
                catch (IOException EX2)
                {
                    Console.WriteLine(EX2.Message);
                }
                catch (ArgumentOutOfRangeException EX3)
                {
                    Console.WriteLine(EX3.Message);
                }
                catch (Exception EX4)
                {
                    Console.WriteLine(EX4.Message);
                }

                if (parametr >= 0 && parametr <= 1000)
                {
                    break;

                }
                else
                {
                    Console.WriteLine("The number does not fit in the numeric range, choose between 0 and 1000");
                }
            }
            return parametr;

        }
        public void FizzBuzz(int numericParametr)
        {
            this.numericParametr = numericParametr;
            try
            {
                if (this.numericParametr % 2 == 0 && this.numericParametr % 3 == 0)
                {
                    Console.WriteLine(divisible2 + divisible3);
                }

                if (this.numericParametr % 2 == 0 && this.numericParametr % 3 != 0)
                {
                    Console.WriteLine(divisible2);
                }
                if (this.numericParametr % 2 != 0 && this.numericParametr % 3 == 0)
                {
                    Console.WriteLine(divisible3);
                }
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX.Message);
            }

        }
    }
}
