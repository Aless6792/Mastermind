using System; 
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace MasterMind
{
    class Program
    {
    	[DllImport("msvcrt")]
    	static extern int _getche();
    	public static void Main(string[] args)
    	{ 
    		CaraValide(args);
    	}
        public static void CaraValide(string[] args)
        {
            StringBuilder chaine = new StringBuilder("[-][-][-][-][-]"); // créé une chaine StringBuilder pour configurer une chaîne de caractères
            Regex regex = new Regex("[brnvjog]"); // Crée un Regex pour vérifier si des lettres correspondent dans "[brnvjog]".
            Console.WriteLine("Saisir 5 couleurs : "); // Affiche un message à l'utilisateur.
            int p = 0; // creer une variable pour compter le nombre de lettres valides saisies par l'utilisateur.
            char lettre; // Déclare une variable pour stocker la lettre saisie par l'utilisateur.
        
           lettre = Console.ReadKey().KeyChar; // saisir par l'utilisateur
            if (regex.IsMatch(lettre.ToString())) // Vérifie si la lettre saisie correspond à l'une des lettres dans "[brnvjog].
            {
                int index = chaine.ToString().IndexOf('-'); // l'index recupere les '-' dans la chaine
                if (index != -1)
                {
                    chaine = chaine.Replace('-', lettre, index, 1); // Remplace le premier '-' 
                    p++;
                }
            }
            Console.Clear(); 
            foreach (char c in chaine.ToString()) // Parcourt chaque caractère de la chaîne.
            {
                if (regex.IsMatch(c.ToString())) // Vérifie si le caractère correspond à l'une des lettres dans "[brnvjog]".
                {
                    Console.ForegroundColor = GetConsoleColor(c); // Change la couleur de premier plan de la console.
                    Console.Write(c);
                    Console.ResetColor(); // restort de la couleur
                }
                else
                {
                    Console.Write(c);
                }
            }
            Console.WriteLine(); // Passe à la ligne suivante.
            while (p < 5)
            {
            	Console.Clear(); 
            	Joueur2(args, chaine.ToString().ToCharArray());
            }
        }
     public static void Joueur2(string[] args, char[] combinaison)
        {
            Console.WriteLine("2ème joueur :                Bien placé                     Mal placé");
            StringBuilder chaine2 = new StringBuilder("essaie : [-][-][-][-][-]        {X}                            {X}");
            Regex regex2 = new Regex("[brnvjog]");
            int p2 = 0;
            char lettre2;
            char[] combinaisonEssaie = new char[5];

            do
            {
                lettre2 = Console.ReadKey().KeyChar;

                if (regex2.IsMatch(lettre2.ToString()))
                {
                    int index2 = chaine2.ToString().IndexOf('-');
                    if (index2 != -1)
                    {
                        chaine2 = chaine2.Replace('-', lettre2, index2, 1);
                        combinaisonEssaie[p2] = lettre2;
                        p2++;
                    }
                }

                Console.Clear();
                foreach (char c in chaine2.ToString())
                {
                    if (regex2.IsMatch(c.ToString()))
                    {
                        Console.ForegroundColor = GetConsoleColor(c);
                        Console.Write(c);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }
                Console.WriteLine();
            } while (p2 < 5);

            Console.Clear();
            CalculBpMp(combinaison, combinaisonEssaie);
        }

      public static void CalculBpMp(char[] combinaison, char[] combinaisonEssaie)
{
    int bienPlaces = 0;
    int malPlaces = 0;
    int minLength = Math.Min(combinaison.Length, combinaisonEssaie.Length);

    for (int i = 0; i < minLength; i++)
    {
        if (combinaison[i] == combinaisonEssaie[i])
        {
            bienPlaces++;
        }
        else if (Array.IndexOf(combinaison, combinaisonEssaie[i]) != -1)
        {
            malPlaces++;
        }
    }

    Console.WriteLine("2ème joueur :" + "Bien placé : " + bienPlaces + "        Mal placé : " + malPlaces);
    Console.ReadLine();
}


        private static ConsoleColor GetConsoleColor(char lettre)
        {
            switch (lettre)
            {
                case 'b': return ConsoleColor.Blue;
                case 'r': return ConsoleColor.DarkRed;
                case 'n': return ConsoleColor.White;
                case 'v': return ConsoleColor.Green;
                case 'j': return ConsoleColor.Yellow;
                case 'o': return ConsoleColor.DarkYellow;
                case 'g': return ConsoleColor.DarkGray;
                default: return ConsoleColor.Black;
            }
        }
    }
}