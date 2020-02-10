using System;

namespace BattleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable definitions.
            CharacterAction attack = new CharacterAction() { TargetChangeHealth = -5, SelfChangeStamina = -8 };
            CharacterAction guard = new CharacterAction() { SelfNegMultiplierHealth = 0.5f, SelfChangeStamina = 12 };
            Character player = new Character("Player", 100, 100,100);
            Character enemy = new Character("Slime", 100, 100,-1);


            bool active = true;
            while (active)
            {

                Console.Clear();
                //Display character cards.
                PrintCharacterCard(player);
                PrintCharacterCard(enemy);
                Console.WriteLine("A: Attack    S: Guard");

                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        player.Action = attack;
                        break;
                    case ConsoleKey.S:
                        player.Action = guard;
                        break;
                    case ConsoleKey.H:
                        if (player.Health > 0)
                        {
                            player.Health -= 1;
                        }
                        break;
                    case ConsoleKey.J:
                        if (player.Stamina > 0)
                        {
                            player.Stamina -= 1;
                        }
                        break;
                    case ConsoleKey.Escape:
                        active = false;
                        break;
                }
                Random r = new Random();
                switch (r.Next(0, 2))
                {
                    case 0:
                        enemy.Action = attack;
                        break;
                    case 1:
                        enemy.Action = guard;
                        break;
                    default:
                        throw new NotImplementedException();



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
            Console.WriteLine(character.Name);
            PrintStatLine($"Health", character.Health);
            PrintStatLine($"Stamina", character.Stamina);
            PrintStatLine($"Mana", character.Mana);
            Console.WriteLine();
        }

        public static void PrintStatLine(string statName, int statValue)
        {
            if (statValue >= 0)
            {
                Console.WriteLine($"{statName}: {GetStatusBar(statValue)} {statValue}");
            }
        }

    }
}
