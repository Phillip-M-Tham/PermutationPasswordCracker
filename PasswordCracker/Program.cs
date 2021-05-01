using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PasswordCracker
{
    class Program
    {
        private static bool STOPRECURSION = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Password Cracker");
            StartGame();
        }

        private static void StartGame()
        {
            string input = "";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1.start\n2.Exit");
            Console.ResetColor();
            input = Console.ReadLine();

            if (input == "1")
            {//single threaded
                CreatePassword();
                StartGame();
            }
            else if (input == "2")
            {
                Console.WriteLine("Thank you for playing!!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That is not a valid input! Press anything to continue.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                StartGame();
            }
        }

        private static void CreatePassword()
        {
            if (STOPRECURSION != false)
            {
                STOPRECURSION = false;
            }
            string input = "";
            //1. write a program that generates all printable chars
            //2. prompt the user to enter a password ->They can choose the length
            //3. apply logic for start time, crack the password, stop time ->four chars in several mins
            Console.WriteLine("Please Enter A Password :");
            input = Console.ReadLine();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            SingleThread("", input);
            Console.WriteLine($"Single Thread: completed in {watch.Elapsed}");
            STOPRECURSION = false;
            watch.Restart();
            MultiThread("", input);
            Console.WriteLine($"Multi Thread: completed in {watch.Elapsed}");
            watch.Stop();
        }

        private static void MultiThread(string guess, string input)
        {
            string result = "";
            int ASCIIstart = 32;
            int ASCIIend = 127;
            char validchar;
            char[] originalkey = new char[95];
            int counter = 0;
            string update = "";
            for (int index = ASCIIstart; index < ASCIIend; index++)
            {//populates part of string
                validchar = (char)index;
                originalkey[counter] = validchar;
                counter++;
            }
            DiveParrallel(guess, 0, input, update, originalkey);
        }

        private static void DiveParrallel(string prefix, int level, string input, string update, char[] valid)
        {

            if (STOPRECURSION == true)
            {
                return;
            }
            else
            {
                level += 1;
                Parallel.For(51, 75, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                Parallel.For(76, 95, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                Parallel.For(0, 25, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                Parallel.For(26, 50, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                /*Parallel.For(31, 40, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                Parallel.For(41, 50, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                Parallel.For(51, 60, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                Parallel.For(61, 70, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                Parallel.For(71, 80, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                Parallel.For(81, 90, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });
                Parallel.For(91, 95, (x, state) =>
                {
                    update = prefix + valid[x];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        state.Break();
                    }
                    if (level < input.Length)
                    {
                        DiveParrallel(prefix + valid[x], level, input, update, valid);
                    }
                });*/
            }
        }

        private static void SingleThread(string guess, string input)
        {
            int ASCIIstart = 32;
            int ASCIIend = 127;
            char validchar;
            char[] originalkey = new char[95];
            int counter = 0;
            string update = "";
            for (int index = ASCIIstart; index < ASCIIend; index++)
            {//populates part of string
                validchar = (char)index;
                originalkey[counter] = validchar;
                counter++;
            }
            Dive(guess, 0, input, update, originalkey);
        }


        public static void Dive(string prefix, int level, string input, string update, char[] valid)
        {
            if (STOPRECURSION == true)
            {
                return;
            }
            else
            {
                level += 1;
                for (int start = 0; start < 95; start++)
                {
                    update = prefix + valid[start];
                    if (update == input)
                    {
                        Console.WriteLine($"PASSWORD MATCH FOUND. Password is [{update}]");
                        STOPRECURSION = true;
                        break;
                    }
                    if (level < input.Length)
                    {
                        Dive(prefix + valid[start], level, input, update, valid);
                    }
                }
            }
        }
    }
}
