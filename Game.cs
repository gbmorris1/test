namespace mis321_pa5_gbmorris1
{
    public class Game
    {
        private ICharacter playerOne;
        private ICharacter playerTwo;
        private string playerOneName;
        private string playerTwoName;
        private bool isPlayingAgainstAI;

        public void InitializeGame()
        {
            Console.WriteLine("Do you want to play against another player or AI?");
            Console.WriteLine("1. Player");
            Console.WriteLine("2. AI");
            Console.Write("Choose an option: ");
            isPlayingAgainstAI = GetUserChoice() == 2;

            Console.Write("Player One, enter your name: ");
            playerOneName = Console.ReadLine();
            playerOne = ChooseCharacter("Player One");

            if (!isPlayingAgainstAI)
            {
                Console.Write("Player Two, enter your name: ");
                playerTwoName = Console.ReadLine();
                playerTwo = ChooseCharacter("Player Two");
            }
            else
            {
                playerTwoName = "AI";
                playerTwo = CreateRandomCharacterForAI();
            }

            Console.Clear();
            Console.WriteLine($"{playerOneName} has chosen {playerOne.Name}");
            if (!isPlayingAgainstAI)
            {
                Console.WriteLine($"{playerTwoName} has chosen {playerTwo.Name}");
            }
            PauseAction();
        }

        private ICharacter ChooseCharacter(string playerName)
        {
            Console.WriteLine($"{playerName}, choose your character:");
            Console.WriteLine("1. Mario");
            Console.WriteLine("2. Donkey Kong");
            Console.WriteLine("3. Bowser");
            Console.Write("Enter the number of your choice: ");
            int userChoice = GetUserChoice();
            return RouteEm(userChoice);
        }
        private ICharacter CreateRandomCharacterForAI() {
            int characterChoice = Randomizer.GetRandomNumber(1, 3);
            if(characterChoice==1)
            {return new Mario();}
            else if(characterChoice==2){
                return new DonkeyKong();
            }
            else{
                return new Bowser();
            }
        }

        private int GetUserChoice()
        {
            string userChoice;
            do
            {
                userChoice = Console.ReadLine();
                if (!IsValidChoice(userChoice))
                {
                    Console.WriteLine("Invalid choice, please enter 1, 2, or 3.");
                }
            } while (!IsValidChoice(userChoice));

            return int.Parse(userChoice);
        }

        private bool IsValidChoice(string userInput)
        {
            return userInput == "1" || userInput == "2" || userInput == "3";
        }

        private ICharacter RouteEm(int menuChoice)
        {
            switch (menuChoice)
            {
                case 1:
                    return new Mario();
                case 2:
                    return new DonkeyKong();
                case 3:
                    return new Bowser();
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Mario.");
                    return new Mario();
            }
        }

    public void StartBattle()
{
    bool isPlayerOneTurn = Randomizer.GetRandomNumber(0, 1) == 0;

    Console.WriteLine("\n=== The battle begins! ===\n");
    Console.WriteLine(isPlayerOneTurn ? $"{playerOneName} goes first!" : $"{playerTwoName} goes first!");

    while (playerOne.Health > 0 && playerTwo.Health > 0)
    {
        ICharacter currentPlayer = isPlayerOneTurn ? playerOne : playerTwo;
        ICharacter opponentPlayer = isPlayerOneTurn ? playerTwo : playerOne;
        string currentPlayerName = isPlayerOneTurn ? playerOneName : playerTwoName;

        if (isPlayingAgainstAI && currentPlayer == playerTwo)
        {
            PerformAITurn(currentPlayer, opponentPlayer);
        }
        else
        {
            // Human player's turn
            Console.WriteLine($"\n{currentPlayerName}'s turn. What would you like to do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. View Stats");
            Console.Write("Enter the number of your choice: ");
            int actionChoice = GetUserChoice();

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine($"\n{currentPlayerName} chooses to attack!");
                    int attackValue = Randomizer.GetRandomNumber(1, currentPlayer.MaxPower);
                    currentPlayer.Attack(opponentPlayer);
                    opponentPlayer.DisplayStats();
                    break;
                case 2:
                    currentPlayer.DisplayStats();
                    Console.WriteLine("\nPress any key to return to actions...");
                    Console.ReadKey();
                    Console.Clear();
                    continue; // The turn does not end if they choose to view stats
                default:
                    Console.WriteLine("\nInvalid choice. Please enter 1 or 2.");
                    continue; // The turn does not end if an invalid choice is made
            }
        }

        if (opponentPlayer.Health <= 0)
        {
            Console.Clear();
            Console.WriteLine($"{opponentPlayer.Name} has been defeated!");
            break; // Exit the loop if the opponent is defeated
        }

        isPlayerOneTurn = !isPlayerOneTurn; // Switch turns
        PauseAction(); // Allow the players to see what happened before continuing
        Console.Clear(); // Clear the console for the next round
    }

    EndGame();
}

        private void PerformAITurn(ICharacter aiPlayer, ICharacter humanPlayer)
        {
            int attackValue = Randomizer.GetRandomNumber(1, aiPlayer.MaxPower);
            Console.WriteLine($"{playerTwoName} (AI) decides to attack with a power of {attackValue}!");
            aiPlayer.Attack(humanPlayer);
            humanPlayer.DisplayStats();
        }

        public void EndGame()
        {
            if (playerOne.Health <= 0)
            {
                Console.WriteLine($"{playerOneName} ({playerOne.Name}) has been defeated!\nGAME OVER");
                PauseAction();
            }
            else if (playerTwo.Health <= 0)
            {
                Console.WriteLine($"{playerTwoName} ({playerTwo.Name}) has been defeated!\n\n\nGAME OVER");
                PauseAction();
            }
            else
            {
                Console.WriteLine("The battle ended unexpectedly.");
                PauseAction();
            }
        }
    
        private void PauseAction() {
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        }
    }
}
