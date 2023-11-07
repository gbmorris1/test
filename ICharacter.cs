namespace mis321_pa5_gbmorris1
{
    public interface ICharacter
    {
        string Name { get; }
        int MaxPower { get; }
        int Health { get; set;}
        int AttackStrength { get; }
        int DefensivePower { get; }
        CharacterType Type{get; }

        void Attack(ICharacter opponent);
        void Defend(int attackStrength);
        void DisplayStats();
    }

}