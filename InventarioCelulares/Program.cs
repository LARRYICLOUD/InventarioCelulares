using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioCelulares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("YO SOY UN PROGRAMADOR Y EXPERTO EN REDES EXCELENTE Y RECONOCIDO");

            bool repetir = true; //Se encarga de repetir el menu hasta que nosotros decidamos salir del programa
            int opcion;


            Inventario  inventario = new Inventario();

            do
            {
                Console.Clear();
                Console.WriteLine("\n CELULARES LARRYSALSA\n");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Mostrar inventario");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Salir");

                Console.Write("Ingresa una opcion");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        inventario.AgregarProducto();
                        break;
                        case 2:
                        //Mostrar inventario
                        inventario.MostrarProducto();
                        break;
                        case 3:
                        inventario.EliminarProducto();
                        break;
                        case 4: //Finalizar el programa
                        repetir = false;  //El bucle se repite mientras "repetir == true" por lo tanto esta instruccion nos sacara del programa
                         break;

                    default:
                        Console.WriteLine("\n¡Opcion invalida, intenta de nuevo!\n");
                        break;

                }        

            } while (repetir); 

            
        }
    }
    struct Celular
    {
        //Campos
        string marca;
        string modelo;
        int memoriaPrincipal;
        double precio;
        int stock;

        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int MemoriaPrincipal { get => memoriaPrincipal; set => memoriaPrincipal = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }


    } //Fin struct Celular

    class Inventario
    {
        //Crea una lista de productos para almacenar el inventario
        List<Celular> listaCelulares = new List<Celular>();

        //Metodos
        public void AgregarProducto() // Metodo
        {

            //Creamos un producto (objeto) de tip celular
            Celular nuevoProducto = new Celular();

            //Limpiamos la consola y colocamos un titulo
            Console.Clear();
            Console.WriteLine("\n\t\tAgregar producto\n");

            //Preguntamos los valores que tendra el  producto y se los asignamos
            Console.Write("Marca: ");
            nuevoProducto.Marca = Console.ReadLine();

            Console.Write("Modelo: ");
            nuevoProducto.Modelo = Console.ReadLine();

            Console.Write("Memoria: ");
            nuevoProducto.MemoriaPrincipal =Convert.ToInt32(Console.ReadLine());

            Console.Write("Precio: ");
            nuevoProducto.Precio = Convert.ToDouble(Console.ReadLine());

            Console.Write("Stock: ");
            nuevoProducto.Stock = Convert.ToInt32(Console.ReadLine());

            //Agregamos el producto "Celular" al inventario (List)
            listaCelulares.Add(nuevoProducto);

            Console.Write(" Producto agregado al inventario. Presiona cualquier tecla para continuar...");
            Console.ReadKey();

        }//Fin Agregarproducto

        public void MostrarProducto()
        {
            Console.Clear();
            if(listaCelulares.Count == 0)
            {
                Console.WriteLine("¡El inventario esta vacio!");
            }
            else
            {
                int indice = 1;
                Console.WriteLine("¡El inventario de producto: \n");

                foreach( var elemento in listaCelulares)
                {
                    Console.WriteLine($"{indice}.- Marca: {elemento.Marca}, Modelo: {elemento.Modelo}, Memoria. {elemento.MemoriaPrincipal}, precio. ${elemento.Precio}, Stock: {elemento.Stock},");
                    indice++;

                }//fin foreach

            }//fin else

            Console.Write("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }//fin mostrarProducto

        public void EliminarProducto()
        {
            //Variable para indicar el indice del producto a eliminar
            int productoEliminar;
            Console.Clear();
            if(listaCelulares.Count == 0)
            {
                Console.WriteLine("¡El inventario esta vacio, no hay nada que eliminar");
            }
            else
            {
                Console.Write($"Ingresa el numero de producto (indice) que deseas eliminar (del 1 al {listaCelulares.Count}): ");
                productoEliminar = Convert.ToInt32(Console.ReadLine()) - 1; //Decimos que es -1 para que el indice ingresado coincida con el indice real de la List
                //Verificamos que el numero ingresado sea valido
                if(productoEliminar >= 0  && productoEliminar < listaCelulares.Count)
                {

                    //Confirmamos que el producto ingresado es el que desea eliminar
                    Console.Write($"¿El producto que desea eliminar es: \"{listaCelulares[productoEliminar].Marca} {listaCelulares[productoEliminar].Modelo}\"? (Si/No): ");
                    string opcion = Console.ReadLine().ToLower();

                    if(opcion == "si")
                    {
                        //Variables para mostrar un mensaje de cual fue ek celular eliminado
                        string marcaEliminado = listaCelulares[productoEliminar].Marca;
                        string modeloEliminado = listaCelulares[productoEliminar].Modelo;

                        //Eliminamos el producto
                        listaCelulares.RemoveAt(productoEliminar);

                        //Le mostramos al usuario el celular que se elimino
                        Console.WriteLine($"\n¡El producto \"{marcaEliminado} {modeloEliminado}\" fue eliminado");
                    }
                    else
                    {
                        Console.WriteLine("Operacion \"eliminar producto\" cancelada ");


                    }

                }
                else
                {
                    Console.WriteLine("el numero del producto no es valido, revisa la lista e intenta nuevamente!");


                }

            }
            Console.WriteLine("\nPresiona cualquier tecla para cintinuar");
            Console.ReadKey();

        }



    }


}
