//Retroteca: alquiler de videojuegos retro

//Estadísticas de la sesión (no se borran entre alquileres)

int operacionesCobradas = 0;
double cobro = 0;
double importeMaximo = 0;
string clienteImporteMaximo = "";

int opcion;
do
{
    //Fase 0: menú principal
    Console.WriteLine("=== RETROTECA ===");
    Console.WriteLine("1. Nuevo alquiler");
    Console.WriteLine("2. Consultar caja");
    Console.WriteLine("3. Salir");
    opcion = int.Parse(Console.ReadLine());

    if(opcion == 1)
    {
        // Fase 1: nombre del cliente (no puede estar vacío ni solo espacios)
        string nombre;
        do
        {
            Console.Write("Nombre del cliente: ");
            nombre = (Console.ReadLine() ?? "").Trim();
            
            if (nombre == "")
            {
                Console.Write("El nombre no puede estar vacío: ");
            }

        } while (nombre == "");

        //Fase 2: producto principal
        
        int producto;
        do
        {
            Console.WriteLine("1. Juego 8/16 bits (3,50 €)");
            Console.WriteLine("2. Juego 32/64 bits (5,00 €)");
            Console.WriteLine("3. Game Boy con juego (7,00 €)");
            producto = int.Parse(Console.ReadLine());

            if(producto < 1 || producto > 3)
            {
                Console.WriteLine("Opción no válida");
            }

        } while(producto < 1 || producto > 3);

        string nomProducto = "";
        double costePrincipal = 0;
        
        switch (producto)
        {
            case 1:
                nomProducto = "Juego 8/16 bits";
                costePrincipal = 3.5;
                break;
            case 2:
                nomProducto = "Juego 32/64 bits";
                costePrincipal = 5;
                break;
            case 3:
                nomProducto = "Game Boy con juego";
                costePrincipal = 7;
                break;
  
        }





    }

}