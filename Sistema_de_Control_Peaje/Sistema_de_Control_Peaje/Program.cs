using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Control_Peaje
{
    internal class Program
    {
        static int max_vehiculos = 15;
        static int[] numeroFactura = new int[max_vehiculos];
        static string[] numeroPlaca = new string[max_vehiculos];
        static string[] fecha = new string[max_vehiculos];
        static string[] hora = new string[max_vehiculos];
        static int[] tipoVehiculo = new int[max_vehiculos];
        static int[] numeroCaseta = new int[max_vehiculos];
        static double[] montoPagar = new double[max_vehiculos];
        static double[] pagaCon = new double[max_vehiculos];
        static double[] vuelto = new double[max_vehiculos];
        static int cantidadVehiculos = 0;

        static void Main(string[] args)
        {
            bool salir = false;
            InicializarVectores();

            do
            {
                Console.WriteLine("=============================================================================");
                Console.WriteLine("Menu Principal Del Sistema");
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Ingresar Paso Vehicular");
                Console.WriteLine("3. Consulta de vehiculos por Numero de Placa");
                Console.WriteLine("4. Modificar Datos de Vehiculos por Numero de Placa");
                Console.WriteLine("5. Reporte de Todos los Datos de Los Vectores");
                Console.WriteLine("6. Salir");

                Console.WriteLine("Selecciona una opcion: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        InicializarVectores();
                        break;

                    case 2:
                        IngresarPasoVehicular();
                        break;

                    case 3:
                        ConsultarVehiculoPorPlaca();
                        break;

                    case 4:
                        ModificarDatosVehiculoPorPlaca();
                        break;

                    case 5:
                        ReporteTodosLosDatos();
                        break;

                    case 6:
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opcion No valida. Reinicia el Programa");
                        break;
                }

            } while (!salir);
        }

        static void InicializarVectores()
        {
            for (int i =0; i < max_vehiculos; i++)
            {
                numeroFactura[i] = 0;
                numeroPlaca[i] = " ";
                fecha[i] = " ";
                hora[i] = " ";
                tipoVehiculo[i] = 0;
                numeroCaseta[i] = 0;
                montoPagar[i] = 0;
                pagaCon[i] = 0.0;
                vuelto[i] = 0.0;
            }
            cantidadVehiculos = 0;
            Console.WriteLine("Vectores Inicializados");
        }

        static void IngresarPasoVehicular()
        {
            if (cantidadVehiculos < max_vehiculos)
            {
                Console.WriteLine("Numero de Factura: ");
                numeroFactura[cantidadVehiculos] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Numero de Placa: ");
                numeroPlaca[cantidadVehiculos] = Console.ReadLine();

                Console.WriteLine("Fecha: ");
                fecha[cantidadVehiculos] = Console.ReadLine();

                Console.WriteLine("Hora: ");
                hora[cantidadVehiculos] = Console.ReadLine();

                Console.WriteLine("Tipo de Vehiculo (1 = Moto, 2 = Vehiculos Liviano, 3 = Camion, 4 = Autobus): ");
                tipoVehiculo[cantidadVehiculos] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Numero de Caseta (1, 2, 3): ");
                numeroCaseta[cantidadVehiculos] = Convert.ToInt32(Console.ReadLine());

                switch (tipoVehiculo[cantidadVehiculos])
                {
                    case 1:
                        montoPagar[cantidadVehiculos] = 500;
                        break;

                    case 2:
                        montoPagar[cantidadVehiculos] = 700;
                        break;

                    case 3:
                        montoPagar[cantidadVehiculos] = 2700;
                        break;

                    case 4:
                        montoPagar[cantidadVehiculos] = 3700;
                        break;

                    default:
                        Console.WriteLine("Tipo de Vehiculo No valido. Monto a Pagar Incorrecto");
                        break;
                }

                Console.WriteLine("Monto a Pagar: ");
                pagaCon[cantidadVehiculos] = Convert.ToDouble(Console.ReadLine());
                vuelto[cantidadVehiculos] = pagaCon[cantidadVehiculos] - montoPagar[cantidadVehiculos];

                cantidadVehiculos++;

                Console.WriteLine("Desea Continuar (S/N)= ");
                char respuesta = Console.ReadLine()[0];
                if (respuesta != 'S' && respuesta  != 's')
                {
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("El limite de vehiculos ha sido superado");
            }
        }

        static void ConsultarVehiculoPorPlaca()
        {
            Console.WriteLine("Ingrese el numero de placa del vehiculo a consultar: ");
            string placa = Console.ReadLine();

            Console.WriteLine("Numero Factura\tPlaca\tFecha\tHora\tTipo de Vehiculo\tNumero Caseta\tMonto a Pagar\tPagar con\tVuelto");
            Console.WriteLine("=====================================================================================================");
            for (int i = 0; i < cantidadVehiculos; i++)
            {
                if (numeroPlaca[i] == placa)
                {
                    Console.WriteLine($"{numeroFactura[i]}\t{numeroPlaca[i]}\t{fecha[i]}\t{hora[i]}\t{tipoVehiculo[i]}\t{numeroCaseta[i]}\t{montoPagar[i]}\t{pagaCon[i]}\t{vuelto[i]}");
                }
            }
            Console.WriteLine("===============================================================================================");
            Console.WriteLine("Presiona cualquier tecla para ingresar");
            Console.ReadKey();
        }

        static void ModificarDatosVehiculoPorPlaca()
        {
            Console.WriteLine("Ingrese el numero de Placa del Vehiculo a Modificar: ");
            string placa = Console.ReadLine();

            for (int i = 0; i < cantidadVehiculos; i++)
            {
                if (numeroPlaca[i] == placa)
                {
                    Console.WriteLine("Numero de Factura: " + numeroFactura[i]);
                    Console.WriteLine("Placa de Placa: " + numeroPlaca[i]);
                    Console.WriteLine("Fecha: " + fecha[i]);
                    Console.WriteLine("Hora: " + hora[i]);
                    Console.WriteLine("Tipo de Vehiculo: " + tipoVehiculo[i]);
                    Console.WriteLine("Numero de Caseta: " + numeroCaseta[i]);
                    Console.WriteLine("Monto a Pagar: " + montoPagar[i]);
                    Console.WriteLine("Paga Con: " + pagaCon[i]);
                    Console.WriteLine("Vuelto: " + vuelto[i]);

                    Console.WriteLine("===============================================================================================");

                    Console.WriteLine("¿Que datos desea modificar?");
                    Console.WriteLine("1. Numero de Factura");
                    Console.WriteLine("3. Numero de Placa");
                    Console.WriteLine("4. Fecha");
                    Console.WriteLine("5. Hora");
                    Console.WriteLine("6. Tipo de Vehiculo");
                    Console.WriteLine("7. Monto a Pagar");
                    Console.WriteLine("8. Paga Con");
                    Console.WriteLine("9. Vuelto");
                    Console.WriteLine("10. Regresar al Menu Principal");

                    Console.WriteLine("Selecciona una opcion: ");
                    int opcion = Convert.ToInt32 (Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Nuevo NUmero de Factura: ");
                            numeroFactura[i] = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Nueva Placa: ");
                            numeroPlaca[i] = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Nueva Fecha: ");
                            fecha[i] = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Nueva Hora: ");
                            hora[i] = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Nuevo Tipo de Vehiculo (1 = Moto, 2 = Vehiculo Liviano, 3 = Camion, 4 = Autoubs): ");
                            tipoVehiculo[i] = Convert.ToInt32(Console.ReadLine());
                            switch (tipoVehiculo[i])
                            {
                                case 1:
                                    montoPagar[i] = 500;
                                    break;
                                case 2:
                                    montoPagar[i] = 700;
                                    break;
                                case 3:
                                    montoPagar[i] = 2700;
                                    break;
                                case 4:
                                    montoPagar[i] = 3700;
                                    break;
                                default:
                                    Console.WriteLine("Tipo de vehiculo no valido. Monto a pagar no valido");
                                    break;
                            }
                            break;
                        case 6:
                            Console.WriteLine("Nuevo Numero de Caseta (1, 2, 3: ");
                            numeroCaseta[i] = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("Nuevo Monto a Pagar: ");
                            montoPagar[i] = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Nueva Paga Con: ");
                            pagaCon[i] = Convert.ToDouble(Console.ReadLine());
                            vuelto[i] = pagaCon[i] - montoPagar[i];
                            break;
                        case 9:
                            Console.WriteLine("Nuevo Vuelto: ");
                            vuelto[i] = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 10:
                            break;
                        default:
                            Console.WriteLine("Opcion no Valida,");
                            break;
                    }
                }
            }
        }

        static void ReporteTodosLosDatos()
        {
            Console.WriteLine("Reporte");
            Console.WriteLine("N Factura\tPlaca\tFecha\tHora\tTipo de Vehiculos\tNumero Caseta\tMonto a Pagar\tPaga Con\tVuelto");
            Console.WriteLine("===============================================================================================");

            for (int i = 0; 1 < cantidadVehiculos; i++)
            {
                Console.WriteLine($"{numeroFactura[i]}\t{numeroPlaca[i]}\t{fecha[i]}\t{hora[i]}\t{tipoVehiculo[i]}\t{numeroCaseta[i]}\t{montoPagar[i]}\t{pagaCon[i]}\t{vuelto[i]}");
            }
            Console.WriteLine("===============================================================================================");
            Console.WriteLine($"Cantidad de Vehiculos: {cantidadVehiculos}\tTotal: {MontoTotalPagar()}");
        }

        static double MontoTotalPagar()
        {
            double total = 0;
            for (int i =0; i < cantidadVehiculos; i++)
            {
                total += montoPagar[i];
            }
            return total;

        }
    }
}
