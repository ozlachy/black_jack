using System.Text;
while (true)
{
    while (true)
    {
        string blackjack = "  ____    _          _       ____   _  __      _      _       ____   _  __\n | __ )  | |        / \\     / ___| | |/ /     | |    / \\     / ___| | |/ /\n |  _ \\  | |       / _ \\   | |     | ' /   _  | |   / _ \\   | |     | ' / \n | |_) | | |___   / ___ \\  | |___  | . \\  | |_| |  / ___ \\  | |___  | . \\ \n |____/  |_____| /_/   \\_\\  \\____| |_|\\_\\  \\___/  /_/   \\_\\  \\____| |_|\\_\\";
        Console.WriteLine("\n" + blackjack + "\n");
        Console.Write("Hi there, welcome to Barry's Blessed Blackjack Bar. Would you like to Enter? (y/n):");
        string? userInput0 = Console.ReadLine();
        if (userInput0 == null)
        {
            Console.Clear();
            continue;
        }
        userInput0.ToLower();
        if (userInput0 == "n")
        {
            Console.Write("\nAre you sure you want to quit? (y/n):");
            string? userInput1 = Console.ReadLine();
            if (userInput1 == null)
            {
                Console.Clear();
                continue;
            }
            userInput1.ToLower();
            if (userInput1 == "y")
            {
                Console.Write("\n\rOk, Quiting in: 3");
                Thread.Sleep(1000);
                Console.Write("\rOk, Quiting in: 2");
                Thread.Sleep(1000);
                Console.Write("\rOk, Quiting in: 1");
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
            else if (userInput0 == "n")
            {
                Console.Clear();
                continue;
            }
        }
        else if (userInput0 == "y")
        {
            break;
        }
        else
        {
            Console.Clear();
            continue;
        }
    }
    int money = 100;
    bool gambaling = true;
    int betAmount;
    while (gambaling)
    {
        bool playing = true;
        bool win = false;
        Console.WriteLine("\nWallet:" + money);
        if (money <= 0)
        {
            Console.WriteLine("\nOops, looks like you're out of money. Press any key to return to the main menu:");
            Console.ReadKey();
            playing = false;
            win = true;
            Console.Clear();
            break;

        }
        while (true)
        {
            Console.Write("\nPlace your bet:");
            string? bet = Console.ReadLine();
            if (int.TryParse(bet, out betAmount))
            {
                if (betAmount > 0 && betAmount <= money)
                {
                    if (betAmount == 69)
                    {
                        Console.WriteLine("Ha, nice");
                        break;
                    }
                    else if (betAmount == money)
                    {
                        Console.WriteLine("All in! Good luck to you friend");
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (betAmount > money)
                {
                    Console.WriteLine("Hey, we both know you ain't go that kinda cash, try again");
                    continue;
                }
                else if (betAmount == 0)
                {
                    Console.WriteLine("Oh, so you wanna play for fun, not here bud, try again");
                    continue;
                }
                else if (betAmount < 0)
                {
                    Console.WriteLine("Really, a negative bet, we both know that ain't possible, try again");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("\nThats not a number dummy, try again");
                continue;
            }
        }
        Console.Write("\n\rRigging the game.");
        Thread.Sleep(333);
        Console.Write("\rRigging the game..");
        Thread.Sleep(333);
        Console.Write("\rRigging the game...\n");
        Thread.Sleep(333);

        Participant dealer = new Participant();
        Participant player = new Participant();

        bool firstTurn = true;
        while (playing)
        {
            Console.WriteLine("\n====DEALER HAS====");
            if (firstTurn == true)
            {
                card dealersCard02 = new card(dealer);
                card dealersCard01 = new card(dealer);
            };
            Console.WriteLine(deckBuilder(dealer, true));
            Console.WriteLine("====PLAYER HAS====");
            card playersCard01 = new card(player);
            if (firstTurn == true) { card playersCard02 = new card(player); firstTurn = false; }
            Console.WriteLine(deckBuilder(player, false));

            if (player.cardsValue > 21)
            {
                foreach (var card in player.cardsList)
                {
                    if (card.number == "A")
                    {
                        player.cardsValue -= 10;
                        card.number = "1";
                        break;
                    }
                }
                if (player.cardsValue > 21)
                {
                    Console.WriteLine("Dealer has:>" + dealer.cardsList[0].cardNumber[dealer.cardsList[0].number]);
                    Console.WriteLine("Player has:" + player.cardsValue);
                    Console.WriteLine("Your cards total over 21, you bust and lose " + betAmount + " :(");
                    money -= betAmount;
                    playing = false;
                    win = true;
                    break;
                }
            }
            else if (player.cardsValue == 21)
            {
                Console.WriteLine("Dealer has:>" + dealer.cardsList[0].cardNumber[dealer.cardsList[0].number]);
                Console.WriteLine("Player has:" + player.cardsValue);
                Console.WriteLine("Your cards total 21, you got blackjack and won " + betAmount * 1.5 + "!");
                money += betAmount;
                playing = false;
                win = true;
                break;
            }

            Console.WriteLine("Dealer has:>" + dealer.cardsList[0].cardNumber[dealer.cardsList[0].number]);
            Console.WriteLine("Player has:" + player.cardsValue);

            while (true)
            {
                Console.Write("Do you want to hit or stand? (h/s):");
                string? userInput2 = Console.ReadLine();
                if (userInput2 == null)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    int currentLineCursor = Console.CursorTop;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, currentLineCursor);
                    continue;
                }
                userInput2.ToLower();
                if (userInput2 == "s")
                {
                    playing = false;
                    break;
                }
                else if (userInput2 == "h")
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    int currentLineCursor = Console.CursorTop;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    continue;
                }
            }
        }
        while (win == false)
        {
            Console.WriteLine("\n====DEALER HAS====");
            Console.WriteLine(deckBuilder(dealer, false));
            Console.WriteLine("====PLAYER HAS====");
            Console.WriteLine(deckBuilder(player, false));
            if (dealer.cardsValue > 21)
            {
                foreach (var card in player.cardsList)
                {
                    if (card.number == "A")
                    {
                        dealer.cardsValue -= 10;
                        card.number = "1";
                        break;
                    }
                }
            }
            Console.WriteLine("Dealer has:" + dealer.cardsValue);
            Console.WriteLine("Player has:" + player.cardsValue);
            if (dealer.cardsValue > 21)
            {
                Console.WriteLine("Dealer Busts, you won " + betAmount * 2 + "!");
                money += betAmount;
                win = true;
            }
            else if (dealer.cardsValue == 21)
            {
                Console.WriteLine("Dealer got blackjack, you lost " + betAmount + " :(");
                money -= betAmount;
                win = true;
            }
            else if (dealer.cardsValue <= 16)
            {
                Console.Write("\r\nDealers cards less then 17.");
                Thread.Sleep(333);
                Console.Write("\rDealers cards less then 17..");
                Thread.Sleep(333);
                Console.Write("\rDealers cards less then 17...");
                Thread.Sleep(333);
                card dealersCard03 = new card(dealer);
                Console.Write("\nPress any key to reveal:\n");
                Console.ReadKey();
            }
            else
            {
                if (player.cardsValue > dealer.cardsValue)
                {
                    Console.WriteLine("Your cards are higher then the dealers, you win " + betAmount * 2 + "!");
                    money += betAmount;
                    win = true;
                }
                else if (player.cardsValue < dealer.cardsValue)
                {
                    Console.WriteLine("Your cards are lower then the dealers, you lose " + betAmount + " :(");
                    money -= betAmount;
                    win = true;
                }
                else if (player.cardsValue == dealer.cardsValue)
                {
                    Console.WriteLine("Your cards are equal to the dealers, it's a tie, you win " + betAmount);
                    win = true;
                }
            }
        }
        while (true)
        {
            Console.Write("\nWould you like to play again? (y/n):");
            string? userInput3 = Console.ReadLine();
            if (userInput3 == null)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
                continue;
            }
            userInput3.ToLower();
            if (userInput3 == "y")
            {
                break;
            }
            else if (userInput3 == "n")
            {
                Console.Clear();
                gambaling = false;
                break;
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.SetCursorPosition(0, currentLineCursor);
                continue;
            }
        }
    }
}
StringBuilder deckBuilder(Participant participant, bool hidden)
{
    StringBuilder stringBuilder = new StringBuilder();
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < participant.cardsList.Count; j++)
        {
            if (j == participant.cardsList.Count - 1)
            {
                if (hidden == true)
                {
                    stringBuilder.Append(participant.cardsList[j].asciiCardHidden[i]);
                }
                else
                {
                    stringBuilder.Append(participant.cardsList[j].asciiCard[i]);
                }
                stringBuilder.Append("\n");
            }
            else
            {
                stringBuilder.Append(participant.cardsList[j].asciiCard[i]);
            }
        }
    }
    return stringBuilder;
}

