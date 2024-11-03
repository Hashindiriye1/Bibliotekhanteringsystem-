namespace BibliotekHanteringAvancerad
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bibliotek nybibliotek = new Bibliotek();

            bool kör = false;

            while (kör == false)
            {
                
                Console.WriteLine("Biblioteket - Välj ett alternativ:");
                Console.WriteLine("1. Lägg till ny bok");
                Console.WriteLine("2. Lägg till ny författare");
                Console.WriteLine("3. Uppdatera bokdetaljer");
                Console.WriteLine("4. Uppdatera författardetaljer");
                Console.WriteLine("5. Ta bort bok");
                Console.WriteLine("6. Ta bort författare");
                Console.WriteLine("7. Lista alla böcker och författare");
                Console.WriteLine("8. Sök och filtrera böcker");
                Console.WriteLine("9. Avsluta och spara data");

                int svar = Convert.ToInt32(Console.ReadLine());

                if (svar == 1)
                {
                    Console.Clear();
                    nybibliotek.LäggTillBok();
                }
                else if (svar == 2)
                {
                    Console.Clear();
                    nybibliotek.LäggTillFörfattare();
                }
                else if (svar == 3)
                {
                    Console.Clear();
                    nybibliotek.UppdateraBok();
                }
                else if (svar == 4)
                {
                    Console.Clear();
                    nybibliotek.UppdateraFörfattare();

                }
                else if (svar == 5)
                {
                    Console.Clear();
                    nybibliotek.TaBortBok();
                }
                else if (svar == 6)
                {
                    Console.Clear();
                    nybibliotek.TaBortFörfattare();

                }
                else if (svar == 7)
                {
                    Console.Clear();
                    nybibliotek.ListaBöcker();
                    nybibliotek.ListaFörfattare();
                }
                else if (svar == 8)
                {

                }
                else
                {
                    Console.Clear();
                    nybibliotek.SparaData();
                    Console.WriteLine("Tack och välkommen åter");

                    kör = true;
                }  
                
            }

        }

    }
}
