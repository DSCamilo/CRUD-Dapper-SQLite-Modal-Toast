using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project_Management.Models
{
    public class Municipios
    {
      
        
        public int Id_Municipio {get; set;}
        public string Nombre_Municipio {get; set;}
        public int Id_Region {get;set;}

        //Relacion con Region
       // public int Region {get; set;}
 
    }
}