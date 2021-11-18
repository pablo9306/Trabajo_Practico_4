using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Trabajo_Practico_4
{
    class Servicios
    {

        public bool urgente { get; set; }

        public bool retiroPuerta { get; set; }

        public bool entregaPuerta { get; set; }

        public int alcanceEnvío { get; set; }

        public int alcanceEnvioInt { get; set; }

        public string direccionOrigen { get; set; }

        public string direccionDestino { get; set; }

        public int codigoPostalOrigen { get; set; }

        public int codigoPostalDestino { get; set; }

        public string regionProvinciaOrigen { get; set; }

        public string tipoEntregaSeleccionada { get; set; }

        public string tipoPaqueteSeleccionado { get; set; }

        public string provinciaDeOrigenSeleccionada { get; set; }

        public string provinciaDeDestinoSeleccionada { get; set; }

        public string provinciaDestinoInternacional { get; set; }

        public double precioFinal { get; set; }

        public int codSeg { get; set; }



        Dictionary<int, string> tipoEntrega = new Dictionary<int, string>()
        {
            [1] = "Nacional",
            [2] = "Internacional"
        };

        Dictionary<int, string> tipoPaquete = new Dictionary<int, string>()
        {
            [1] = "Sobres hasta 500 gramos",
            [2] = "Bultos hasta 10 kilogramos",
            [3] = "Bultos hasta 20 kilogramos",
            [4] = "Bultos hasta 30 kilogramos"
        };

        Dictionary<int, string> provinciaNacional = new Dictionary<int, string>()
        {
            [1] = "Buenos Aires",
            [2] = "CABA",
            [3] = "Catamarca",
            [4] = "Chaco",
            [5] = "Chubut",
            [6] = "Cordoba",
            [7] = "Corrientes",
            [8] = "Entre Rios",
            [9] = "Formosa",
            [10] = "Jujuy",
            [11] = "La Pampa",
            [12] = "La Rioja",
            [13] = "Mendoza",
            [14] = "Misiones",
            [15] = "Neuquen",
            [16] = "Rio Negro",
            [17] = "San Luis",
            [18] = "San Juan",
            [19] = "Santa Cruz",
            [20] = "Santa Fe",
            [21] = "Santiago del Estero",
            [22] = "Salta",
            [23] = "Tierra del Fuego",
            [24] = "Tucumán",

        };

        Dictionary<int, string> provinciaInternacional = new Dictionary<int, string>()
        {
            [1] = "Brasil - San Pablo",
            [2] = "Uruguay - Montevideo",
            [3] = "Paraguay - Asuncion",
            [4] = "Colombia - Antioquia",
            [5] = "Peru - Lima",
            [6] = "Ecuador - Quito",
            [7] = "Estados Unidos - California",
            [8] = "España - Madrid",
            [9] = "Japon - Tokio",
            [10] = "China - Pekin",
        };

        List<string> regionNorte = new List<string>()
        {
            "Chaco",
            "Salta",
            "Catamarca",
            "Formosa",
            "Jujuy",
            "Misiones",
            "Santiago del Estero",
            "Tucuman",
            "Corrientes"
        };

        List<string> regionCentro = new List<string>()
        {
            "Cordoba",
            "Entre Rios",
            "La Pampa",
            "La Rioja",
            "Mendoza",
            "San Juan",
            "San Luis",
            "Santa Fe"

        };

        List<string> regionSur = new List<string>()
        {
            "Chubut",
            "Neuquen",
            "Rio Negro",
            "Santa Cruz",
            "Tierra Del Fuego"
        };


        List<string> regionMetropolitana = new List<string>()
        {
            "Buenos Aires",
            "CABA"
        };

        List<string> paisesLimitrofes = new List<string>()
        {
            "Brasil - San Pablo",
            "Uruguay - Montevideo",
            "Paraguay - Asunción"
        };

        List<string> restoAmericaLatina = new List<string>()
        {
            "Colombia - Antioquia",
            "Peru - Lima",
            "Ecuador - Quito"
        };

        List<string> americaDelNorte = new List<string>()
        {
            "Estados Unidos - California"
        };

        List<string> europa = new List<string>()
        {
            "España - Madrid"
        };

        List<string> asia = new List<string>()
        {
            "Japon - Tokio",
            "China - Pekin"
        };

        //Selecciona el usuario el peso del paquete a enviar

        int opcionPaquete;

        public void elegirTipoPaquete()
        {
            bool flag = false;
            string paquete;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Paso 1 - Seleccione el número del tipo de paquete a entregar y presione ENTER");
                Console.WriteLine();
                foreach (KeyValuePair<int, string> opcion in tipoPaquete)
                {
                    Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                    Console.WriteLine();
                }

                paquete = Console.ReadLine();

                //Valido la data ingresada por el usuario
                if (string.IsNullOrWhiteSpace(paquete))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
                    Console.WriteLine();
                }

                else if (!int.TryParse(paquete, out opcionPaquete))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valor numérico.");
                    Console.WriteLine();
                }

                else if (opcionPaquete != 1 && opcionPaquete != 2 && opcionPaquete != 3 && opcionPaquete != 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese una de las opciones");
                    Console.WriteLine();

                }

                else
                {
                    flag = true;
                }

            } while (flag == false);

            tipoPaqueteSeleccionado = tipoPaquete[opcionPaquete];

            Console.WriteLine($"\nEligió: {tipoPaqueteSeleccionado}\n");
            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();

            Console.Clear();
        }

        //Selecciona el usuario si desea una entrega nacional o internacional

        int opcionEntrega;
        int opcionProvincia;

        public void elegirTipoEntrega(int nrocliente)
        {
            bool flag = false;
            string entrega;

            do
            {
                Console.WriteLine("Paso 2 - Seleccione el número del tipo de entrega a realizar y presione ENTER");
                Console.WriteLine();

                foreach (KeyValuePair<int, string> opcion in tipoEntrega)
                {

                    Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                    Console.WriteLine();
                }

                entrega = Console.ReadLine();

                //Valido la data ingresada por el usuario
                if (string.IsNullOrWhiteSpace(entrega))
                    Console.WriteLine("\nPor favor, no ingrese valores vacíos\n");

                else if (!int.TryParse(entrega, out opcionEntrega))
                    Console.WriteLine("\nPor favor ingrese un valor numérico\n");
                
                else if (opcionEntrega != 1 && opcionEntrega != 2)
                    Console.WriteLine("\nPor favor ingrese una de las opciones\n");
                
                else
                    flag = true;
                
            } while (flag == false);

            tipoEntregaSeleccionada = tipoEntrega[opcionEntrega];

            //Devuelvo la información seleccionada para el tipo de entrega
            Console.WriteLine($"\nEligió: {tipoEntregaSeleccionada}\n");
            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();

            Console.Clear();

            bool flagC = false;
            string provinciaDeOrigen;

            Console.WriteLine("Paso 3 - Seleccione la provincia de ORIGEN y presione ENTER");
            Console.WriteLine();
            do
            {
                foreach (KeyValuePair<int, string> opcion in provinciaNacional)
                {
                    Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                }

                provinciaDeOrigen = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(provinciaDeOrigen))
                    Console.WriteLine("\nPor favor, no ingrese valores vacíos\n");
                
                else if (!int.TryParse(provinciaDeOrigen, out opcionProvincia))
                    Console.WriteLine("\nPor favor ingrese un valor numérico\n");
                
                else if (opcionProvincia <= 0 || opcionProvincia > 24)
                    Console.WriteLine("\nPor favor ingrese una de las opciones\n");
                
                else
                    flagC = true;
                
            } while (flagC == false);

            provinciaDeOrigenSeleccionada = provinciaNacional[opcionProvincia];

            Console.WriteLine($"\nEligió {provinciaDeOrigenSeleccionada} como ORIGEN\n");
            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();

            Console.Clear();

            if (tipoEntregaSeleccionada == "Nacional")
            {
                bool flagF = false;
                string provinciaDeDestino;

                Console.WriteLine("Paso 4 - Seleccione la provincia/estado de DESTINO y presione ENTER");
                Console.WriteLine();
                do
                {
                    foreach (KeyValuePair<int, string> opcion in provinciaNacional)
                    {
                        Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                    }

                    provinciaDeDestino = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(provinciaDeDestino))
                        Console.WriteLine("\nPor favor, no ingrese valores vacíos\n");
                    
                    else if (!int.TryParse(provinciaDeDestino, out opcionProvincia))
                        Console.WriteLine("\nPor favor ingrese un valor numérico\n");
                    
                    else if (opcionProvincia <= 0 || opcionProvincia > 24)
                        Console.WriteLine("\nPor favor ingrese una de las opciones\n");
                    
                    else
                        flagF = true;
                    
                } while (flagF == false);

                provinciaDeDestinoSeleccionada = provinciaNacional[opcionProvincia];

                Console.WriteLine($"\nEligió {provinciaDeDestinoSeleccionada} como DESTINO\n");
                Console.WriteLine("------Enter para continuar------");
                Console.ReadKey();

                Console.Clear();
            }

            else
            {
                bool flagG = false;

                Console.WriteLine("Paso 4 - Seleccione el DESTINO y presione ENTER");

                do
                {
                    foreach (KeyValuePair<int, string> opcion in provinciaInternacional)
                    {
                        Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                    }

                    provinciaDestinoInternacional = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(provinciaDestinoInternacional))
                        Console.WriteLine("\nPor favor, no ingrese valores vacíos\n");
                    
                    else if (!int.TryParse(provinciaDestinoInternacional, out opcionProvincia))
                        Console.WriteLine("\nPor favor ingrese un valor numérico\n");
                    
                    else if (opcionProvincia <= 0 || opcionProvincia > 10)
                        Console.WriteLine("\nPor favor ingrese una de las opciones\n");
                    
                    else
                        flagG = true;
                    
                } while (flagG == false);

                provinciaDestinoInternacional = provinciaInternacional[opcionProvincia];

                Console.WriteLine($"\nEligió {provinciaDestinoInternacional} como DESTINO\n");
                Console.WriteLine("------Enter para continuar------");
                Console.ReadKey();

                Console.Clear();
            }

            bool flagA = false;
            bool flagB = false;
            string codigoPostalIngresado;
            int codigoPostalValidadoOrigen = 0;
            int codigoPostalValidadoDestino = 0;

            do
            {
                Console.WriteLine("Paso 5.1 - Ingrese el Código Postal de origen (SOLO NUMEROS) y presione ENTER");

                codigoPostalIngresado = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(codigoPostalIngresado))
                    Console.WriteLine("\nPor favor, no ingrese valores vacíos\n");
                
                else if (!int.TryParse(codigoPostalIngresado, out codigoPostalValidadoOrigen))
                    Console.WriteLine("\nPor favor ingrese un Código Postal valido\n");
                
                else if (codigoPostalValidadoOrigen <= 0)
                    Console.WriteLine("\nPor favor ingrese un Código Postal valido\n");
                
                else
                    flagA = true;
                
            } while (flagA == false);

            codigoPostalOrigen = codigoPostalValidadoOrigen;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Paso 5.2 - Ingrese el Código Postal de destino (SOLO NUMEROS) y presione ENTER");

                codigoPostalIngresado = Console.ReadLine();
                Console.WriteLine();
                if (string.IsNullOrWhiteSpace(codigoPostalIngresado))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
                    Console.WriteLine();
                }

                else if (!int.TryParse(codigoPostalIngresado, out codigoPostalValidadoDestino))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un Código Postal valido.");
                    Console.WriteLine();
                }
                else if (codigoPostalValidadoDestino <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un Código Postal valido.");
                    Console.WriteLine();
                }

                else
                {
                    flagB = true;
                }

            } while (flagB == false);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//

            Console.Clear();//

            codigoPostalDestino = codigoPostalValidadoDestino;

            string direccionDeOrigen;
            bool flagD = false;

            do
            {

                Console.WriteLine("Paso 6.1 - Ingrese la dirección de ORIGEN y presione ENTER");

                direccionDeOrigen = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(direccionDeOrigen))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
                    Console.WriteLine();
                    continue;
                }

                if (flag = hasSpecialChar2(direccionDeOrigen))
                {
                    Console.WriteLine("La dirección no debe contener símbolos");
                    continue;
                }

                else
                {
                    flagD = true;
                }

            } while (flagD == false);


            direccionOrigen = direccionDeOrigen;

            string direccionDeDestino;
            bool flagE = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Paso 6.2 - Ingrese la dirección de DESTINO y presione ENTER");

                direccionDeDestino = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(direccionDeDestino))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
                    Console.WriteLine();
                    continue;
                }

                if (flag = hasSpecialChar2(direccionDeDestino))
                {
                    Console.WriteLine("La dirección no debe contener símbolos");
                    continue;
                }

                else
                {
                    flagE = true;
                }

            } while (flagE == false);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//

            Console.Clear();//


            direccionDestino = direccionDeDestino;

            //calculo alcance del envío comparando regiones ( alcance: 1 = local / 2=provincial / 3=regional / 4=nacional )

            if (tipoEntregaSeleccionada == "Nacional")
            {

                if (regionCentro.Contains(provinciaDeOrigenSeleccionada) && regionCentro.Contains(provinciaDeDestinoSeleccionada) ||
                regionNorte.Contains(provinciaDeOrigenSeleccionada) && regionNorte.Contains(provinciaDeDestinoSeleccionada) ||
                regionSur.Contains(provinciaDeOrigenSeleccionada) && regionSur.Contains(provinciaDeDestinoSeleccionada) ||
                regionMetropolitana.Contains(provinciaDeOrigenSeleccionada) && regionMetropolitana.Contains(provinciaDeDestinoSeleccionada))
                {

                    if (provinciaDeDestinoSeleccionada == provinciaDeOrigenSeleccionada)
                    {
                        if (codigoPostalDestino == codigoPostalOrigen)
                            alcanceEnvío = 1;
                        else
                            alcanceEnvío = 2;
                    }
                    else
                        alcanceEnvío = 3;
                }
                else
                    alcanceEnvío = 4;
            }
            else
            {
                if (regionMetropolitana.Contains(provinciaDeOrigenSeleccionada) && regionMetropolitana.Contains("CABA"))
                {
                    if (provinciaDeOrigenSeleccionada == "CABA")
                        alcanceEnvío = 1;
                    else
                        alcanceEnvío = 3;
                }
                else
                    alcanceEnvío = 4;

            }

            if (paisesLimitrofes.Contains(provinciaDestinoInternacional))
            {
                alcanceEnvioInt = 1;

            }
            else if (restoAmericaLatina.Contains(provinciaDestinoInternacional))
            {
                alcanceEnvioInt = 2;
            }
            else if (americaDelNorte.Contains(provinciaDestinoInternacional))
            {
                alcanceEnvioInt = 3;
            }
            else if (europa.Contains(provinciaDestinoInternacional))
            {
                alcanceEnvioInt = 4;
            }
            else if (asia.Contains(provinciaDestinoInternacional))
            {
                alcanceEnvioInt = 5;

            }

            bool flag1 = false;
            do
            {
                Console.WriteLine("Paso 7 - ¿Desea hacer el envío con entrega a domicilio? Su costo adicional es de $80. Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);

                Console.WriteLine();

                if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }

                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El envío será realizado al domicilio");
                    entregaPuerta = true;
                    flag1 = true;
                    Console.WriteLine();
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El envío será realizado a la sucursal de DESTINO más cercana");
                    entregaPuerta = false;
                    flag1 = true;
                    Console.WriteLine();
                }


            } while (!flag1);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//

            Console.Clear();//

            bool flag2 = false;
            do
            {

                Console.WriteLine("Paso 8 - ¿Desea hacer el despacho desde su domicilio? El valor adicional es de $70. Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);
                Console.WriteLine();

                if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }


                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El despacho será realizado desde su domicilio");
                    retiroPuerta = true;
                    flag2 = true;
                    Console.WriteLine();
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El despacho será realizado desde la sucursal");
                    retiroPuerta = false;
                    flag2 = true;
                    Console.WriteLine();
                }


            } while (!flag2);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();

            Console.Clear();

            bool flag3 = false;
            do
            {


                Console.WriteLine("Paso 9 - ¿Desea que el envío sea urgente? El adicional es de un 15% sobre el valor del envío. Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);
                Console.WriteLine();

                if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }


                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El envío será realizado de forma urgente");
                    urgente = true;
                    flag3 = true;
                    Console.WriteLine();
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El envío será realizado de forma normal");
                    urgente = false;
                    flag3 = true;
                    Console.WriteLine();
                }

            } while (!flag3);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();

            Console.Clear();

            //CALCULAR PRECIO
            var precio = new Precios();
            var logistica = new Logistica();

            if (tipoEntregaSeleccionada == "Nacional")
                precioFinal = precio.CalcularPrecioServicio(tipoPaqueteSeleccionado, alcanceEnvío, entregaPuerta, retiroPuerta, urgente);
            else
                precioFinal = precio.CalcularPrecioServicio(tipoPaqueteSeleccionado, alcanceEnvío, entregaPuerta, retiroPuerta, alcanceEnvioInt, urgente);
            
            Console.WriteLine($"Valor del envío: ${precioFinal} (IVA incluido)");

            flag = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Paso 10 - ¿Desea confirmar? Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);

                if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                    Console.WriteLine("Ingrese Si(S) / No(N)");
                
                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("\nEl envío fue confirmado exitosamente");
                    Console.ReadKey();

                    logistica.DatosCoddeSeg();
                    
                    //MOSTRAR DETALLE
                    mostrarDetalle();
                    //Generar código de seguimiento y grabar servicio
                    logistica.GenerarFile(nrocliente,logistica.GeneraryMostrarMostrarCS(nrocliente), precioFinal);
                    flag = true;
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("\n¿Esta seguro que quiere cancelarlo? Si(S) / No(N)");

                    var tecla2 = Console.ReadKey(intercept: true);

                    if (tecla2.Key != ConsoleKey.S && tecla2.Key != ConsoleKey.N)
                        Console.WriteLine("\nIngrese Si(S) / No(N)");
                    
                    if (tecla2.Key == ConsoleKey.N)
                        flag = false;
                    
                    if (tecla2.Key == ConsoleKey.S)
                    {
                        Console.WriteLine("\nEl envío fue cancelado");
                        //VOLVER AL MENU PRINCIPAL
                        flag = true;
                    }

                }

            } while (!flag);

        }


        public void mostrarDetalle()
        {
            Console.Clear();
            var logistica = new Logistica();

            Console.WriteLine($"\nResumen servicio: ");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Datos generales del servicio: ");
            Console.WriteLine($"Se enviará un {tipoPaqueteSeleccionado} ");
            Console.WriteLine($"El servicio a realizar será de alcance: {tipoEntregaSeleccionada}");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Datos de origen: ");
            Console.WriteLine($"Provincia de origen: {provinciaDeOrigenSeleccionada}");
            Console.WriteLine($"Dirección de origen: {direccionOrigen}");
            Console.WriteLine($"Codigo postal de origen: {codigoPostalOrigen}");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Datos de destino: ");
            Console.WriteLine($"Provincia de destino: {provinciaDeDestinoSeleccionada}{provinciaDestinoInternacional}");
            Console.WriteLine($"Dirección de destino: {direccionDestino}");
            Console.WriteLine($"Codigo postal de destino: {codigoPostalDestino}");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Servicios adicionales: ");

            if (urgente == false && entregaPuerta == false && retiroPuerta == false)
            {
                Console.WriteLine("No se solicitó ningún servicio adicional");
            }

            else
            {
                int numero = 0;

                if (urgente == true)
                {
                    numero++;
                    Console.WriteLine($" {numero}. El servicio será realizado con caracter urgente");
                }
                if (entregaPuerta == true)
                {
                    numero++;
                    Console.WriteLine($" {numero}. El servicio se entregará en puerta");
                }
                if (retiroPuerta == true)
                {
                    numero++;
                    Console.WriteLine($" {numero}. El servicio se retirará en puerta");
                }
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.ReadKey();

        }


        //METOD PARA VALIDAR SIMBOLOS
        public static bool hasSpecialChar2(string input)
        {
            string specialChar = @"|¡!#$%&/()`^=¿?»«@£§€{}.,;:[]+-~`'°<>_";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
    }
}

