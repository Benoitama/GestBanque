using Models;

namespace GestBanque;
class Program
{
    static void Main(string[] args)
    {
        Personne doeJohn = new Personne()
        {
            Nom = "Doe",
            Prenom = "John",
            DateNaiss = new DateTime(1970, 1, 1)
        };

        Courant courant = new Courant()
        {
            Numero = "0001",
            LigneDeCredit = 500,
            Titulaire = doeJohn
        };

        courant.Depot(-100);
        courant.Depot(100);
        courant.Depot(-100);
        courant.Depot(100);
        courant.Depot(600);

    }
}