// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");



List<Personaje> ListadoDePersonajes = new List<Personaje>();

for (int i = 0; i < 8; i++)
{
    Personaje personaje = new Personaje();
    personaje = personaje.cargarPersonajes();

    ListadoDePersonajes.Add(personaje);

    if ((ListadoDePersonajes.Count != 1))
    {
        // corroboro la existencia así no se crean personajes con nombres iguales
        while (corroborarExistencia(ListadoDePersonajes, personaje, i))
        {
            ListadoDePersonajes.Remove(personaje);
            personaje = personaje.cargarPersonajes();
            ListadoDePersonajes.Add(personaje);
        }
    }
}


// ACÁ INICIA EL JUEGO MOSTRANDO LOS PERSONAJES PARA SER SELECCIONADOS
mostrarPersonajesDisponibles(ListadoDePersonajes);
int jugador1 = elegirPersonaje(1, ListadoDePersonajes.Count);
int jugador2 = elegirPersonaje(2, ListadoDePersonajes.Count);
int perdedor = pelea(ListadoDePersonajes, jugador1, jugador2);

opcionesDeUsuarioSegunPerdedor(ListadoDePersonajes, jugador1, jugador2, perdedor);




bool corroborarExistencia(List<Personaje> ListadoDePersonajes, Personaje personaje, int indice)
{
    bool bandera = true;

    for (int i = 0; i < ListadoDePersonajes.Count; i++)
    {
        if (personaje.datos.Nombre1 == ListadoDePersonajes[i].datos.Nombre1)
        {
            if (i == indice) //si es el mismo nombre pero el mismo indice es porque el dato es el último agregado, no se repitió
            {
                bandera = false;
            } else
            {
                bandera = true;
                return bandera;
            }
        }
        else
        {
            bandera = false;
        }
    }

    return bandera;
}

void mostrarPersonajesDisponibles(List<Personaje> ListadoDePersonajes)
{
    Console.WriteLine("\nPERSONAJES DISPONIBLES\n");
    for (int i = 0; i < ListadoDePersonajes.Count; i++)
    {
        Console.Write($"[{i+1}]");
        ListadoDePersonajes[i].mostrarApodo();   
    }
    
}

int elegirPersonaje(int num, int cantPersonajes)
{
    Console.WriteLine($"\nJUGADOR [{num}] Escoja un personaje: ");
    int opcion = int.Parse(Console.ReadLine());

    //el switch cant personajes es un control para que el usuario no rompa el programa queriendo poner un número distinto a la cantidad de personajes
    switch (cantPersonajes)
    {
        case 1:
            while ((opcion < 1) || (opcion > 1))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 2:
            while ((opcion < 1) || (opcion > 2))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 3:
            while ((opcion < 1) || (opcion > 3))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 4:
            while ((opcion < 1) || (opcion > 4))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 5:
            while ((opcion < 1) || (opcion > 5))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 6:
            while ((opcion < 1) || (opcion > 6))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 7:
            while ((opcion < 1) || (opcion > 7))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 8:
            while ((opcion < 1) || (opcion > 8))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        default:
            break;
    }

    //el switch opción es para retornar el indice del personaje elegido, retorna de 0 a 8 porque son los elementos de la lista, caso de 1 a 8 porque así muestro los personajes
    switch (opcion)
    {
        case 1:
            return 0;
            break;
        case 2:
            return 1;
            break;
        case 3:
            return 2;
            break;
        case 4:
            return 3;
            break;
        case 5:
            return 4;
            break;
        case 6:
            return 5;
            break;
        case 7:
            return 6;
            break;
        case 8:
            return 7;
            break;
        default:
            break;
    }

    return 0;
}

int pelea(List<Personaje> ListadoDePersonajes, int jugador1, int jugador2)
{
    Combate combate = new Combate();
    Random rand = new Random();
    int primeroEnAtacar = rand.Next(1, 3); //número aleatorio para ver quien empieza la batalla

    if (primeroEnAtacar == 1)
    {
        Console.WriteLine($"\nComienza atacando el jugador 1 con {ListadoDePersonajes[jugador1].datos.Apodo1}");
    }
    else
    {
        Console.WriteLine($"\nComienza atacando el jugador 2 con {ListadoDePersonajes[jugador2].datos.Apodo1}");
    }

    for (int j = 0; j < 3; j++) //hasta 3 porque son 3 golpes que piden en la consigna
    {   
        if ((ListadoDePersonajes[jugador1].datos.Salud1 > 0) && (ListadoDePersonajes[jugador2].datos.Salud1 > 0)) //corroboro que tengan salud sino no tiene sentido seguir la batalla
        {    
            if (primeroEnAtacar == 1)
            {
                ListadoDePersonajes[jugador2].datos.Salud1 = combate.combate(ListadoDePersonajes[jugador1], ListadoDePersonajes[jugador2]); //ataca primero jugador 1, defiende jugador 2
                ListadoDePersonajes[jugador1].datos.Salud1 = combate.combate(ListadoDePersonajes[jugador2], ListadoDePersonajes[jugador1]); //ataca jugador 2, defiende jugador 1
            }
            else
            {
                ListadoDePersonajes[jugador1].datos.Salud1 = combate.combate(ListadoDePersonajes[jugador2], ListadoDePersonajes[jugador1]); //ataca primero jugador 2, defiende jugador 1
                ListadoDePersonajes[jugador2].datos.Salud1 = combate.combate(ListadoDePersonajes[jugador1], ListadoDePersonajes[jugador2]); //ataca jugador 1, defiende jugador 2
            }
        }
    }

    return corroborarPerdedor(ListadoDePersonajes[jugador1], ListadoDePersonajes[jugador2], jugador1, jugador2);
}

