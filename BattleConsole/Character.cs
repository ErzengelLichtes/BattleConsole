using System;
using System.Collections.Generic;
using System.Text;

namespace BattleConsole
{
    class Character
    {
        public string Name;
        public CharacterStat Health;
        public CharacterStat Stamina;
        public CharacterStat Mana;
        public CharacterAction Action;
        public Character()
        {
            Name = "error";

        }
        public Character(string name, int health, int stamina, int mana)
        {
            Name = name;
            Health = CharacterStat.Create(health);
            Stamina = CharacterStat.Create(stamina);
            Mana = CharacterStat.Create(mana);
        }
    }
}
