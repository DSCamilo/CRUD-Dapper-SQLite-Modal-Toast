using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Management.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Project_Management.Repositories
{
    public class ProyectosRepository : IProyectosRepository
    {
        private readonly string _connectionString;

        public ProyectosRepository (IConfiguration configuration)
        {
                 _connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<Proyectos> Create (Proyectos proyectos)
        {
          var sqlQuery = "INSERT INTO TBL_PROYECTOS(Nombre_Proyecto, Valor_Proyecto, Id_Sector) VALUES (@Nombre_Proyecto, @Valor_Proyecto, @Id_Sector)";

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new 
                {
                    proyectos.Nombre_Proyecto,
                    proyectos.Valor_Proyecto,
                    proyectos.Id_Sector
                });

                return proyectos;
            }  
        }

        public async Task Delete(int id)
        {
            var sqlQuery = $"DELETE from TBL_PROYECTOS WHERE Id_Proyecto={id}";

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery);
            }
        }

         public async Task<IEnumerable<Proyectos>> Get()
        {
            var sqlQuery = "SELECT * FROM TBL_PROYECTOS";

            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryAsync<Proyectos>(sqlQuery);
            } 
        }

         public async Task<Proyectos> Get(int id)
        {
            var sqlQuery = "SELECT * FROM TBL_PROYECTOS WHERE Id_Proyecto=@ProyectoId";

            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Proyectos>(sqlQuery, new { ProyectoId = id });
            }
        }

        public async Task Update(Proyectos proyectos)
        {
            var sqlQuery = "UPDATE TBL_PROYECTOS SET Nombre_Proyecto=@Nombre_Proyecto, Valor_Proyecto=@Valor_Proyecto, Id_Sector=@Id_Sector WHERE Id_Proyecto=@Id_Proyecto";

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    proyectos.Id_Proyecto,
                    proyectos.Nombre_Proyecto,
                    proyectos.Valor_Proyecto,
                    proyectos.Id_Sector
                });
            }
        }


    }
}