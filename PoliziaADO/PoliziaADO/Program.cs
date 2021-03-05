using System;

namespace PoliziaADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto");

            //creao un oggetto di tipo AgenteService con una repository di tipo AdoRepAgente
            var agenteService = new AgenteService(new AdoRepAgente());
            // poi passo oggetto agenteService ai metodi della classe statica InterazioneUtente

            string s_input;
            do
            {
                Console.WriteLine("Cosa vuoi fare? Premi C per creare un nuovo agente, R per leggere tutti gli agenti, R_AR per leggere tutti gli agenti in una specifica area, R_AN per leggere tutti gli agenti con più di un tot di anni di servizio, ESC per uscire");
                s_input = Console.ReadLine();

                switch (s_input)
                {
                    case "C":
                        InterazioneUtente.CreateAgente(agenteService);
                        break;
                    case "R":
                        InterazioneUtente.GetAllAgenti(agenteService);
                        break;
                    case "R_AR":
                        InterazioneUtente.GetAgentiPerArea(agenteService);
                        break;
                    case "R_AN":
                        InterazioneUtente.GetAgentiAnniServizioMaggiori(agenteService);
                        break;
                    default:
                        break;
                }

            } while (s_input != "ESC");
        }
    }
}
