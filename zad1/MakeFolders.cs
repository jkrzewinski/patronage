using System;
using System.IO;
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
            this.folderName = "Name";
            // this.topFolder = @"C:\\Users\\Jacek\\Desktop\\Projekty\\zad0-1 patronage";  
            this.topFolder = Directory.GetCurrentDirectory();                 //nowa ścieżka, wcześniej używałem statycznej ścieżki poprostu dla własnej wygody w eksploratorze

        }
        public void DeepDive(int howManyTimes)
        {
            try
            {
                if (howManyTimes == 0)
                {
                    return;
                }
                Guid firstGuid = Guid.NewGuid();
                folderName = firstGuid.ToString();
                Directory.CreateDirectory(Path.Combine(topFolder, folderName));
                topFolder = Path.Combine(topFolder, folderName);
                patch = topFolder;
                Levels++;

                DeepDive(howManyTimes - 1);
            }
            catch (FormatException EX)
            {
                Console.WriteLine(EX.Message);
            }
            catch (UnauthorizedAccessException EX2)
            {
                Console.WriteLine(EX2.Message);
            }
            catch (DirectoryNotFoundException EXX)
            {
                Console.WriteLine(EXX.Message);
            }
            catch (ArgumentException EX3)
            {
                Console.WriteLine(EX3.Message);
            }
            catch (IOException EX4)
            {
                Console.WriteLine(EX4.Message);
            }
            catch (Exception EX5)
            {
                Console.WriteLine(EX5.Message);
            }
        }
        public void DrownItDown(int lvl)
        {
            string answer = "";
            string answer2 = "";
            try
            {
                if ((Levels - lvl) <= 0)
                {
                    if (Levels - lvl == 0)
                    {
                        if (!System.IO.File.Exists(Path.Combine(patch, "Emptyfile")))
                        {
                            var File = System.IO.File.Create(Path.Combine(patch, "Emptyfile"));
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

                                    System.IO.File.Delete(Path.Combine(patch, "Emptyfile"));
                                    var File2 = System.IO.File.Create(Path.Combine(patch, "Written file"));
                                    File2.Close();
                                    break;
                                }
                                else if (answer == "n")
                                {
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong choice, choose between y or n");
                                }

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
                                DeepDive(lvl - Levels);
                                DrownItDown(lvl);

                                break;
                            }
                            else if (answer2 == "n")
                            {
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Wrong choice, choose between y or n");
                            }
                        }
                        return;
                    }
                }

                patch = Directory.GetParent(patch).ToString();
                DrownItDown(lvl + 1);
            }
            catch (FormatException EX)
            {
                Console.WriteLine(EX.Message);
            }
            catch (UnauthorizedAccessException EX2)
            {
                Console.WriteLine(EX2.Message);
            }
            catch (DirectoryNotFoundException EXX)
            {
                Console.WriteLine(EXX.Message);
            }
            catch (ArgumentException EX3)
            {
                Console.WriteLine(EX3.Message);
            }
            catch (IOException EX4)
            {
                Console.WriteLine(EX4.Message);
            }
            catch (Exception EX5)
            {
                Console.WriteLine(EX5.Message);
            }
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
