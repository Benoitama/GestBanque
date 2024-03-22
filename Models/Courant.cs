namespace Models;


public class Courant
{
    public string Numero;
    private double _Solde;
    public double Solde { get => Solde; private set => Solde = value; }
    public double LigneDeCredit;
    public Personne Titulaire;


    public void Retrait(double Montant)
    {
        if(Montant < 0)
        {
            Console.WriteLine("Impossible de retirer un montant négatif");
            return;
        }
            
        if(Montant > Solde + LigneDeCredit)
        {
        Console.WriteLine("Vous n'avez pas suffisamment d'argent");
        return;
        }
            
        Solde  = Solde-Montant;
        Console.WriteLine("Voici votre argent");
            
    }

    public void Depot(double Montant)
    {
    if (Montant < 0)
    {
        Console.WriteLine("Impossible de déposer une valeur négative");
        return;
    }
        
        Solde += Montant;
        Console.WriteLine("L'argent à bien été ajouté à votre compte.");
                
    }
}

