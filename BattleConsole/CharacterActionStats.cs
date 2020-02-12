namespace BattleConsole {
    class CharacterActionStats
    {
        public CharacterActionLine Health;
        public CharacterActionLine Stamina;
        public CharacterActionLine Mana;

        public static readonly CharacterActionStats Default = new CharacterActionStats();
    }
}