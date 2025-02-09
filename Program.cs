using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Bienvenue dans le chiffrement et déchiffrement du chiffrement de César");

        while (true)
        {
            AfficherMenuPrincipal();

            // Lecture du choix de l'utilisateur
            int choix = LireChoixUtilisateur(1, 3);

            switch (choix)
            {
                case 1:
                    CrypterMessage();
                    break;
                case 2:
                    DecrypterMessage();
                    break;
                case 3:
                    DecryptageForceBrute();
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez entrer un choix valide.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static void AfficherMenuPrincipal()
    {
        Console.WriteLine("Menu principal :");
        Console.WriteLine("1- Crypter un message");
        Console.WriteLine("2- Décrypter un message");
        Console.WriteLine("3- Décryptage en force brute");
        Console.WriteLine("Merci de rentrer votre choix [1, 2, 3] : ");
    }

    public static int LireChoixUtilisateur(int min, int max)
    {
        int choix;
        while (!int.TryParse(Console.ReadLine(), out choix) || choix < min || choix > max)
        {
            Console.WriteLine("Choix invalide. Entrez un choix entre " + min + " et " + max + " : ");
        }
        return choix;
    }

    public static void CrypterMessage()
    {
        Console.WriteLine("Cryptage d'un message :");
        Console.WriteLine("Base de la ROT :");
        Console.WriteLine("1. ROT3");
        Console.WriteLine("2. ROT autre");

        int choixRot = LireChoixUtilisateur(1, 2);
        int rot = (choixRot == 1) ? 3 : DemanderROT();

        Console.Write("Entrez votre message en clair : ");
        string message = Console.ReadLine();

        string messageCrypte = ChiffrerCesar(message, rot);
        Console.WriteLine("Message crypté : " + messageCrypte);
    }

    public static void DecrypterMessage()
    {
        Console.WriteLine("Décryptage d'un message :");
        Console.WriteLine("Base de la ROT :");
        Console.WriteLine("1. ROT3");
        Console.WriteLine("2. ROT autre");

        int choixRot = LireChoixUtilisateur(1, 2);
        int rot = (choixRot == 1) ? 3 : DemanderROT();

        Console.Write("Entrez votre message crypté : ");
        string messageCrypte = Console.ReadLine();

        string messageDechiffre = DechiffrerCesar(messageCrypte, rot);
        Console.WriteLine("Message décrypté : " + messageDechiffre);
    }

    public static void DecryptageForceBrute()
    {
        Console.WriteLine("Décryptage en force brute :");
        Console.Write("Entrez votre message crypté : ");
        string messageCrypte = Console.ReadLine();

        Console.WriteLine("Décryptage en cours...");
        Console.WriteLine("Résultats possibles :");
        ForceBrute(messageCrypte);
    }

    public static int DemanderROT()
    {
        Console.Write("Entrez votre choix de ROT (1 à 26) : ");
        int rot;
        while (!int.TryParse(Console.ReadLine(), out rot) || rot < 1 || rot > 26)
        {
            Console.WriteLine("Veuillez entrer un nombre entre 1 et 26 : ");
        }
        return rot;
    }

    public static string ChiffrerCesar(string message, int decalage)
    {
        string messageCrypte = "";

        foreach (char lettre in message)
        {
            if (char.IsLetter(lettre))
            {
                int decalageAlphabet = char.IsUpper(lettre) ? 'A' : 'a';
                char lettreCryptee = (char)((((lettre + decalage) - decalageAlphabet) % 26) + decalageAlphabet);
                messageCrypte += lettreCryptee;
            }
            else
            {
                messageCrypte += lettre;
            }
        }

        return messageCrypte;
    }

    public static string DechiffrerCesar(string messageCrypte, int decalage)
    {
        return ChiffrerCesar(messageCrypte, 26 - decalage); // Utilise la fonction de chiffrement avec un décalage inversé pour déchiffrer
    }

    public static void ForceBrute(string messageCrypte)
    {
        for (int i = 1; i <= 26; i++)
        {
            Console.WriteLine("ROT" + i + ": " + DechiffrerCesar(messageCrypte, i));
        }
    }
}