int corroborarPerdedor(Personaje jugador1, Personaje jugador2, int numEnListaJugador1, int numEnListaJugador2)
{
    if((jugador1.datos.Salud1 != 0)  &&  (jugador2.datos.Salud1 != 0)) //corroboro que ambos tengan algo de salud
    {
        if(jugador1.datos.Salud1 > jugador2.datos.Salud1) //gana el jugador 1
        {    
            jugador1.mejoraDeHabilidades(jugador1);
            return numEnListaJugador2; //retorno jugador 2 como perdedor
        } else //gana el jugador 2
        {
            jugador2.mejoraDeHabilidades(jugador2);
            return numEnListaJugador1; //retorno jugador 1 como perdedor
        }
    }else
    {
        if((jugador1.datos.Salud1 == 0) && (jugador2.datos.Salud1 == 0)) //si hay empate retorno un número cualquiera e insignificante
        {   
            return 9;
        } else
        {
            if(jugador1.datos.Salud1 == 0) //el jugador 1 no tiene vida, gana el jugador 2
            {
                jugador2.mejoraDeHabilidades(jugador2);
                return numEnListaJugador1; //retorno jugador 1 como perdedor
            } else //el jugador 2 no tiene vida, gana el jugador 1
            {
                jugador1.mejoraDeHabilidades(jugador1);
                return numEnListaJugador2; //retorno jugador 2 como perdedor
            }
        }
    }
}

void opcionesDeUsuarioSegunPerdedor(List<Personaje> ListadoDePersonajes, int jugador1, int jugador2, int perdedor)
{
    if (ListadoDePersonajes.Count != 1) //verifico que queden personajes en la lista para terminar la recursividad y el último que queda es el ganador
    {    
        if (perdedor == jugador1) //si coinciden los índices
        {
            Console.WriteLine($"\nJUGADOR 1 con {ListadoDePersonajes[jugador1].datos.Apodo1} ELIMINADOS");
            ListadoDePersonajes.Remove(ListadoDePersonajes[jugador1]);

            mostrarPersonajesDisponibles(ListadoDePersonajes);
            jugador1 = elegirPersonaje(1, ListadoDePersonajes.Count);
            if (jugador2 == ListadoDePersonajes.Count+1) //hago este control por si el personaje estaba en la última posición de la lista, ya que si se borra un elemento se borra el último índice
            {
                jugador2--;
            }
            perdedor = pelea(ListadoDePersonajes, jugador1, jugador2); //genero otra pelea
            opcionesDeUsuarioSegunPerdedor(ListadoDePersonajes, jugador1, jugador2, perdedor); //según el perdedor elijo nuevos personajes
        }
        else if (perdedor == jugador2) //si coinciden los índices
        {
            Console.WriteLine($"\nJUGADOR 2 con {ListadoDePersonajes[jugador2].datos.Apodo1} ELIMINADOS");
            ListadoDePersonajes.Remove(ListadoDePersonajes[jugador2]);

            mostrarPersonajesDisponibles(ListadoDePersonajes);
            jugador2 = elegirPersonaje(2, ListadoDePersonajes.Count);
            if (jugador1 == ListadoDePersonajes.Count+1) //hago este control por si el personaje estaba en la última posición de la lista, ya que si se borra un elemento se borra el último índice
            {
                jugador1--;
            }
            perdedor = pelea(ListadoDePersonajes, jugador1, jugador2); //genero otra pelea
            opcionesDeUsuarioSegunPerdedor(ListadoDePersonajes, jugador1, jugador2, perdedor); //según el perdedor elijo nuevos personajes
        }
        else
        {
            Console.Write("\nHUBO UN EMPATE\n¿Jugar con los mismos personajes?\nOPCIONES:\n[S] SI\n[N] NO\nElija una opción: ");
            int mismosPersonajes = Char.ToLower(Convert.ToChar(Console.ReadLine()));
            while ((mismosPersonajes != 's') && (mismosPersonajes != 'n'))
            {
                Console.Write("\nError de formato\nHUBO UN EMPATE\n¿Jugar con los mismos personajes?\nOPCIONES:\n[S] SI\n[N] NO\nElija una opción: ");
                mismosPersonajes = Char.ToLower(Convert.ToChar(Console.ReadLine()));
            }

            if (mismosPersonajes == 's')
            {
                perdedor = pelea(ListadoDePersonajes, jugador1+1, jugador2+1);
                opcionesDeUsuarioSegunPerdedor(ListadoDePersonajes, jugador1, jugador2, perdedor);
            }
            else
            {
                mostrarPersonajesDisponibles(ListadoDePersonajes);
                jugador1 = elegirPersonaje(1, ListadoDePersonajes.Count);
                jugador2 = elegirPersonaje(2, ListadoDePersonajes.Count);
                perdedor = pelea(ListadoDePersonajes, jugador1, jugador2);
                opcionesDeUsuarioSegunPerdedor(ListadoDePersonajes, jugador1, jugador2, perdedor);
            }
        }
    } else
    {
        Console.WriteLine("\nNo quedan personajes!");
    }
}