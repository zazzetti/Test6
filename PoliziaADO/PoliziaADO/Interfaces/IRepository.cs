using System;
using System.Collections.Generic;
using System.Text;

namespace PoliziaADO.Interfaces
{

    // Interfaccia IRepository
    // da utilizzare per definire IAgenteRepository inq uesto caso, e per una futura estensione anche per IAreaMetropolitanaRepository ecc
    public interface IRepository<T>
    {

        // Definisco i metodi CRUD : Create Read Update Delete



        //CREATE

        void Create(T obj);


        //READ

        T GetByID(int ID);

        IEnumerable<T> GetAll();


        //UPDATE
        bool Update(T obj);
        

        // DELETE
        bool Delete(T obj);



    }
}

