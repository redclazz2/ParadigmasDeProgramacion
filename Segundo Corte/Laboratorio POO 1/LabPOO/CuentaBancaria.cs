using System;

namespace LabPOO
{
    public class CuentaBancaria
    {
        //Atributos
        private int numeroCuenta;
        private float saldo;
        private string nombreTitular, tipoCuenta;
        
        //Definición de Get y Set 
        public string NombreTitular
        {
            get { return nombreTitular; }
            set { nombreTitular = value; }
        }

        public string TipoCuenta
        {
            get { return tipoCuenta; }
            set { tipoCuenta = value; }
        }

        public float Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public int NumeroCuenta 
        {
            get { return numeroCuenta; }
        }
        
        //Constructor de la clase
        public CuentaBancaria()
        {
            //Por medio de la clase random se genera el número de cuenta
            Random rnd = new Random();
            numeroCuenta = rnd.Next(10000000, 99999999);
        }
        
        //Métodos
        //Retirar Dinero
        public void retirarDinero(float valorRetiro)
        {
            if (valorRetiro > this.saldo)
            {
                Console.WriteLine("Error, El saldo de la cuenta es insuficiente.");
            }
            else
            {
                this.saldo -= valorRetiro;
                Console.WriteLine("El saldo de la cuenta después del retiro es: " + saldo + "$");
            }
        }
        //Consignar Dinero
        public void consignarDinero(float valorConsig)
        {
            if (valorConsig > 0)
            {
                this.saldo += valorConsig;
                Console.WriteLine("El saldo de la cuenta después de la consignación es: " + saldo + "$");
            }
            else
            {
                Console.WriteLine("Error, entrada inválida");
            }
        }
        //Ver Saldo Actual
        public void verSaldo()
        {
            Console.WriteLine("El saldo actual de la cuenta es: " + saldo + "$");
        }
        
        //Ver Todos los datos de la cuenta
        public void verTodosDatos()
        {
            Console.WriteLine("Los datos de la cuenta son: \n" +
                              "Titular: {0} \n" +
                              "Tipo de Cuenta: {1} \n" +
                              "Número de Cuenta: {2} \n" +
                              "Saldo: {3}$ \n", nombreTitular,tipoCuenta,numeroCuenta,saldo);         
        }
    }
}