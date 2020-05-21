using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosProgramacion
{
    class Program
    {
        private static int suma;
        private static int multiplo;
        private static string frase;

        static void Main(string[] args)
        {
            char opcion;
            Console.WriteLine("Bienvenido al sistema");
            do
            {
                Console.WriteLine("\t*******************************************************");
                Console.WriteLine("\t* Digite el número                                  *");
                Console.WriteLine("\t* 1: Suma de los multiplos de 3 y 5                 *");
                Console.WriteLine("\t* 2: Funcion camel case                             *");
                Console.WriteLine("\t* 3: palabra mayor a 5 letras se tranforma al revés *");
                Console.WriteLine("\t* 0: Salir                                          *");
                Console.WriteLine("\t*******************************************************");
                Console.Write("Opcion: ");
                do
                {
                    opcion = Console.ReadKey(true).KeyChar;
                } while (opcion < '0');
                Console.WriteLine(opcion + "\n");

                switch (opcion)
                {
                    case '1':
                        int numero = 0;
                        Console.WriteLine("Ingrese numero entero positivo");
                        numero = Convert.ToInt32(Console.ReadLine());
                        int resultado = metodoMultiplos(numero);
                        Console.WriteLine($"La suma de los multiplos de 3 y 5 menor a {numero} es: " + resultado);

                        break;
                    case '2':

                        Console.WriteLine("Ingrese la frase");
                        frase = Console.ReadLine().ToString();
                        string resulCameCasel = metodoCameCasel(frase);
                        Console.WriteLine($"La frase con la función camel case es : { resulCameCasel } ");

                        break;
                    case '3':
                        Console.WriteLine("Ingrese la frase");
                        frase = Console.ReadLine();
                        string FraseAlreves = metodoPalabraAlReves(frase);
                        Console.WriteLine($"La tranformacion de la frase es: { FraseAlreves } ");
                        break;
                    default:
                        Console.WriteLine("ERROR. Digito un numero incorrecto");
                        break;
                }
            } while (opcion != '0');
        }
        public static int metodoMultiplos(int numero)
        {
            multiplo = 0;
            suma = 0;
            for (int i = 0; i < numero; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    multiplo = i;
                    if (multiplo < numero)
                        suma = suma + multiplo;
                    else break;
                }

            }
            return suma;
        }
        public static string metodoCameCasel(string word)
        {
            string CamelCaseWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ' || word[i] == '_' || word[i] == '-')
                {
                    i = i + 1;
                    CamelCaseWord = CamelCaseWord + char.ToUpper(word[i]);
                }
                else
                {
                    CamelCaseWord = CamelCaseWord + word[i];
                }
            }
            return CamelCaseWord;
        }

        public static string metodoPalabraAlReves(string word)
        {

            string invertedPhrase = "";
            string[] words = word.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 5)
                {
                    string wordToInvert = words[i];
                    string invertedWord = "";
                    for (int j = wordToInvert.Length - 1; j >= 0; j--)
                    {
                        invertedWord = invertedWord + wordToInvert[j];
                    }
                    invertedPhrase = invertedPhrase + " " + invertedWord;
                }
                else
                {
                    invertedPhrase = invertedPhrase + " " + words[i];
                }
            }
            return invertedPhrase;

        }
    }
}
