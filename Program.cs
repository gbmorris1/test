using mis321_pa5_gbmorris1;
         //start main
    int userChoice = GetUserChoice();
    while(userChoice!=3) {//condition check
        RouteEm(userChoice);
        userChoice = GetUserChoice();
    }
    Console.WriteLine("Thank you for playing!");
    //End Main
    static int GetUserChoice() {
        DisplayMenu();
        string userChoice=Console.ReadLine();
        if(IsValidChoice(userChoice)) {
            return int.Parse(userChoice);
        }
        else return 0;
    }
    
    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Super Mario Battle Game");
        Console.WriteLine("1. Start New Game");
        System.Console.WriteLine("2. View Rules");
        System.Console.WriteLine("3. Exit");
    }

    static bool IsValidChoice(string userInput) {
        if(userInput=="1" || userInput=="2" || userInput=="3") {
            return true;
        }
        return false;
    }

    static void RouteEm(int menuChoice) {
        if(menuChoice==1) {
            StartGame();
        }
        if(menuChoice==2) {
            ShowRules();
        }
        else if(menuChoice!=3){
            SayInvalid();
        }

        }
        static void SayInvalid() {
        System.Console.WriteLine("Invalid!");
        PauseAction();
        }
    static void PauseAction() {
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void StartGame()
    {
        Console.WriteLine("Starting a new game...");
        Game game = new Game();
        game.InitializeGame();
        game.StartBattle();
    }

static void ShowRules() {
    Console.Clear();
    Console.WriteLine("=== Super Mario Battle Game Rules ===\n");
    Console.WriteLine("1. Each player chooses a character from the Mario universe.");
    Console.WriteLine("2. Characters take turns attacking each other.");
    Console.WriteLine("3. On your turn, choose to either Attack or View Stats.");
    Console.WriteLine("4. Viewing your stats does not consume your turn.");
    Console.WriteLine("5. Each attack's strength is determined randomly, up to your character's Max Power.");
    Console.WriteLine("6. Each defense's effectiveness is also determined randomly each turn.");
    Console.WriteLine("7. Characters have type advantages that may affect the attack's strength:");
    Console.WriteLine("   - Mario has an advantage over Bowser.");
    Console.WriteLine("   - Donkey Kong has an advantage over Mario.");
    Console.WriteLine("   - Bowser has an advantage over Donkey Kong.");
    Console.WriteLine("8. The battle continues until one character's health drops to zero.");
    Console.WriteLine("9. The first player to reduce their opponent's health to zero wins the game.");
    Console.WriteLine("\nPress any key to return to the main menu...");
    Console.ReadKey();
}



