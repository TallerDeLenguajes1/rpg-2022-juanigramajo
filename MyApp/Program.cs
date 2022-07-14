// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

int indefinido = 999;


List<Personaje> ListadoDePersonajes = new List<Personaje>();

string PathCarpeta = "ganadores.csv";

if (!File.Exists(PathCarpeta))
{
    File.Create(PathCarpeta);
}


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
mostrarHistorialDeCombates();

Console.WriteLine("\n\nAhora si, a jugar...");
mostrarPersonajesDisponibles(ListadoDePersonajes);
int jugador1 = elegirPersonaje(1, ListadoDePersonajes.Count, indefinido);
int jugador2 = elegirPersonaje(2, ListadoDePersonajes.Count, jugador1);
int perdedor = pelea(ListadoDePersonajes, jugador1, jugador2);

Personaje ganador = opcionesDeUsuarioSegunPerdedor(ListadoDePersonajes, jugador1, jugador2, perdedor);
mostrarGanador(ganador);
mostrarHistorialDeCombates();



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
        Console.Write($"[{i}]");
        ListadoDePersonajes[i].mostrarApodo();   
    }
}

int elegirPersonaje(int num, int cantPersonajes, int personajeElegido)
{
    Console.WriteLine($"\nJUGADOR [{num}] Escoja un personaje: ");
    int opcion = int.Parse(Console.ReadLine());

    //el switch cant personajes es un control para que el usuario no rompa el programa queriendo poner un número distinto a la cantidad de personajes
    switch (cantPersonajes)
    {
        case 1:
            while ((opcion < 0) || (opcion > 0))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 2:
            while ((opcion < 0) || (opcion > 1))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 3:
            while ((opcion < 0) || (opcion > 2))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 4:
            while ((opcion < 0) || (opcion > 3))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 5:
            while ((opcion < 0) || (opcion > 4))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 6:
            while ((opcion < 0) || (opcion > 5))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 7:
            while ((opcion < 0) || (opcion > 6))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        case 8:
            while ((opcion < 0) || (opcion > 7))
            {
                Console.WriteLine($"\nError de formato.\nJUGADOR [{num}] Escoja un personaje: ");
                opcion = int.Parse(Console.ReadLine());
            }
            break;
        default:
            break;
    }

    while (opcion == personajeElegido)
    {
        Console.WriteLine($"\nEl personaje ya fue elegido.\nJUGADOR [{num}] Escoja un personaje: ");
        opcion = int.Parse(Console.ReadLine());
    }

    //el switch opción es para retornar el indice del personaje elegido, retorna de 0 a 8 porque son los elementos de la lista, caso de 1 a 8 porque así muestro los personajes
    switch (opcion)
    {
        case 0:
            return 0;
            break;
        case 1:
            return 1;
            break;
        case 2:
            return 2;
            break;
        case 3:
            return 3;
            break;
        case 4:
            return 4;
            break;
        case 5:
            return 5;
            break;
        case 6:
            return 6;
            break;
        case 7:
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

Personaje opcionesDeUsuarioSegunPerdedor(List<Personaje> ListadoDePersonajes, int jugador1, int jugador2, int perdedor)
{
    if (perdedor == jugador1) //si coinciden los índices
    {
        Console.WriteLine($"\nJUGADOR 1 con {ListadoDePersonajes[jugador1].datos.Apodo1} ELIMINADOS");

        string linea = $"{ListadoDePersonajes[jugador1].datos.Apodo1} VS {ListadoDePersonajes[jugador2].datos.Apodo1} | GANADOR: {ListadoDePersonajes[jugador2].datos.Apodo1} con [{ListadoDePersonajes[jugador2].datos.Salud1}] vidas restantes\n";
        File.AppendAllText(PathCarpeta, linea);

        if ((jugador1 == 0) || (jugador2 > jugador1)) //hago este control por si el personaje estaba en la primera posición de la lista, ya que si se borra el elemento se cambia el próximo índice O SINO por si el jugador que queda estaba por encima del jugador a eliminar en la lista
        {
            jugador2--;
        }

        ListadoDePersonajes.Remove(ListadoDePersonajes[jugador1]);

        if (ListadoDePersonajes.Count == 1)
        {
            Console.WriteLine("\n\n\n¡No quedan personajes!");
            return ListadoDePersonajes[0];
        }
        mostrarPersonajesDisponibles(ListadoDePersonajes);
        
        if (jugador2 == ListadoDePersonajes.Count) //hago este control por si el personaje estaba en la última posición de la lista, ya que si se borra un elemento se borra el último índice
        {
            jugador2--;
        }
        if (jugador1 == ListadoDePersonajes.Count) //hago este control por si el personaje estaba en la última posición de la lista, ya que si se borra un elemento se borra el último índice
        {
            jugador1--;
        }

        jugador1 = elegirPersonaje(1, ListadoDePersonajes.Count, jugador2);

        perdedor = pelea(ListadoDePersonajes, jugador1, jugador2); //genero otra pelea
        opcionesDeUsuarioSegunPerdedor(ListadoDePersonajes, jugador1, jugador2, perdedor); //según el perdedor elijo nuevos personajes
    }
    else if (perdedor == jugador2) //si coinciden los índices
    {
        Console.WriteLine($"\nJUGADOR 2 con {ListadoDePersonajes[jugador2].datos.Apodo1} ELIMINADOS");

        string linea = $"{ListadoDePersonajes[jugador1].datos.Apodo1} VS {ListadoDePersonajes[jugador2].datos.Apodo1} | GANADOR: {ListadoDePersonajes[jugador1].datos.Apodo1} con [{ListadoDePersonajes[jugador1].datos.Salud1}] vidas restantes\n";
        File.AppendAllText(PathCarpeta, linea);

        if ((jugador2 == 0) || (jugador1 > jugador2)) //hago este control por si el personaje estaba en la primera posición de la lista, ya que si se borra el elemento se cambia el próximo índice O SINO por si el jugador que queda estaba por encima del jugador a eliminar en la lista
        {
            jugador1--;
        }

        ListadoDePersonajes.Remove(ListadoDePersonajes[jugador2]);

        if (ListadoDePersonajes.Count == 1)
        {
            Console.WriteLine("\n\n\n¡No quedan personajes!");
            return ListadoDePersonajes[0];
        }
        mostrarPersonajesDisponibles(ListadoDePersonajes);
        
        if (jugador1 == ListadoDePersonajes.Count) //hago este control por si el personaje estaba en la última posición de la lista, ya que si se borra un elemento se borra el último índice
        {
            jugador1--;
        }

        if (jugador2 == ListadoDePersonajes.Count) //hago este control por si el personaje estaba en la última posición de la lista, ya que si se borra un elemento se borra el último índice
        {
            jugador2--;
        }

        jugador2 = elegirPersonaje(2, ListadoDePersonajes.Count, jugador1);
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
            perdedor = pelea(ListadoDePersonajes, jugador1, jugador2);
            opcionesDeUsuarioSegunPerdedor(ListadoDePersonajes, jugador1, jugador2, perdedor);
        }
        else
        {
            mostrarPersonajesDisponibles(ListadoDePersonajes);
            jugador1 = elegirPersonaje(1, ListadoDePersonajes.Count, indefinido);
            jugador2 = elegirPersonaje(2, ListadoDePersonajes.Count, jugador1);
            perdedor = pelea(ListadoDePersonajes, jugador1, jugador2);
            opcionesDeUsuarioSegunPerdedor(ListadoDePersonajes, jugador1, jugador2, perdedor);
        }
    }

    return ListadoDePersonajes[0];
}

void mostrarGanador(Personaje Ganador)
{
    Console.WriteLine("\n----------EL GANADOR ES----------");
    Console.WriteLine($"\n         {Ganador.datos.Apodo1}");
    Console.WriteLine($"\nCon un total de {Ganador.datos.Salud1} vidas\n\n");

    string linea = $"\nGANADOR: {Ganador.datos.Apodo1} con [{Ganador.datos.Salud1}] vidas restantes\n\n";
    File.AppendAllText(PathCarpeta, linea);
}

void mostrarHistorialDeCombates()
{
    Console.WriteLine("\n¿Desea ver el historial de combates de este juego?\nOPCIONES\n[S] Si\n[N] No\nIngrese una opción: ");
    char salida = Char.ToLower(Convert.ToChar(Console.ReadLine()));
    while ((salida != 's') && (salida != 'n'))
    {
        Console.WriteLine("\nError de formato.\n¿Desea ver el historial de combates de este juego?\nOPCIONES\n[S] Si\n[N] No\nIngrese una opción: ");
        salida = Char.ToLower(Convert.ToChar(Console.ReadLine()));
    }

    if (salida == 's')
    {
        Console.WriteLine("\n\n");

        List<string> LineasDelArchivo = File.ReadAllLines(PathCarpeta).ToList();

        foreach (string Linea in LineasDelArchivo)
        {
            Console.WriteLine(Linea);
        }
    }
}