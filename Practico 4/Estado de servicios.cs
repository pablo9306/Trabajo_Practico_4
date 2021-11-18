using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Practico_4
{
    class Estado_de_servicio
    {
        //en class Estado_de_servicio

        //verifico si el file existe, sino se crea
        public static void SolicitudesDeServicio()
        {
            //Verifico si el file existe, en caso de no existir se crea.
            /*
            if (!File.Exists(@"SolicitudesDeServicio.txt"))
            {
                using (var writer = new StreamWriter(@"SolicitudesDeServicio.txt"))
                {
                    //formato: cuit cliente; cod servicio; estado; monto
                    writer.WriteLine("40395;10589;Recibido;3000");
                    writer.WriteLine("40395;10432;Tránsito;4500");
                    writer.WriteLine("40395;10946;Cerrado;1800");
                    writer.WriteLine("18285;10049;Tránsito;1200");
                    writer.WriteLine("18285;10501;Tránsito;7000");
                    writer.WriteLine("18285;10689;Cerrado;2000");
                    writer.WriteLine("14330;10054;Recibido;6000");
                    writer.WriteLine("14330;11194;Recibido;1200");
                    writer.WriteLine("48407;11052;Cerrado;3000");
                    writer.WriteLine("48407;10784;Tránsito;1800");

                    writer.Close();
                }
            }*/
        }

        //devuelve historial de servicios por cliente
        public static List<string> ConsultarServiciosCliente(int cuit)
        {
            List<string> ServiciosCliente = new List<string>();

            using (StreamReader lector = new StreamReader(@"CodigosdeSeguimiento.txt"))
            {
                string line;

                while ((line = lector.ReadLine()) != null)
                {
                    if (line.Contains(cuit.ToString()))
                    {
                        ServiciosCliente.Add(line);
                    }
                }

                lector.Close();
            }

            return ServiciosCliente;
        }


        //en class

        //muestra historial de servicios
        public void ConsultarHistorialCuenta(int cuit)
        {
            Console.WriteLine($"Historial de servicios del cliente {cuit}:");

            foreach (var item in Estado_de_servicio.ConsultarServiciosCliente(cuit))
            {
                string[] linea = item.Split(';');
                Console.WriteLine($"Código servicio: {linea[0]} \t\t Monto total: {linea[3]} \t\t Estado: {linea[2]}");
            }

            Console.ReadKey();
        }

        //muestra saldo deudor de la cuenta
        public void ConsultarSaldoCuenta(int cuit)
        {
            Console.WriteLine($"Servicios del cliente {cuit}:");
            double servicios_pagos = 0;
            double servicios_total = 0;
            List<string> servicios_facturados = Facturacion.ConsultarFacturacionCliente(cuit);
            List<string> codigos_facturados = new List<string>();

            foreach (var item in servicios_facturados)
            {
                string[] linea = item.Split(';');
                codigos_facturados.Add(linea[2]);
            }

            //arranca con lista de todos los servicios
            foreach (var item in Estado_de_servicio.ConsultarServiciosCliente(cuit))
            {
                string[] lineaservicio = item.Split(';');

                //escribe los que no estan facurados
                if (!codigos_facturados.Contains(lineaservicio[1]))
                {
                    Console.WriteLine($"Código servicio: {lineaservicio[0]} \t\t Monto total: {lineaservicio[3]} \t\t Estado: Pendiente Facturación");
                    double monto = double.Parse(lineaservicio[3]);
                }
                //escribe los facturados 
                else
                {
                    foreach (var item2 in servicios_facturados)
                    {
                        string[] lineafactura = item2.Split(';');

                        if (lineaservicio[1] == lineafactura[2])
                        {
                            //escribe los que estan pagos
                            if (lineafactura[3] == "si")
                            {
                                Console.WriteLine($"Código servicio: {lineafactura[2]} \t\t Monto total: {lineafactura[4]} \t\t Estado: Pago");
                                double monto = int.Parse(lineafactura[4]);
                                servicios_pagos += monto;
                            }
                            else
                                Console.WriteLine($"Código servicio: {lineafactura[2]} \t\t Monto total: {lineafactura[4]} \t\t Estado: Facturado pendiente de pago");

                        }

                    }

                }

                double monto2 = double.Parse(lineaservicio[3]);
                servicios_total += monto2;

            }

            Console.WriteLine($"\nSu saldo deudor es de ${servicios_total - servicios_pagos}" +
                        "\nPresione una tecla para volver al menú principal.\n");
            Console.ReadKey();
        }

        public static void ConsultarEstadoServicio()
        {
            string estado_servicio = "";
            int codigo = Logistica.ValidarCodigoIngresado();

            //falta recorrer txt y escribir el estado
            using (StreamReader sr = new StreamReader(@"CodigosdeSeguimiento.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(codigo.ToString()))
                    {
                        string[] arraylinea = line.Split(';');
                        estado_servicio = arraylinea[2];
                    }
                }

                sr.Close();
            }

            Console.WriteLine($"Estado del servicio {codigo}: {estado_servicio}");

        }

    }
}
