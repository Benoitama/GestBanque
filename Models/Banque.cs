namespace Models
{
    public class Banque
    {
        private string _nom;
        private Dictionary<string, Courant> _compte = new Dictionary<string, Courant>();


        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public Courant? this[string Key] {
            get
            {
                if (!_compte.ContainsKey(Key))
                {
                    return null;
                }

                return _compte[Key];
            }

        }

        public void Ajouter(Courant compte)
        {
            _compte.Add(compte.Numero, compte);
        }

        public void Supprimer(string Numero)
        {
            if (!_compte.ContainsKey(Numero))
            {
                return;
            }
            _compte.Remove(Numero);
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            double total = 0;
            foreach (KeyValuePair<string, Courant> compte in _compte) {

                if(compte.Value.Titulaire == titulaire)
                {
                    total += compte.Value;

                }
                /* OU
                foreach (Courant courant in _compte.Values)
                {
                    if(courant.Titulaire == titulaire)
                    {
                        total += courant;
                    }
                }*/

            }
            return total;
        }
    }
}
