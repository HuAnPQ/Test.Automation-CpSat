using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Data
{
    public class ProveedorDeDatos
    {

        public IEnumerable<Busqueda> ConsultarBusquedasDeExcel()
        {
            var memoryStream = new MemoryStream(Recursos.Archivos.Busquedas);
            return new ExcelMapper(memoryStream) { HeaderRow = true }.Fetch<Busqueda>();
        }
    }
}
