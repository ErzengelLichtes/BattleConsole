using System;

namespace BattleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable definitions.
            int playerHealth = 100;
            int playerStamina = 100;
            int enemyHealth = 100;
            int enemyStamina = 100;
          

            bool active = true;
            while (active)
            {
               
                Console.Clear();
                //Display character cards.
                PrintCharacterCard(playerHealth, playerStamina);
                Console.WriteLine("Enemy");
                Console.WriteLine($"Health: {GetStatusBar(enemyHealth)} {enemyHealth}");
                Console.WriteLine($"Stamina: {GetStatusBar(enemyStamina)} {enemyStamina}");
                
                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.H:
                        playerHealth -= 1;
                        break;
                    case ConsoleKey.J:
                        playerStamina -= 1;
                        break;
                    case ConsoleKey.Escape:
                        active = false;
                        break;
                }
            }


        }
        public static string GetStatusBar(int statValue) 
        {
            string statusBar = new string('|', statValue / 10);
            if (statValue % 10 != 0) { statusBar = statusBar + "-"; }
            return statusBar;

        }

        public static void PrintCharacterCard(int playerHealth, int playerStamina)
        { Console.WriteLine("Player");
            Console.WriteLine($"Health: {GetStatusBar(playerHealth)} {playerHealth}");
             Console.WriteLine($"Stamina: {GetStatusBar(playerStamina)} {playerStamina}"); }
}
}
