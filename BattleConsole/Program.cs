using System;
using System.Diagnostics;

namespace BattleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable definitions.
            CharacterAction attack = new CharacterAction()
                                     {
                                         Self = new CharacterActionStats()
                                                {
                                                    Stamina = new CharacterActionLine(){Change = -8}
                                                }, 
                                         Target = new CharacterActionStats()
                                                  {
                                                      Health = new CharacterActionLine(){Change = -5}
                                                  }
                                     };
            CharacterAction guard = new CharacterAction()
                                     {
                                         Self = new CharacterActionStats()
                                                {
                                                    Stamina = new CharacterActionLine() { Change = 12 },
                                                    Health = new CharacterActionLine() { NegativeMultiplier = 0.5f }
                                                },
                                     };
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

                CharacterActionsProcess(player, enemy);
                CharacterActionsProcess(enemy, player);

                if(player.Health.Value == 0)
                {
                    Console.WriteLine("Game Over");
                    active = false;
                }
                else if(enemy.Health.Value == 0)
                {
                    Console.WriteLine("You Win!");
                    active = false;
                }
            }


        }

        public static void CharacterActionsProcess(Character actor, Character target)
        {
            //Change actor if possible
            
            //Actor's changes to itself
            var self = actor.Action.Self;
            //Target's changes to actor
            var other = target.Action.Target;

            actor.Health.Change(ProcessActionLine(self.Health, target.Action.Target.Health));
            if(actor.Stamina.TryChange(ProcessActionLine(self.Stamina, other.Stamina)) < 0)
            {
                actor.Stamina.Change(3);
                return;
            }
            if (actor.Mana.TryChange(ProcessActionLine(self.Mana, other.Mana)) < 0)
            {
                return;
            }

            //Change target

            //Actor's changes to target
            self = actor.Action.Target;
            //Target's changes to itself
            other = target.Action.Self;

            target.Health .Change(ProcessActionLine(self.Health , other.Health ));
            target.Stamina.Change(ProcessActionLine(self.Stamina, other.Stamina));
            target.Mana   .Change(ProcessActionLine(self.Mana   , other.Mana   ));
        }

        static int ProcessActionLine(CharacterActionLine actorLine, CharacterActionLine targetLine)
        {
            int change = targetLine.Change;
            float multiplier;
            if(change < 0)
                multiplier = targetLine.NegativeMultiplier * actorLine.NegativeMultiplier;
            else
                multiplier = targetLine.PositiveMultiplier * actorLine.PositiveMultiplier;
            return (int)(change * multiplier);
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

        public static void PrintStatLine(string statName, CharacterStat stat)
        {
            int statValue = stat.Value;
            if (statValue >= 0)
            {
                Console.WriteLine($"{statName}: {GetStatusBar(statValue)} {statValue}");
            }
        }

    }
}
