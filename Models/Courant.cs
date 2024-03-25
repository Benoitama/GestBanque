using System.Security.Cryptography;

namespace Models;


public class Courant
{
    private string _numero;
    private double _solde;
    private double _ligneDeCredit;
    private Personne _titulaire;
    


    public static double operator +(double amount, Courant s2)  //surcharge d'operateur
    {

        return (amount < 0 ? 0 : amount) + (s2.Solde < 0 ? 0 : s2.Solde);
    }

    public string Numero
    {
        get
        {
            return _numero;
        }

        set
        {
            _numero = value;
        }
    }

    public double Solde
    {
        get
        {
            return _solde;
        }

        private set
        {
            _solde = value;
        }
    }

    public double LigneDeCredit
    {
        get
        {
            return _ligneDeCredit;
        }

        set
        {
            if(value < 0)
            {
                Console.WriteLine("La valeur doit être strictement positive");
                return;
            }
            _ligneDeCredit = value;
        }
    }

    public Personne Titulaire
    {
        get
        {
            return _titulaire;
        }

        set
        {
            _titulaire = value;
        }
    }

    public void Retrait(double Montant)
    {
        if(Montant <= 0)
        {
            Console.WriteLine("Impossible de retirer un montant négatif");
            return;
        }
            
        if(Solde - Montant < -LigneDeCredit)
        {
        Console.WriteLine("Vous n'avez pas suffisamment d'argent");
        return;
        }
            
        Solde -= Montant;
        Console.WriteLine("Voici votre argent");
            
    }

    public void Depot(double Montant)
    {
    if (Montant <= 0)
    {
        Console.WriteLine("Impossible de déposer une valeur négative");
        return;
    }
        
        Solde += Montant;
        Console.WriteLine("L'argent à bien été ajouté à votre compte.");
                
    }
}

