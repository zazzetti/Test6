using PoliziaADO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoliziaADO
{

    //Classe statica per gestire l'interazione con l'utente
    static class InterazioneUtente
    {

        //metodi che prendono in input un oggetto di tipo AgenteService (da cui accedo a repository e relativi metodi)


        static public void CreateAgente(AgenteService agServ)
        {
            Console.WriteLine("Creazione Agente");
            Agente agente = new Agente();

            Console.WriteLine("Inserisci Nome");
            string nome = Console.ReadLine();
            agente.Nome = nome;
            Console.WriteLine("Inserisci Cognome");
            string cognome = Console.ReadLine();
            agente.Cognome = cognome;

            Console.WriteLine("Inserisci CodiceFiscale");
            string codiceFiscale = Console.ReadLine();
            agente.CodiceFiscale = codiceFiscale;

            Console.WriteLine("Inserisci Data di Nascita");

            bool flagData= DateTime.TryParse(Console.ReadLine(), out DateTime dataDiNascita);

            while (flagData != true)
            {
                Console.WriteLine("Non valido, Inserisci nuovamente Data di Nascita");

                flagData = DateTime.TryParse(Console.ReadLine(), out dataDiNascita);
            }
            agente.DataDiNascita = dataDiNascita;

            Console.WriteLine("Inserisci Anni di Servizio");

            bool flagAnni = int.TryParse(Console.ReadLine(), out int anniServizio);

            while (flagAnni != true)
            {
                Console.WriteLine("Non valido, Inserisci nuovamente Anni di Servizio");

                flagAnni = int.TryParse(Console.ReadLine(), out anniServizio);
            }
            agente.AnniServizio = anniServizio;

            agServ.CreateAgente(agente);


        }
    
    
    
        static public void GetAllAgenti(AgenteService agServ)
        {
            IEnumerable<Agente> agenti = agServ.GetAllAgenti();
            foreach (var a in agenti)
            {
                Console.WriteLine(a.ToString());
            }
            if (agenti.Count() == 0) Console.WriteLine("Non ci sono agenti");

        }


        static public void GetAgentiPerArea(AgenteService agServ)
        {
            Console.WriteLine("Inserisci Codice Area di Servizio");
            string codiceareaServizio = Console.ReadLine();


            IEnumerable<Agente> agenti = agServ.GetAgentiPerArea(codiceareaServizio);
            foreach (var a in agenti)
            {
                Console.WriteLine(a.ToString());
            }

            if (agenti.Count() == 0) Console.WriteLine("Non ci sono agenti in quest'area di servizio");
        }


        static public void GetAgentiAnniServizioMaggiori(AgenteService agServ)
        {
            Console.WriteLine("Inserisci Anni di Servizio");

            bool flagAnni = int.TryParse(Console.ReadLine(), out int anniServizio);

            while (flagAnni != true)
            {
                Console.WriteLine("Non valido, Inserisci nuovamente Anni di Servizio");

                flagAnni = int.TryParse(Console.ReadLine(), out anniServizio);
            }

            IEnumerable<Agente> agenti = agServ.GetAgentiAnniServizioMaggiori(anniServizio);
            foreach (var a in agenti)
            {
                Console.WriteLine(a.ToString());
            }
            if (agenti.Count() == 0) Console.WriteLine("Non ci sono agenti con più di "+ anniServizio.ToString()+ " di servizio");
        }




    }
}
