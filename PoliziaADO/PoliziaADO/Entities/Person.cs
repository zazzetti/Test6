using System;
using System.Collections.Generic;
using System.Text;

namespace PoliziaADO.Entities
{

    //Classe astratta Person
    public abstract class Person
    {

        //Proprietà
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public string CodiceFiscale { get; set; }

     
        //Metodi
        //override del metodo Equals, e degli operatori == e != per gli oggetti di tipo Person
        public override bool Equals(object obj)
        {
            return obj is Person p && CodiceFiscale == p.CodiceFiscale;
        }

        public static bool operator ==(Person left, Person right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }
    }
}
