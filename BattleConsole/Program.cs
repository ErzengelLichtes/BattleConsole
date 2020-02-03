﻿using System;

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
                PrintCharacterCard("Player", playerHealth, playerStamina);
                Console.WriteLine();
                PrintCharacterCard("Slime", enemyHealth, enemyStamina);

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
            int remainder = statValue % 10;
            if (remainder != 0)
            {
                if (remainder <= 4) { statusBar = statusBar + "."; }
                else if (remainder <= 7) { statusBar = statusBar + "-"; }
                else if (remainder <= 9) { statusBar = statusBar + "/"; }
            }
            return statusBar;

        }

        public static void PrintCharacterCard(string characterName, int charHealth, int charStamina)
        {
            Console.WriteLine(characterName);
            Console.WriteLine($"Health: {GetStatusBar(charHealth)} {charHealth}");
            Console.WriteLine($"Stamina: {GetStatusBar(charStamina)} {charStamina}");
        }


    }
}
