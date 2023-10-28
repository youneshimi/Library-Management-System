using System.Data.Entity;



    public class Emprunt
    {
        public int Id { get; set; }
        public int LivreId { get; set; }
        public int AbonneId { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
    }

