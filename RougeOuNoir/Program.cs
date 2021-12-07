using System;

namespace RougeOuNoir
{
    class Program
    {
        public struct JeuxDeCarte{
            public char cardValue;
            public string cardName;
        }   
        public static Random rand = new Random();

        /// <summary>
        /// Mélange un tableau d'entiers selon le Knuth's shuffle
        /// </summary>
        /// <param name="nombres">Un tableau de nombres entiers</param>
        public static void Melanger(JeuxDeCarte[] storageCard)
        {
            for (int i = storageCard.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                JeuxDeCarte temporaire = storageCard[i];
                storageCard[i] = storageCard[j];
                storageCard[j] = temporaire;
            }
        }
        public static void JeuxRougeOuNoir()
        {

        }
        /// <summary>
        /// Permet de jouer au Rouge ou Noir contre l'ordinateur
        /// </summary>
        /// <param name="args">Argument d'exécution. Ils sont ignorés.</param>
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            int countPoint = 0;
            int countCroupier = 0;
            JeuxDeCarte[] storageCard = new JeuxDeCarte[52];
            string[] cardName = new[] { "As","2","3","4","5","6","7","8","9","10","Valet","Dame","Roi" };
            char[] zeleOfTheColor = new[] { '♥', '♦', '♣', '♠' };
            // Initialiser un tableau avec les nombres de 1 à 200
            int[] nombres = new int[52];
            int count = 0;
            for (int i = 0; i < zeleOfTheColor.Length; i++)
            {
                for (int j = 0; j < cardName.Length; j++)
                {
                    storageCard[count].cardName = cardName[j];
                    storageCard[count].cardValue = zeleOfTheColor[i];
                    count++;
                }  
            }
            // Mélanger le tableau
            Melanger(storageCard);
            Console.WriteLine();
            int oneTap = 1;
            int nbCarteRestant = 53;
            Console.WriteLine("********** BIENVENUE AU JEU ROUGE OU NOIR **********");
            for (int i = 0; i < 52; i++)
            {
                nbCarteRestant--;
                Console.Write($"[Il reste ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(nbCarteRestant);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" carte(s)]");
                Console.WriteLine();
                string redOrBlack;
                
                do
                {
                    Console.WriteLine("(R)ouges ou (N)oir ?");
                    redOrBlack = Console.ReadLine();
                    redOrBlack = redOrBlack.Trim();
                    redOrBlack = redOrBlack.ToUpper();
                } while (!(redOrBlack == "R" || redOrBlack == "N" || redOrBlack == "PATATE"));
                if(redOrBlack == "R")
                {
                    if (storageCard[i].cardValue == '♥' || storageCard[i].cardValue == '♦')
                        countPoint++;
                    else
                        countCroupier++;
                }
                else
                {
                    if (storageCard[i].cardValue == '♣' || storageCard[i].cardValue == '♠')
                        countPoint++;
                    else
                        countCroupier++;
                }
                //Cheat code utilisable uniquement sur premiere carte
                if (redOrBlack == "PATATE" && oneTap == 1)
                {
                    countPoint = 53;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ł€ĐǤƗŦ ŞØỮŘĆ€ ŞỮŘ");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                oneTap = 0;
                Console.Write("La carte etait : ");
                if(storageCard[i].cardValue == '♥' || storageCard[i].cardValue == '♦')
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(storageCard[i].cardValue);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(storageCard[i].cardName);
                Console.WriteLine();
                Console.WriteLine($"Pointage : {countCroupier} - {countPoint}");
            }
            string winOrLose;
            if (countCroupier > countPoint)
                winOrLose = "Vous avez perdu !";
            else
                winOrLose = "Vous avez gagne !";
            Console.WriteLine($"***************** {winOrLose} *******************");
        }
    }
}
