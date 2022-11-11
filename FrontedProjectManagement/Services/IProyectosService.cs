
using FrontedProjectManagement.Models;

namespace FrontedProjectManagement.Services
{
    public interface IProyectosService
    {
        public Task<List<Proyectos>> GetProyectos();
        public Task<Proyectos>GetProyectos(int id);
        public Task <Proyectos> CreateProyectos(Proyectos proyectos);
        public Task UpdateProyectos(int id, Proyectos proyectos);
        public Task DeleteProyectos(int id);
    }
}