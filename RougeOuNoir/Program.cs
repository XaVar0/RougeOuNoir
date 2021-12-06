using System;

namespace RougeOuNoir
{
    class Program
    {
        public static Random rand = new Random();

        /// <summary>
        /// Mélange un tableau d'entiers selon le Knuth's shuffle
        /// </summary>
        /// <param name="nombres">Un tableau de nombres entiers</param>
        public static void Melanger(int[] nombres)
        {
            for (int i = nombres.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                int temporaire = nombres[i];
                nombres[i] = nombres[j];
                nombres[j] = temporaire;
            }
        }

        /// <summary>
        /// Permet de jouer au Rouge ou Noir contre l'ordinateur
        /// </summary>
        /// <param name="args">Argument d'exécution. Ils sont ignorés.</param>
        static void Main(string[] args)
        {
            // Initialiser un tableau avec les nombres de 1 à 200
            int[] nombres = new int[200];
            for (int i = 0; i < nombres.Length; i ++)
                nombres[i] = i + 1;

            // Imprimer le contenu du tableau, avant le mélange
            Console.WriteLine("Avant le mélange :");
            for (int i = 0; i < nombres.Length; i++)
                Console.Write($"{nombres[i]}, ");

            // Mélanger le tableau
            Melanger(nombres);

            // Imprimer le contenu du tableau, après le mélange
            Console.WriteLine("\n\nAprès le mélange :");
            for (int i = 0; i < nombres.Length; i++)
                Console.Write($"{nombres[i]}, ");

            Console.WriteLine();
        }
    }
}
