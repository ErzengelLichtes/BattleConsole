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
        public int Mana;
        public Character()
        {
            Name = "error";

        }
        public Character(string name, int health, int stamina, int mana)
        {
            Name = name;
            Health = health;
            Stamina = stamina;
            Mana = mana;

        }
    }
}
