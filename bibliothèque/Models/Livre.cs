using System.Data.Entity;


    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Resume { get; set; }
        public bool EstEmprunte { get; set; }
    }

