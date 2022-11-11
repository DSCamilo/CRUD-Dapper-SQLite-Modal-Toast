using FrontedProjectManagement.Models;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


namespace FrontedProjectManagement.Services
{
    public class ProyectosService : IProyectosService
    {
        private readonly HttpClient httpClient;

        public ProyectosService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
            ServicePointManager.ServerCertificateValidationCallback =  delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
            { return true; };      
        }
        async Task<List<Proyectos>> IProyectosService.GetProyectos()
        {
            return await httpClient.GetFromJsonAsync<List<Proyectos>>("api/Proyectos");
        }
    
           async Task<Proyectos> IProyectosService.GetProyectos(int id)
        {
            return await httpClient.GetFromJsonAsync<Proyectos>($"api/Proyectos/{id}");
        }

          async Task<Proyectos> IProyectosService.CreateProyectos(Proyectos proyectos)
        {
            var result = await httpClient.PostAsJsonAsync<Proyectos>($"api/Proyectos", proyectos);
            var newProyecto = await result.Content.ReadFromJsonAsync<Proyectos>();
            return newProyecto;
        }

        async Task IProyectosService.UpdateProyectos(int id, Proyectos proyectos)
        {
            await httpClient.PutAsJsonAsync<Proyectos>($"api/Proyectos?id={id}", proyectos);
        }

        public async Task DeleteProyectos(int id)
        {
            await httpClient.DeleteAsync($"api/Proyectos/{id}");
        }

            

    }
    
}
