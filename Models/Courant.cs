﻿namespace Models;

public class Courant : Compte
{
    private double _ligneDeCredit;

    public double LigneDeCredit
    {
        get
        {
            return _ligneDeCredit;
        }

        set
        {
            if (value < 0)
            {
                Console.WriteLine("La ligne de crédit est strictement positive..."); // => Erreur : Exception
                return;
            }
            _ligneDeCredit = value;
        }
    }

    public Courant(string numero, Personne titulaire):base(numero, titulaire)
    {

    }

    public Courant(string numero, Personne titulaire, double solde) : base(numero, titulaire,solde)
    {

    }
    public Courant(string numero, double ligne,Personne titulaire) : base(numero, titulaire)
    {
        LigneDeCredit = ligne;
    }
    protected override double CalculInteret()
    {
        if (Solde > 0)
        {
            return Solde * 3 / 100;
        }
        else
        {
            return Solde * 9.75 / 100;
        }
         
    }
    public override void Retrait(double montant)
    {
        Retrait(montant, LigneDeCredit);

        if (Solde - montant < 0)
        {
            PassageEnNegatif();
        }
    }
}