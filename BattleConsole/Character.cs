using System;
using System.Collections.Generic;
using System.Text;

namespace BattleConsole
{
    class Character
    {
        public string Name;
        public int Health;
        public int Stamina;
        public Character()
        {
            Name = "error";

        }
        public Character(string name, int health, int stamina)
        {
            Name = name;
            Health = health;
            Stamina = stamina;

        }
    }
}
