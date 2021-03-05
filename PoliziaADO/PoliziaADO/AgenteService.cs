using PoliziaADO.Entities;
using PoliziaADO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliziaADO
{

    // classe AgenteService per gestire eventuali logiche di business
    // (in questo caso richiamo semplicemente i metodi della repository)
    public class AgenteService
    {
        // campo privato di tipo IAgenteRepository
        private IAgenteRepository _repo;


        //creo istanza del repository
        public AgenteService(IAgenteRepository repo)
        {
            _repo = repo;

        }



        public void CreateAgente(Agente agente)
        {

            _repo.Create(agente);


        }
        public IEnumerable<Agente> GetAllAgenti()
        {

            return _repo.GetAll();
        }

        public IEnumerable<Agente> GetAgentiPerArea(string codiceArea)
        {

            return _repo.GetAgentiPerArea(codiceArea);
        }
        public IEnumerable<Agente> GetAgentiAnniServizioMaggiori(int anniServizio)
        {

            return _repo.GetAgentiAnniServizioMaggiori(anniServizio);
        }

        public bool DeleteAgente(Agente agente)
        {
            return _repo.Delete(agente);

        }

        public Agente GetbyId(int id)
        {
            return _repo.GetByID(id);
        }
        public bool UpdateAgente(Agente agente)
        {


            return _repo.Update(agente);

        }


      
    }
}
