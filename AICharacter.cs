namespace mis321_pa5_gbmorris1
{
        public class AICharacter : CharacterBase
    {
        public AICharacter() : base("AI", CharacterType.Bowser) // Example, you can randomize this
        {
        }

        public override void Attack(ICharacter opponent)
        {
            int attackValue = Randomizer.GetRandomNumber(1, MaxPower);
            Console.WriteLine($"AI attacks with a power of {attackValue}!");
            opponent.Defend(attackValue);
        }
    }

}