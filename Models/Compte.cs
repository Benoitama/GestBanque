
using System.Runtime.CompilerServices;

namespace Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        public static double operator +(double montant, Compte compte)
        {
            return (montant < 0 ? 0 : montant) + (compte.Solde < 0 ? 0 : compte.Solde);
        }

        private Personne _titulaire;
        private string _numero;
        private double _solde;

    protected Compte(string numero,Personne titulaire)
        {
            _numero = numero;
            _titulaire = titulaire;
        }

    protected Compte(string numero, Personne titulaire,double solde) : this (numero, titulaire)
        {
            Solde = solde;

        }

        public string Numero
        {
            get
            {
                return _numero;
            }

            private set
            {
                _numero = value;
            }
        }

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }
        protected abstract double CalculInteret();
        


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

        public Personne Titulaire
        {
            get
            {
                return _titulaire;
            }

            private set
            {
                _titulaire = value;
            }
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Dépot d'un montant négatif impossible"); // => Erreur : Exception
                return;
            }

            Solde += montant;
        }

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0D);
        }

        protected void Retrait(double montant, double ligneDeCredit)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Retrait d'un montant négatif impossible"); // => Erreur : Exception
                return;
            }

            if (Solde - montant < -ligneDeCredit)
            {
                Console.WriteLine("Solde insuffisant"); // => Erreur : Exception
                return;
            }

            Solde -= montant;
        }
    }
}
