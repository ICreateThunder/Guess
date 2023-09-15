namespace Guess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Generate random value
            Random random = new Random();
            byte value = Convert.ToByte(random.Next(1, 100));

            byte input;

            Console.WriteLine("---           ---\n- Guessing Game -\n---           ---\n\nWelcome, the game is simple: Guess the value.\nThe program will think of a number between 1 and 99.\nIt's your job to guess it in a maximum of 6 turns. \n\nGood luck\n\n");

            for (byte i = 0; i < 6; i++)
            {
                // Give prompt
                Console.Write($"Enter your {i + 1}{integerSuffix(i+1)} guess:");

                // Set the value to outside the bounds
                input = 255;

                try
                {
                    input = Convert.ToByte(Console.ReadLine());
                } catch (OverflowException) { Console.WriteLine($"[!] ERROR :: Value outside of bounds. Select value between 1 - 99\n\nRemaining guesses: {6-(i+1)}/6"); }
                catch (Exception) { Console.WriteLine($"[!] ERROR :: Something went wrong. Select value between 1 - 99\n\nRemaining guesses: {6-(i+1)}/6"); }

                if (input > 99)
                {
                    Console.WriteLine($"[!] ERROR :: Value outside of bounds. Select value between 1 - 99\\n\\nRemaining guesses: {6 - (i + 1)}/6");
                    continue;
                }

                if (input == value)
                {
                    Console.WriteLine("[-] INFO :: You have guessed correctly!");
                    break;
                }
                else if (input < value) { Console.WriteLine("[-] INFO :: Your guess is lower than the value"); }
                else { Console.WriteLine("[-] INFO :: Your guess is greater than the value"); }
            }
        }

        public static string integerSuffix(int value) { return (value.ToString()[value.ToString().Length - 1] == 1) ? "st" : "th"; }
    }
}