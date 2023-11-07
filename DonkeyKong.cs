namespace mis321_pa5_gbmorris1
{
    public class DonkeyKong : CharacterBase
    {
        public DonkeyKong() : base("Donkey Kong", CharacterType.DonkeyKong)
        {
        }

        public override void Attack(ICharacter opponent)
        {
            int baseAttack = Randomizer.GetRandomNumber(1, MaxPower);
            float typeBonus = (opponent.Type == CharacterType.Bowser) ? 1.2f : 1.0f;
            int attackPower = (int)(baseAttack * typeBonus);

            Console.WriteLine($"{Name} attacks {opponent.Name} with Fire Flower for {attackPower} damage!");
            opponent.Defend(attackPower);
        }

    }
}