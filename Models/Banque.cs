using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Banque
    {
        private string _nom;
        private Dictionary<string, Compte> _compte = new Dictionary<string, Compte>();

        public Banque(string nom)
        {
            this._nom = nom;
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            init
            {
                _nom = value;
            }
        }

        public Compte? this[string Key] {
            get
            {
                if (!_compte.ContainsKey(Key))
                {
                    return null;
                }

                return _compte[Key];
            }

        }

        public void Ajouter(Compte compte)
        {
            _compte.Add(compte.Numero, compte);
            compte.PassageEnNegatifEvent += PassageEnNegatifAction;
        }

        private void PassageEnNegatifAction(Compte compte)
        {
            Console.WriteLine($" Le compte {compte.Numero} vient de passer en négatif");
        }

        public void Supprimer(string Numero)
        {
            if (!_compte.ContainsKey(Numero))
            {
                return;
            }
            Compte compte = this[Numero]!;
            _compte[Numero].PassageEnNegatifEvent -= PassageEnNegatifAction;
            _compte.Remove(Numero);
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            double total = 0;
            //foreach (KeyValuePair<string, Courant> compte in _compte) {

            //    if(compte.Value.Titulaire == titulaire)
            //    {
            //        total += compte.Value;

            //    }
            //OU
                foreach (Compte courant in _compte.Values)
                {
                    if(courant.Titulaire == titulaire)
                    {
                        total += courant;
                    }
                

            }
            return total;
        }
    }
}
