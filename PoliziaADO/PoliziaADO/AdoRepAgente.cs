using PoliziaADO.Entities;
using PoliziaADO.Extensions;
using PoliziaADO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PoliziaADO
{

    //implementazione concreto dell'interfaccia IAgenteRepository per ADO
    public class AdoRepAgente : IAgenteRepository
    {
        // stringa di connessione per il database Polizia
        const string connectionString = @"Persist Security Info=False; Integrated Security=True; Initial Catalog= Polizia; Server=.\SQLEXPRESS";


        // Funzionalità in modalità connessa per leggere tutti gli agenti
        // return value: un IEnumerable contenente oggetti di tipo Agente
        public IEnumerable<Agente> GetAll()
        {

            List<Agente> agenti = new List<Agente>() { };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //Apertura connessione
                connection.Open();


                //Creazione comando 
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Agenti";

                //Esecuzione dei comandi: Lettore
                SqlDataReader reader = command.ExecuteReader();

                //Leggo con reader, converto in oggetti di tipo Agente e inserisco nella Lista di Agenti
                while (reader.Read())
                {

                    agenti.Add(reader.ToAgente());
                }

                //Chiusura reader e connessione
                reader.Close();
                connection.Close();

            }

            return agenti;

            }


        // Funzionalità in modalità connessa per leggere tutti gli agenti in una determinata area metropolitana
        // input value: codiceArea, codice dell'area metropolitana, tipo stringa
        // return value: un IEnumerable contenente oggetti di tipo Agente
        public IEnumerable<Agente> GetAgentiPerArea(string codiceArea)
        {

            List<Agente> agenti = new List<Agente>() { };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Apertura connessione
                connection.Open();

                //Creazione comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT DISTINCT * FROM Agenti INNER JOIN Assegnazioni ON Agenti.ID = Assegnazioni.AgenteID INNER JOIN AreeMetropolitane" +
                    " ON AreeMetropolitane.ID = Assegnazioni.AreaMetropolitanaID WHERE AreeMetropolitane.Codice =@Codice";
;

                //Aggiunta parametro codiceArea
                command.Parameters.AddWithValue("@Codice", codiceArea);

                //Esecuzione dei comandi: Lettore

                SqlDataReader reader = command.ExecuteReader();


                //Leggo con reader, converto in oggetti di tipo Agente e inserisco nella Lista di Agenti
                while (reader.Read())
                {

                    agenti.Add(reader.ToAgente());
                }

                //Chiusura reader e connessione
                reader.Close();
                connection.Close();

            }

            return agenti;

        }



        // Funzionalità in modalità connessa per leggere tutti gli agenti con anni di servizio maggiori o uguali rispetto ad un valore di input
        // input value: anni di servizio, tipo int
        // return value: un IEnumerable contenente oggetti di tipo Agente
        public IEnumerable<Agente> GetAgentiAnniServizioMaggiori(int anniServizio)
        {

            List<Agente> agenti = new List<Agente>() { };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Apertura connessione
                connection.Open();

                //Creazione comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT DISTINCT * FRom Agenti WHERE Agenti.AnniServizio >= @anniServizio";

                //Aggiunta parametro anniServizio
                command.Parameters.AddWithValue("@anniServizio", anniServizio);

                //Esecuzione dei comandi: Lettore
                SqlDataReader reader = command.ExecuteReader();


                //Leggo con reader, converto in oggetti di tipo Agente e inserisco nella Lista di Agenti
                while (reader.Read())
                {

                    agenti.Add(reader.ToAgente());
                }

                //Chiusura reader e connessione
                reader.Close();
                connection.Close();

            }

            return agenti;

        }

        // Funzionalità in modalità disconnessa per inserire un nuovo agente
        // input value: oggetto di tipo Agente
        public void Create(Agente obj)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //Adapter
                SqlDataAdapter adapter = new SqlDataAdapter();


                //Creazione i comandi da associare all'adapter

                //Creare un comando per selezionare tutti gli agenti

                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = connection;
                selectCommand.CommandType = System.Data.CommandType.Text;
                selectCommand.CommandText = "SELECT * FROM Agenti";


                //Creazione comando di INSERT
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText = "INSERT INTO Agenti VALUES(@Nome,@Cognome,@CodiceFiscale,@DataDiNascita, @AnniServizio)";


                ////Creazione parametri 

                insertCommand.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar, 255, "Nome");
                insertCommand.Parameters.Add("@Cognome", System.Data.SqlDbType.NVarChar, 255, "Cognome");
                insertCommand.Parameters.Add("@CodiceFiscale", System.Data.SqlDbType.NVarChar, 255, "CodiceFiscale");
                insertCommand.Parameters.Add("@DataDiNascita", System.Data.SqlDbType.DateTime,20, "DataDiNascita");
                insertCommand.Parameters.Add("@AnniServizio", System.Data.SqlDbType.Int, 20, "AnniServizio");




                // Associazione all'adapter dei comandi insert e select definiti 
                adapter.InsertCommand = insertCommand;
                adapter.SelectCommand = selectCommand;


                //Creazione DataSet locale
                DataSet dataSet = new DataSet();

                try
                {
                    //Apro connessione
                    connection.Open();
                    //Riempio dataset locale con table Agenti
                    adapter.Fill(dataSet, "Agenti");


                    //creo un nuovo agente nella table Agenti del dataSet locale
                    DataRow agente = dataSet.Tables["Agenti"].NewRow();
                    agente["Nome"] = obj.Nome;
                    agente["Cognome"] = obj.Cognome;
                    agente["CodiceFiscale"] = obj.CodiceFiscale;
                    agente["DataDiNascita"] = obj.DataDiNascita;
                    agente["AnniServizio"] = obj.AnniServizio;


                    dataSet.Tables["Agenti"].Rows.Add(agente);

                    //update sul database
                    adapter.Update(dataSet, "Agenti");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }





            }
        }


        // Funzionalità non implementata
        public Agente GetByID(int ID)
        {
            throw new NotImplementedException();
        }


        // Funzionalità non implementata
        public bool Update(Agente obj)
        {
            throw new NotImplementedException();
        }

        // Funzionalità non implementata
        public bool Delete(Agente obj)
        {
            throw new NotImplementedException();
        }
    }
}
