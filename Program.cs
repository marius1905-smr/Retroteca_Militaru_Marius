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

        //Fase 3: extras (cada uno solo una vez, por eso uso bool)
        bool limpieza = false;
        bool mando = false;
        bool manual = true;
        int extras = 0;
        double importeExtras = 0;
        
        int opcionExtra;
        do
        {
            Console.WriteLine($"Extras; {extras} | Importe: {importeExtras.ToString("F2")}€ ");
            Console.WriteLine("1. Limpieza del cartucho (1,50€)");
            Console.WriteLine("2. Mando adicional (2,50€)");
            Console.WriteLine("3. Manual y caja (1,00€)");
            Console.WriteLine("4. Terminar");
            opcionExtra = int.Parse(Console.ReadLine());

            switch (opcionExtra)
            {
                case 1:
                    if (limpieza)
                    {
                        Console.WriteLine("Ya has añadido la limpieza");
                    }
                    else
                    {
                        limpieza = true;
                        extras++;
                        importeExtras += 1.5;
                    }
                    break;
                case 2:
                    if (mando)
                    {
                        Console.WriteLine("Ya has añadido el mando");
                    }
                    else
                    {
                        mando = true;
                        extras++;
                        importeExtras += 2.5;
                    }
                    break;
                case 3:
                    if (manual)
                    {
                        Console.WriteLine("Ya has añadido el manual");
                    }
                    else
                    {
                        manual = true;
                        extras++;
                        importeExtras += 1.0;
                    }
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }   
                
        } while (opcionExtra != 4);

        //Fase 4: recogida o domicilio

        int entrega;
        do
        {
            Console.WriteLine("1. Recogida en tienda");
            Console.WriteLine("2. Entrega a domicilio (+3,00€)");
            entrega = int.Parse(Console.ReadLine());

            if(entrega < 1 || entrega > 2)
            {
                Console.WriteLine("Opción no válida");
            }
        } while (entrega < 1 || entrega > 2);

        double suplemento = 0;
        string direccion = "";
        if (entrega == 2)
        {
            suplemento = 3;
            do
            {
                Console.Write("Dirección de entrega:");
                direccion = (Console.ReadLine() ?? "").Trim();

                if (direccion == "")
                {
                    Console.WriteLine("La dirección no puede estar vacia");

                }

            } while (direccion == "");
        }

        // Fase 5: cálculo (descuento del 10% si el subtotal llega a 10)

        double subtotal = costePrincipal + importeExtras;
        double descuento = 0;
        if (subtotal >= 10)
        {
            descuento = subtotal * 0.1;
            
        }
        double total = subtotal - descuento + suplemento;
        if (total < 0)
        {
            total = 0;
        }

        Console.WriteLine("Subtotal: " + subtotal.ToString("F2") + " €");
        Console.WriteLine("Descuento: " + descuento.ToString("F2") + " €");
        Console.WriteLine("Suplemento: " + suplemento.ToString("F2") + " €");
        Console.WriteLine("Total: " + total.ToString("F2") + " €");

        // Fase 6: pago y cambio (se pide una vez y se repite mientras no llegue)

        Console.WriteLine("Dinero entregado: ");
        double dineroEntregado = double.Parse(Console.ReadLine());
        while (dineroEntregado < total)
        {
            Console.WriteLine("Pago insuficiente. Faltan " + (total - dineroEntregado).ToString("F2") + " €");
            Console.WriteLine("Dinero entregado: ");
            dineroEntregado = double.Parse(Console.ReadLine());
        }
        double cambio = dineroEntregado - total;

        //Fase 7: contabilizar (una sola vez)
        operacionesCobradas++;
        cobro += total;
        if (operacionesCobradas == 1 || total > importeMaximo)
        {
            importeMaximo = total;
            clienteImporteMaximo = nombre;
        }
        
        //Fase 8: ticket
        Console.WriteLine("TICKET Nº " + operacionesCobradas);
        Console.WriteLine("Cliente" + nombre);
        Console.WriteLine("Producto" + nomProducto);

        if (extras == 0)
        {
            Console.WriteLine("Extras: ninguno");
        }
        else
        {
            if (limpieza)
            {
                Console.WriteLine("Extra: limpieza del cartucho");
            }
            if (mando)
            {
                Console.WriteLine("Extra: mando adicional");
            }
            if (manual)
            {
                Console.WriteLine("Extra: manual y caja");
            }
        }

        if(entrega == 1)
        {
            Console.WriteLine("Recogida en tienda");
        }
        else
        {
            Console.WriteLine("Entrega a domicilio en; " + direccion);
        } 
        Console.WriteLine("Precio principal: " + costePrincipal.ToString("F2") + " €");
        Console.WriteLine("Extras: " + extras.ToString("F2") + " €");
        Console.WriteLine("Descuento: " + descuento.ToString("F2") + " €");
        Console.WriteLine("Suplemento: " + suplemento.ToString("F2") + " €");
        Console.WriteLine("Total: " + total.ToString("F2") + " €");
        Console.WriteLine("Entregado: " + dineroEntregado.ToString("F2") + " €");
        Console.WriteLine("Cambio: " + cambio.ToString("F2") + " €");
    }

} while(opcion != 3);