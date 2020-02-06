using System;

namespace BattleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable definitions.
          

            Character player = new Character("Player",100,100);
            Character enemy = new Character("Slime", 100, 100);

            bool active = true;
            while (active)
            {

                Console.Clear();
                //Display character cards.
                PrintCharacterCard(player);
                Console.WriteLine();
                PrintCharacterCard(enemy);

                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.H:
                        player.Health -= 1;
                        break;
                    case ConsoleKey.J:
                        player.Stamina -= 1;
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
            int remainder = statValue % 10;
            if (remainder != 0)
            {
                string toAdd = "error";
                if (remainder <= 4) { toAdd = "."; }
                else if (remainder <= 7) { toAdd = "-"; }
                else if (remainder <= 9) { toAdd = "/"; }
                statusBar += toAdd;
            }
            return statusBar;

        }

        public static void PrintCharacterCard(Character character)
        {
            PrintCharacterCard(character.Name, character.Health, character.Stamina);
        }
        public static void PrintCharacterCard(string characterName, int charHealth, int charStamina)
        {
            Console.WriteLine(characterName);
            PrintStatLine($"Health", charHealth);
            PrintStatLine($"Stamina", charStamina);
        }
        public static void PrintStatLine(string statName, int statValue)
        {
            Console.WriteLine($"{statName}: {GetStatusBar(statValue)} {statValue}");
        }

    }
}
