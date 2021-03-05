using PoliziaADO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliziaADO.Interfaces
{

    //Interfaccia per Agente
    public interface IAgenteRepository : IRepository<Agente>
    {

        // aggiungo metodi di lettura specifici per Agenti
        IEnumerable<Agente> GetAgentiPerArea(string codiceArea);
        IEnumerable<Agente> GetAgentiAnniServizioMaggiori(int anniServizio);

    }
 
}
