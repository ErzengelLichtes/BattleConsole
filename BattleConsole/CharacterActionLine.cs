namespace BattleConsole {
    class CharacterActionLine
    {
        public int   Change;
        public float PositiveMultiplier = 1.0f;
        public float NegativeMultiplier = 1.0f;
        public static readonly CharacterActionLine Default = new CharacterActionLine();
    }
}