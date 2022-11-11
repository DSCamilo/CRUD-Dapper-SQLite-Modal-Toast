using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FrontedProjectManagement.Models
{
    public class Proyectos
    {

        public int Id_Proyecto { get; set; }

        [Required (ErrorMessage = "El nombre es obligatorio")]
        [StringLength(500, ErrorMessage = "El Nombre es muy largo (Max. 500 caracteres)")]
        public string Nombre_Proyecto { get; set; }
        
        [Required (ErrorMessage = "El valor es obligatorio")]
        [Range(1, float.MaxValue, ErrorMessage = "Ingrese un valor positivo valido")]
        public double Valor_Proyecto { get; set; }
        
        //Verificar si es con ID o con nombreproyecto
    // [Required (ErrorMessage = "El sector es obligatorio")]
      //  [StringLength(500, ErrorMessage = "la descripcion es muy larga (Max. 500 caracteres)")]

        [Required (ErrorMessage = "El valor es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Ingrese un sector valido")]
        
        public int Id_Sector { get; set; }

        public Proyectos()
        {
            Nombre_Proyecto = string.Empty;
            Valor_Proyecto = 0;
            Id_Sector = 0;
        }

        public Proyectos(int id_Proyecto, string nombre_proyecto, float valor_proyecto, int id_sector)
        {
            Id_Proyecto = id_Proyecto;
            Nombre_Proyecto = nombre_proyecto;
            Valor_Proyecto = valor_proyecto;
            Id_Sector = id_sector;            
        }
        
    }
}