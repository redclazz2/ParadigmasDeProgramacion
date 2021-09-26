using System;

namespace LabPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreTitular; bool listo = false;
            CuentaBancaria cuentaActual = new CuentaBancaria();
            
            Console.WriteLine("Bienvenido a Bancos La Gloria Carmen, Porfavor digite la información solicitada para crear su cuenta.\n" +
                              "Ingrese su nombre completo: ");
            nombreTitular = Console.ReadLine();
            cuentaActual.NombreTitular = nombreTitular;
            
            while(true)
            {
                Console.WriteLine("\nIngrese el tipo de cuenta, digite el número de la opción (1,2):  \n" +
                                  "1. Ahorros. \n" +
                                  "2. Corriente.");
                
                var opcion = Console.ReadLine();
                if (opcion == "1")
                {
                    cuentaActual.TipoCuenta = "Ahorros";
                    cuentaActual.Saldo = 50000;
                    listo = true;
                    break;
                }
                else if (opcion == "2")
                {
                    cuentaActual.TipoCuenta = "Corriente";
                    cuentaActual.Saldo = 100000;
                    listo = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Error, la selección no se encuentra dentro del menú de opciones.");
                }
            }
            Console.WriteLine("\nLa cuenta ha sido creada satisfactoriamente.\nTitular: {0}, Tipo de Cuenta: {1}, Numero de la cuenta: {2}.",cuentaActual.NombreTitular,cuentaActual.TipoCuenta,cuentaActual.NumeroCuenta);
            
            //Menu Opciones Cuenta
            while(listo)
            {
                Console.WriteLine("\nDigite el número de la opción que desee seleccionar: \n" +
                                  "1.Retirar dinero \n" +
                                  "2.Consignar dinero \n" +
                                  "3.Ver saldo actual \n" +
                                  "4.Ver todos los detalles de la cuenta \n" +
                                  "5.Salir");
                
                var menuOpcion = Console.ReadLine();
                switch (menuOpcion)
                {
                    case "1": 
                        Console.WriteLine("\nIngrese la cantidad de dinero que quiere retirar, debe ser menor a: " + cuentaActual.Saldo + "$");
                        var retiro = float.Parse(Console.ReadLine());
                        
                        cuentaActual.retirarDinero(retiro);
                        break;
                    
                    case "2": 
                        Console.WriteLine("\nIngrese la cantidad de dinero que quiere consignar: ");
                        var consig = float.Parse(Console.ReadLine());
                        
                        cuentaActual.consignarDinero(consig);
                        break;
                    
                    case "3":
                        cuentaActual.verSaldo();
                        break;
                    
                    case "4":
                        cuentaActual.verTodosDatos();
                        break;
                    
                    case "5":
                        Console.WriteLine("\nGracias por usar nuestros servicios.");
                        listo = false;
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}