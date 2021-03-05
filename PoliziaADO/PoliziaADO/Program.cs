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
                Console.WriteLine("Cosa vuoi fare?\n Premi C per creare un nuovo agente,\n R per leggere tutti gli agenti, \n R_AR per leggere gli agenti in una determinata area metropolitana,\n R_AN per leggere gli agenti con numero anni di servizio maggiori o uguali a input, \n ESC per uscire");
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
