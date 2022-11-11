using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Management.Models;

namespace Project_Management.Repositories
{
    public interface IProyectosRepository
    {
        Task<IEnumerable<Proyectos>> Get();
        Task<Proyectos> Get(int id);
        Task<Proyectos> Create(Proyectos proyectos);
        Task Update(Proyectos proyectos);
        Task Delete(int id);
    }
}