class card
{
    public string? number;
    public readonly string? suit;
    public readonly string[] asciiCard = { "┌───────────┐", "│#..........│", "│...........│", "│...........│", "│.....*.....│", "│...........│", "│...........│", "│..........#│", "└───────────┘" };
    public readonly string[] asciiCardHidden = { "┌───────────┐", "│:::::::::::│", "│:::::::::::│", "│:::::::::::│", "│:::::::::::│", "│:::::::::::│", "│:::::::::::│", "│:::::::::::│", "└───────────┘" };
    public Dictionary<string, int> cardNumber = new Dictionary<string, int>()
    {
        ["A"] = 11,
        ["2"] = 2,
        ["3"] = 3,
        ["4"] = 4,
        ["5"] = 5,
        ["6"] = 6,
        ["7"] = 7,
        ["8"] = 8,
        ["9"] = 9,
        ["10"] = 10,
        ["J"] = 10,
        ["Q"] = 10,
        ["K"] = 10,
        ["1"] = 1
    };
    private string[] cardSuit = { "♣", "♦", "♥", "♠" };
    public card(Participant participant)
    {
        Random rnd = new Random();
        number = cardNumber.ElementAt(rnd.Next(0, 12)).Key;
        if (number == "10")
        {
            asciiCard[1] = asciiCard[1].Remove(3, 1);
            asciiCard[7] = asciiCard[7].Remove(3, 1);
        }
        suit = cardSuit[rnd.Next(0, 3)];
        asciiCard[1] = asciiCard[1].Replace("#", number);
        asciiCard[7] = asciiCard[7].Replace("#", number);
        asciiCard[4] = asciiCard[4].Replace("*", suit);
        participant.AddCard(this);
    }
}

class Participant
{
    public int cardsValue = 0;
    public List<card> cardsList = new List<card>();

    public void AddCard(card card)
    {
        cardsList.Add(card);
        cardsValue += card.cardNumber[card.number];
    }
}