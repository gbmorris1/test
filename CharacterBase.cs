namespace mis321_pa5_gbmorris1
{
    public abstract class CharacterBase : ICharacter
    {
        public string Name { get; private set; }
        public int MaxPower { get; private set; }
        public int Health { get; set; }
        public int AttackStrength { get; private set; }
        public int DefensivePower { get; private set; }
        public CharacterType Type{get; private set;}

        protected CharacterBase(string name, CharacterType Type)
        {
            Name = name;
            MaxPower = Randomizer.GetRandomNumber(1, 100);
            Health = 100;
            AttackStrength = Randomizer.GetRandomNumber(1, MaxPower);
            DefensivePower = Randomizer.GetRandomNumber(1, MaxPower);
        }

        public abstract void Attack(ICharacter opponent);

    public virtual void Defend(int attackStrength)
    {
        int defenseValue = Randomizer.GetRandomNumber(1, MaxPower);
        int damage = Math.Max(attackStrength - defenseValue, 0);
        Health -= damage;
        Console.WriteLine($"{Name} defended with a power of {defenseValue} and took {damage} damage.");
    }

        public void DisplayStats()
        {
            Console.WriteLine($"{Name}'s Stats - Health: {Health}, Attack: {AttackStrength}, Defense: {DefensivePower}");
        }
    }
}

