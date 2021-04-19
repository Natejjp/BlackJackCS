using System;
using System.Collections.Generic;
namespace Test
{

    class Card
    {
        public string Suits;
        public string Face;
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

        static List<Card> MakeDeck()
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
            return deck;

        }

        static void Shuffle(List<Card> deck)
        {
            var numberOfCards = deck.Count;

            for (var rightIndex = numberOfCards - 1; rightIndex >= 0; rightIndex--)
            {
                var leftIndex = new Random().Next(0, rightIndex);
                var rightCard = deck[rightIndex];
                deck[rightIndex] = deck[leftIndex];
                deck[leftIndex] = rightCard;

            }
        }


        // *Does not work
        // static void deal()
        // {
        //     var playerHand = new List<int>();
        //     playerHand.Add($"{deck[0]}");
        //     playerHand.Add($"{deck[1]}");

        //     var dealerHand = new List<int>();
        //     dealerHand.Add($"{deck[10]}");
        //     dealerHand.Add($"{deck[11]}");

        //     Console.WriteLine($"You have the {deck[0]} and the {deck[1]}");
        //     Console.Write("Would you like to hit or stand? ");
        //     var play = Console.ReadLine();

        //     if (play == "hit")
        //     {
        //         playerHand.Add($"{deck[2]}");
        //         Console.WriteLine($"You now have {deck[0]}, {deck[1]}, and {deck[2]}");
        //         Console.WriteLine($"Your total is {playerHandTotal}");

        //         if (playerHandTotal > 21)
        //         {
        //              Console.Write("You Busted! Play Again? ");
        //              var playAgain = Console.ReadLine();
        //                  if (playAgain == "yes")
        //                  {
        //                      MakeDeck();
        //                      Shuffle(deck);
        //                      DisplayGreeting();
        //                      Deal() 
        //                  } 
        //         }

        //     } else
        //     {
        //         Console.WriteLine($"Dealer has {deck[10]} and {deck[11]}");
        //         Console.WriteLine($"Dealer total is {dealerHandTotal}");
        //         if (dealerHandTotal < 17)
        //         {
        //              dealerHand.Add($"{deck[12]}")
        //              if (dealerHandTotal > 21)
        //              {
        //                  Console.WriteLine("Dealer Busted! Winner winner chicken dinner!");
        //                  Console.Write("Play Again? ");
        //                  var playAgain = Console.ReadLine();
        //                      if (playAgain == "yes")
        //                      {
        //                          MakeDeck();
        //                          Shuffle(deck);
        //                          DisplayGreeting();
        //                          Deal(); 
        //                      } 
        //              }
        //         } else 
        //         {
        //              if (playerHandTotal > dealerHandTotal)
        //              {
        //                  Console.WriteLine("Winner winner chicken dinner!);
        //                  Console.Write("Play Again? ");
        //                  var playAgain = ConsoleReadLine();
        //                      if (playAgain == "yes")
        //                      {
        //                          MakeDeck();
        //                          Shuffle(deck);
        //                          DisplayGreeting();
        //                          Deal(); 
        //                      }
        //              } else 
        //                {
        //                  Console.Write("You Busted! Play again? ");
        //                  var playAgain = Console.ReadLine();
        //                      if (playAgain == "yes")
        //                      {
        //                          MakeDeck();
        //                          Shuffle(deck);
        //                          DisplayGreeting();
        //                          Deal(); 
        //                      } 
        //                }
        //         }
        //     }
        // }


        static void Main(string[] args)
        {
            var deck = new List<Card>();
            MakeDeck();
            Shuffle(deck);
            DisplayGreeting();
            //  Deal();

        }
    }
}