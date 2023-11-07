namespace mis321_pa5_gbmorris1
{
    public static class Randomizer
    {
        private static Random random = new Random();
        public static int GetRandomNumber(int min, int max) {
            return random.Next(min, max+1);
        }
    }
}