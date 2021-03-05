using System;
using System.Collections.Generic;
using System.Text;

namespace PoliziaADO.Entities
{

    // classe Agente che eredita da classe astratta Person
    public class Agente : Person
    {
       
        // Proprietà
        public int AnniServizio { get; set; }
        public DateTime DataDiNascita { get; set; }


        //Metodo
        //override del metodo ToString per gli oggetti di tipo Agente
        public override string ToString()
        {
            return CodiceFiscale + " - " + Nome + " - " + Cognome + " - " + AnniServizio.ToString() + " anni di servizio";
        }
    }

}
