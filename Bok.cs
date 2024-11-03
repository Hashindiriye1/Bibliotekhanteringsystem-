namespace BibliotekHanteringAvancerad
{
    public class Bok
    {
        
        public string Titel { get; set; }
        public Författare Författare { get; set; }
        public string Genre { get; set; }
        public int Publiceringsår { get; set; }
        public int ISBN { get; set; }
        //public List<Recension> Recensioner { get; set; }

        public Bok()
        {
            //Recensioner = new List<Recension>();
        }
    }
}

