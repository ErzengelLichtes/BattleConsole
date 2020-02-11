namespace BattleConsole {
    class CharacterStat
    {
        public int Max;
        public int Value;

        public static CharacterStat Create(in int max)
        {
            if(max == -1) return null;
            return new CharacterStat() {Max = max, Value = max};
        }

        public void Change(int change)
        {
            Value += change;
            if(Value > Max) Value = Max;
            if(Value < 0) Value = 0;
        }

        public int TryChange(int change)
        {
            int result = Value + change;
            if(result < 0) return -1;
            if(result > Max) return 1;
            Value = result;
            return 0;
        }
    }
}