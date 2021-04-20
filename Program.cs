using System;
using System.Collections.Generic;
namespace BlackJackCS
{

    class Card
    {
        public string Suits { get; set; }
        public string Face { get; set; }
        public int Value()
        {
            if (Face == "Ace")
            {
                return 11;
            }
            else if (Face == "Jack")
            {
                return 10;
            }
            else if (Face == "Queen")
            {
                return 10;
            }
            else if (Face == "King")
            {
                return 10;
            }
            else
            {
                return int.Parse(Face);
            }

        }
        public string Description()
        {
            var newDescription = $"The {Face} of {Suits}";
            return newDescription;
        }

    }

    class Hand
    {
        public List<Card> IndividualCards { get; set; } = new List<Card>();

        public void Receive(Card newCard)
        {
            IndividualCards.Add(newCard);
        }

        public int TotalValue()
        {
            var total = 0;
            foreach (var card in IndividualCards)
            {
                total += card.Value();
            }
            return total;
        }

    }

    class Game
    {
        public void Play()
        {
            var cardSuits = new List<string>() { "Hearts", "Diamonds", "Spades", "Clubs" };
            var cardFaces = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            var deck = new List<Card>();

            for (var indexSuits = 0; indexSuits < cardSuits.Count; indexSuits++)
            {
                for (var indexFaces = 0; indexFaces < cardFaces.Count; indexFaces++)

                {
                    var mango = new Card()
                    {
                        Suits = cardSuits[indexSuits],
                        Face = cardFaces[indexFaces]

                    };
                    deck.Add(mango);
                }
            }
            var numberOfCards = deck.Count;

            for (var rightIndex = numberOfCards - 1; rightIndex >= 0; rightIndex--)
            {
                var leftIndex = new Random().Next(0, rightIndex);
                var rightCard = deck[rightIndex];
                deck[rightIndex] = deck[leftIndex];
                deck[leftIndex] = rightCard;
            }

            var playerHand = new Hand();
            var dealerHand = new Hand();

            var newCard = deck[0];
            deck.Remove(newCard);

            playerHand.Receive(newCard);

            newCard = deck[0];
            deck.Remove(newCard);

            playerHand.Receive(newCard);

            newCard = deck[0];
            deck.Remove(newCard);

            dealerHand.Receive(newCard);

            newCard = deck[0];
            deck.Remove(newCard);

            dealerHand.Receive(newCard);

            var keepAsking = true;
            while (keepAsking && playerHand.TotalValue() <= 21)
            {
                Console.WriteLine("Your cards are:");
                foreach (var card in playerHand.IndividualCards)
                {
                    Console.WriteLine(card.Description());
                }
                Console.Write("Your total hand value is: ");
                Console.WriteLine(playerHand.TotalValue());

                Console.Write("Do you want to Hit or Stand? ");
                var choice = Console.ReadLine().ToLower();

                if (choice == "hit")
                {
                    var hitCard = deck[0];
                    deck.Remove(hitCard);

                    playerHand.Receive(hitCard);
                }
                else
                {
                    keepAsking = false;
                }
            }

            Console.WriteLine("Your cards are: ");
            foreach (var card in playerHand.IndividualCards)
            {
                Console.WriteLine(card.Description());
            }
            Console.Write("Your total hand value is: ");
            Console.WriteLine(playerHand.TotalValue());

            while (dealerHand.TotalValue() < 17 && playerHand.TotalValue() <= 21)
            {
                var newDealerCard = deck[0];
                deck.Remove(newDealerCard);

                dealerHand.Receive(newDealerCard);
            }

            Console.WriteLine("The dealer's cards are:");
            foreach (var card in dealerHand.IndividualCards)
            {
                Console.WriteLine("The dealer's total hand value is: ");
            }
            Console.Write("The dealer's total hand value is: ");
            Console.WriteLine(dealerHand.TotalValue());

            if (playerHand.TotalValue() > 21)
            {
                Console.WriteLine("Dealer wins!");
            }
            else if (dealerHand.TotalValue() > 21)
            {
                Console.WriteLine("Player Wins!");
            }
            else if (dealerHand.TotalValue() > playerHand.TotalValue())
            {
                Console.WriteLine("Dealer Wins!");
            }
            else if (playerHand.TotalValue() > dealerHand.TotalValue())
            {
                Console.WriteLine("Player Wins");
            }
            else
            {
                Console.WriteLine("Tie! Dealer wins!");
            }

        }
    }

    class Program
    {
        static string DisplayGreeting()
        {
            Console.WriteLine("--------------------------------- ");
            Console.Write("Would you like to play blackjack? ");
            var answer = Console.ReadLine();
            return answer;
        }

        static void Main(string[] args)
        {
            DisplayGreeting();

            var playerWantsToKeepGoing = true;

            while (playerWantsToKeepGoing)
            {
                var theGame = new Game();
                theGame.Play();

                Console.Write("Want to Play Again? Y/N? ");
                var answer = Console.ReadLine().ToLower();
                playerWantsToKeepGoing = (answer == "Y");

            }

        }
    }
}
