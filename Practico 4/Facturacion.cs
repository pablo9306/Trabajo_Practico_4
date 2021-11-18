using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Practico_4
{
    class Facturacion
    {

        public static void DatosFacturacion()
        {
            //Verificao si el file existe, en caso de no existir se crea.
            /*
            if (!File.Exists(@"Facturas.txt"))
            {
                using (var writer = new StreamWriter(@"Facturas.txt"))
                {
                    //formato: num factura; cuit cliente; cod servicio; pago; monto 
                    writer.WriteLine("0001-57913462;40395;10432;no;4500");
                    writer.WriteLine("0001-03184061;40395;10946;si;1800");
                    writer.WriteLine("0001-64703198;18285;10049;si;1200");
                    writer.WriteLine("0001-94310580;18285;10501;no;7000");
                    writer.WriteLine("0001-54872695;18285;10689;si;2000");
                    writer.WriteLine("0001-16485201;48407;11052;si;3000");
                    writer.WriteLine("0001-84301764;48407;10784;no;1800");

                    writer.Close();
                }
            }*/
        }

        //devuelve facturación por cliente
        public static List<string> ConsultarFacturacionCliente(int cuit)
        {
            List<string> FacturasCliente = new List<string>();

            using (StreamReader lector = new StreamReader(@"Facturas.txt"))
            {
                string line;

                while ((line = lector.ReadLine()) != null)
                {
                    if (line.Contains(cuit.ToString()))
                    {
                        FacturasCliente.Add(line);
                    }
                }

                lector.Close();
            }

            return FacturasCliente;
        }
    }

}
