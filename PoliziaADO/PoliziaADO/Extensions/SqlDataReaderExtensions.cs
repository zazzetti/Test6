using PoliziaADO.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PoliziaADO.Extensions
{

    // Classe statica per raccolta Extension Methods
    //(in questo caso solo per Agente)
    public static class SqlDataReaderExtensions
    {

        // Extension Method per estendere funzionalità SqlDataReader: conversione reader -> Agente
        public static Agente ToAgente(this SqlDataReader reader)
        {
            return new Agente()
            {
                
               
                Nome= reader["Nome"].ToString(),
                Cognome = reader["Cognome"].ToString(),
                CodiceFiscale = reader["CodiceFiscale"].ToString(),
                DataDiNascita =(DateTime) reader["DataDiNascita"],
                AnniServizio = (int)reader["AnniServizio"]

            };
        }
    }
}
