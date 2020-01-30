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
            string playerHealthBar = new string('|', playerHealth / 10);
            string playerStaminahBar = new string('|', playerStamina / 10);
            string enemyHealthBar = new string('|', enemyHealth / 10);
            string enemyStaminaBar = new string('|', enemyStamina / 10);


            bool active = true;
            while (active)
            {
                //Display character cards.
                Console.WriteLine("Player");
                Console.WriteLine($"Health: {playerHealthBar} {playerHealth}");
                Console.WriteLine($"Stamina: {playerStaminahBar} {playerStamina}");
                Console.WriteLine();
                Console.WriteLine("Enemy");
                Console.WriteLine($"Health: {enemyHealthBar} {enemyHealth}");
                Console.WriteLine($"Stamina: {enemyStaminaBar} {enemyStamina}");
                
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
    }
}
