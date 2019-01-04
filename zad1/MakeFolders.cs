using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
namespace zad1
{
    class MakeFolders
    {
        string folderName;
        string topFolder;
        string patch;
        public int Levels { get; set; }
      
        public MakeFolders()
        {
            this.Levels = 0;
            this.folderName ="Name";
            this.topFolder = @"C:\\Users\\Jacek\\Desktop\\Projekty\\zad0-1 patronage";  //ścieżka miejsca na dysku w którym tworzę foldery
        }
        public void DeepDive(int howManyTimes)
        {
            if (howManyTimes == 0)
                return;

            Guid firstGuid = Guid.NewGuid();
            folderName = firstGuid.ToString();
            Directory.CreateDirectory(topFolder +"\\"+ folderName);
            topFolder += "\\" + folderName;
            patch = topFolder;
            Levels++;

            DeepDive(howManyTimes - 1);
        }
        public void DrownItDown(int lvl)
        {
            string answer = "";
            string answer2 = "";
           
            if ((Levels - lvl) <= 0)
            {
                if (Levels - lvl == 0)
                {
                    if (!System.IO.File.Exists(patch + "\\" + "Emptyfile"))
                    {
                       var File= System.IO.File.Create(patch + "\\" + "Emptyfile");
                        File.Close();
                        
                    }
                    else
                    {
                        Console.WriteLine("File already exist, do I should overwrite it ? y/n");
                        while (answer != "y" || answer != "n")
                        {
                           
                                answer = Console.ReadLine().ToString();
                                answer = answer.ToLower();

                            if (answer == "y")
                            {

                                System.IO.File.Delete(patch + "\\"+"Emptyfile");
                                var File2=System.IO.File.Create(patch + "\\" + "Written file");
                                File2.Close();
                                break;
                            }
                            else if (answer == "n")
                                return;
                            else
                                Console.WriteLine("Wrong choice, choose between y or n");

                        }
                    }
                    patch = topFolder;
                    return;
                }
                if (Levels - lvl < 0)
                {
                    Console.WriteLine("The structure has only " + Levels + " nested folders, do you want to create the rest to place the file at the appropriate level ? y/n ");
                    while (answer2 != "y" || answer2 != "n")
                    {
                        answer2 = Console.ReadLine().ToString();
                        answer2 = answer2.ToLower();
                        if (answer2 == "y")
                        {
                            DeepDive(lvl-Levels);
                            DrownItDown(lvl);
                            
                            break;
                        }
                        else if (answer2 == "n")
                            return;
                        else
                            Console.WriteLine("Wrong choice, choose between y or n");
                    }
                    return;
                }
            }

            patch = Directory.GetParent(patch).ToString();
            DrownItDown(lvl + 1);
        }
        public int Validation(string textMessage)
        {
            string temporary;
            int parametr = -1;
            Console.WriteLine(textMessage);
            while (parametr < 1 || parametr > 5)
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
                catch (Exception EX2)
                {
                    Console.WriteLine(EX2.Message);
                }

                if (parametr >= 1 && parametr <= 5)
                {
                    break;

                }
                else
                {
                    Console.WriteLine("The number does not fit in the numeric range, choose between 1 and 5");
                }
            }
            return parametr;
        }
        public void Exit()
        {
            Console.WriteLine("bye bye ;)");
            
        }
    }
}
