using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulos.Entidades
{
    //Debe ser PUBLIC para que sea visible para las demas capas
    public class rArticulos
    {
        [Key] //hay que importar System.ComponentModel.DataAnnotations;
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public int CantidadCotizada { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public rArticulos()
        {

            ArticuloId = 0;
            Descripcion = string.Empty;
            Precio = string.Empty;
            CantidadCotizada = 0;
            FechaVencimiento = DateTime.Now; //inicializamos con la fecha actual.

        }
    }
}
