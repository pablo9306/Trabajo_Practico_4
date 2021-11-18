using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Practico_4
{
    public class Precios
    {
        public double IVA { get; } = 1.21;
        public double RetiroPuerta { get; } = 70;
        public double EntregaPuerta { get; } = 80;
        public double precioBruto { get; set; }
        public double precioAlcance { get; set; }
        public double precioAlcanceInt { get; set; }
        public double Urgente { get; } = 1.15;
        public double precioFinal { get; set; }
        public double precioPL { get; } = 2500;
        public double precioRAM { get; } = 4500;
        public double precioAN { get; } = 7500;
        public double precioEU { get; } = 10000;
        public double precioAS { get; } = 13500;

        public void DatosTarifas()
        {
            //ver de agregar un file con tarifas
        }


        //método calcular precio
        public double CalcularPrecioServicio(string tipoPaquete, int alcance, bool entregaPuerta, bool retiroPuerta, bool urgente)
        {
            precioBruto = 0;
            precioAlcance = 0;

            if (tipoPaquete == "Sobres hasta 500 gramos")
                precioBruto = 200;
            else if (tipoPaquete == "Bultos hasta 10 kilogramos")
                precioBruto = 300;
            else if (tipoPaquete == "Bultos hasta 20 kilogramos")
                precioBruto = 400;
            else if (tipoPaquete == "Bultos hasta 30 kilogramos")
                precioBruto = 500;

            Console.WriteLine("-------------------Valores del envío-------------------\n");

            Console.WriteLine($"1){tipoPaquete}: ${precioBruto}");

            if (alcance == 1)
            {
                precioAlcance = 150;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma localidad: ${precioAlcance}");
            }
            else if (alcance == 2)
            {
                precioAlcance = 250;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma provincia: ${precioAlcance}");
            }
            else if (alcance == 3)
            {
                precioAlcance = 350;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma región: ${precioAlcance}");
            }
            else
            {
                precioAlcance = 450;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en distinta región: ${precioAlcance}");
            }
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Servicios adicionales:");
            Console.WriteLine();
            if (entregaPuerta == true)
            {
                Console.WriteLine($"3)Entrega en domicilio: Si - ${EntregaPuerta}");
                precioBruto += EntregaPuerta;
            }
            else
                Console.WriteLine("3)Entrega en domicilio: No");
            
            if (retiroPuerta == true)
            {
                Console.WriteLine($"4)Retiro en domicilio: Si - ${RetiroPuerta}");
                precioBruto += RetiroPuerta;
            }
            else
                Console.WriteLine("4)Retiro en domicilio: No");
            
            if (urgente == true)
            {
                Console.WriteLine($"5)Urgente: Si - ${precioBruto * (Urgente - 1)}");
                precioBruto = precioBruto * Urgente;
            }
            else
                Console.WriteLine("5)Urgente: No");

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Valor del envío sin IVA: ${precioBruto}");
            Console.WriteLine();

            precioFinal = precioBruto * IVA;

            return precioFinal;
        }

        public double CalcularPrecioServicio(string tipoPaquete, int alcance, bool entregaPuerta, bool retiroPuerta, int alcanceEnvioInt, bool urgente)
        {
            precioBruto = 0;
            precioAlcance = 0;
            precioAlcanceInt = 0;

            if (tipoPaquete == "Sobres hasta 500 gramos")
                precioBruto = 200;
            else if (tipoPaquete == "Bultos hasta 10 kilogramos")
                precioBruto = 300;
            else if (tipoPaquete == "Bultos hasta 20 kilogramos")
                precioBruto = 400;
            else if (tipoPaquete == "Bultos hasta 30 kilogramos")
                precioBruto = 500;
            
            Console.WriteLine("-------------------Valores del envío-------------------\n");

            Console.WriteLine($"1){tipoPaquete}: ${precioBruto}\n");

            if (alcance == 1)
            {
                precioAlcance = 150;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma localidad: ${precioAlcance}");
            }
            else if (alcance == 2)
            {
                precioAlcance = 250;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma provincia: ${precioAlcance}");
            }
            else if (alcance == 3)
            {
                precioAlcance = 350;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma región: ${precioAlcance}");
            }
            else
            {
                precioAlcance = 450;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en distinta región: ${precioAlcance}");
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Servicios adicionales:");
            Console.WriteLine();
            if (entregaPuerta == true)
            {
                Console.WriteLine($"3)Entrega en domicilio: Si - ${EntregaPuerta}");
                precioBruto += EntregaPuerta;
            }
            else
                Console.WriteLine("3)Entrega en domicilio: No");
            
            if (retiroPuerta == true)
            {
                Console.WriteLine($"4)Retiro en domicilio: Si - ${RetiroPuerta}");
                precioBruto += RetiroPuerta;
            }
            else
                Console.WriteLine("4)Retiro en domicilio: No");
            
            if (alcanceEnvioInt == 1)
            {
                Console.WriteLine($"5)Envío a país limítrofe: ${precioPL}");
                precioBruto += precioPL;
            }
            else if (alcanceEnvioInt == 2)
            {
                Console.WriteLine($"5)Envío a país resto de América Latina: ${precioRAM}");
                precioBruto += precioRAM;
            }
            else if (alcanceEnvioInt == 3)
            {
                Console.WriteLine($"5)Envío a país de América del Norte: ${precioAN}");
                precioBruto += precioAN;
            }
            else if (alcanceEnvioInt == 4)
            {
                Console.WriteLine($"5)Envío a país de Europa: ${precioEU}");
                precioBruto += precioEU;
            }
            else if (alcanceEnvioInt == 5)
            {
                Console.WriteLine($"5)Envío a país de Asia: ${precioAS}");
                precioBruto += precioAS;
            }

            if (urgente == true)
            {
                Console.WriteLine($"6)Urgente: Si - ${precioBruto * (Urgente - 1)}");
                precioBruto = precioBruto * Urgente;
            }
            else
                Console.WriteLine("6)Urgente: No");

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Valor del envío sin IVA: ${precioBruto}\n");

            precioFinal = precioBruto * IVA;

            return precioFinal;
        }

    }
}

