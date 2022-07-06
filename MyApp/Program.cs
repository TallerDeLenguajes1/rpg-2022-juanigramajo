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

opcionesDeUsuarioSegunGanador(ListadoDePersonajes, jugador1, jugador2, perdedor);




bool corroborarExistencia(List<Personaje> ListadoDePersonajes, Personaje personaje, int indice)
{
    bool bandera = true;

    for (int i = 0; i < ListadoDePersonajes.Count; i++)
    {
        if (personaje.datos.Nombre1 == ListadoDePersonajes[i].datos.Nombre1)
        {
            if (i == indice)
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
    int primeroEnAtacar = rand.Next(1, 3);

    if (primeroEnAtacar == 1)
    {
        Console.WriteLine($"\nComienza atacando el jugador 1 con {ListadoDePersonajes[jugador1].datos.Apodo1}");
    }
    else
    {
        Console.WriteLine($"\nComienza atacando el jugador 2 con {ListadoDePersonajes[jugador2].datos.Apodo1}");
    }

    for (int j = 0; j < 3; j++)
    {   
        if ((ListadoDePersonajes[jugador1].datos.Salud1 > 0) && (ListadoDePersonajes[jugador2].datos.Salud1 > 0))
        {    
            if (primeroEnAtacar == 1)
            {
                ListadoDePersonajes[jugador1].datos.Salud1 = combate.combate(ListadoDePersonajes[jugador2], ListadoDePersonajes[jugador1]);
                ListadoDePersonajes[jugador2].datos.Salud1 = combate.combate(ListadoDePersonajes[jugador1], ListadoDePersonajes[jugador2]);
            }
            else
            {
                ListadoDePersonajes[jugador2].datos.Salud1 = combate.combate(ListadoDePersonajes[jugador1], ListadoDePersonajes[jugador2]);
                ListadoDePersonajes[jugador1].datos.Salud1 = combate.combate(ListadoDePersonajes[jugador2], ListadoDePersonajes[jugador1]);
            }
        }
    }

    return corroborarPerdedor(ListadoDePersonajes[jugador1], ListadoDePersonajes[jugador2], jugador1, jugador2);
}

int corroborarPerdedor(Personaje jugador1, Personaje jugador2, int numEnListaJugador1, int numEnListaJugador2)
{
    if((jugador1.datos.Salud1 != 0)  &&  (jugador2.datos.Salud1 != 0))
    {
        if(jugador1.datos.Salud1 > jugador2.datos.Salud1)//gana el primer personaje
        {    
            jugador1.mejoraDeHabilidades(jugador1);
            return numEnListaJugador2;
        } else
        {  //gana el segundo personaje
            jugador2.mejoraDeHabilidades(jugador2);
            return numEnListaJugador1; 
        }
    }else
    {  //alguno o ambos tienen salud 0, pierde
        if((jugador1.datos.Salud1 == 0) && (jugador2.datos.Salud1 == 0))
        {   //hay un empate, si hace una batalla nuevamente
            return 9;
        } else
        {
            if(jugador1.datos.Salud1 == 0)
            {  //gana el segundo
                jugador2.mejoraDeHabilidades(jugador2);
                return numEnListaJugador1; 
            } else
            { //gana el primero
                jugador1.mejoraDeHabilidades(jugador1);
                return numEnListaJugador2;
            }
        }
    }
}

void opcionesDeUsuarioSegunGanador(List<Personaje> ListadoDePersonajes, int jugador1, int jugador2, int perdedor)
{
    if (ListadoDePersonajes.Count != 0)
    {    
        if (perdedor == jugador1)
        {
            Console.WriteLine($"\nJUGADOR 1 con {ListadoDePersonajes[jugador1].datos.Apodo1} ELIMINADOS");
            ListadoDePersonajes.Remove(ListadoDePersonajes[jugador1]);

            mostrarPersonajesDisponibles(ListadoDePersonajes);
            jugador1 = elegirPersonaje(1, ListadoDePersonajes.Count);
            if (jugador2 == ListadoDePersonajes.Count+1)
            {
                jugador2--;
            }
            perdedor = pelea(ListadoDePersonajes, jugador1, jugador2);  
            opcionesDeUsuarioSegunGanador(ListadoDePersonajes, jugador1, jugador2, perdedor);
        }
        else if (perdedor == jugador2)
        {
            Console.WriteLine($"\nJUGADOR 2 con {ListadoDePersonajes[jugador2].datos.Apodo1} ELIMINADOS");
            ListadoDePersonajes.Remove(ListadoDePersonajes[jugador2]);

            mostrarPersonajesDisponibles(ListadoDePersonajes);
            jugador2 = elegirPersonaje(2, ListadoDePersonajes.Count);
            if (jugador1 == ListadoDePersonajes.Count+1)
            {
                jugador1--;
            }
            perdedor = pelea(ListadoDePersonajes, jugador1, jugador2);
            opcionesDeUsuarioSegunGanador(ListadoDePersonajes, jugador1, jugador2, perdedor);
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
                opcionesDeUsuarioSegunGanador(ListadoDePersonajes, jugador1, jugador2, perdedor);
            }
            else
            {
                mostrarPersonajesDisponibles(ListadoDePersonajes);
                jugador1 = elegirPersonaje(1, ListadoDePersonajes.Count);
                jugador2 = elegirPersonaje(2, ListadoDePersonajes.Count);
                perdedor = pelea(ListadoDePersonajes, jugador1, jugador2);
                opcionesDeUsuarioSegunGanador(ListadoDePersonajes, jugador1, jugador2, perdedor);
            }
        }
    } else
    {
        Console.WriteLine("\nNo quedan personajes!");
    }
}