

public enum Tipos
{
    Vuela,
    PiedaDelInfinito,
    SueroSupersoldado,
    Magia,
    ArtesMarciales
}

public enum Nombres
{
    SteveRogers,
    TonyStark,
    NatashaRomanoff,
    BruceBanner,
    StephenStrange,
    WandaMaximoff,
    ClintBarton,
    PeterParker
}

public enum Apodos
{
    CaptainAmerica,
    IronMan,
    BlackWidow,
    Hulk,
    DrStrange,
    ScarletWich,
    Hawkeye,
    SpiderMan
}

public struct Caracteristicas
{
    private int Velocidad;
    private int Destreza;
    private int Fuerza;
    private int Nivel;
    private int Armadura;

    public int Velocidad1 { get => Velocidad; set => Velocidad = value; }
    public int Destreza1 { get => Destreza; set => Destreza = value; }
    public int Fuerza1 { get => Fuerza; set => Fuerza = value; }
    public int Nivel1 { get => Nivel; set => Nivel = value; }
    public int Armadura1 { get => Armadura; set => Armadura = value; }
}

public struct Datos
{
    private Tipos Tipo;
    private Nombres Nombre;
    private Apodos Apodo;
    private DateTime FechaNac;
    private int Edad;
    private int Salud;

    public Tipos Tipo1 { get => Tipo; set => Tipo = value; }
    public Nombres Nombre1 { get => Nombre; set => Nombre = value; }
    public Apodos Apodo1 { get => Apodo; set => Apodo = value; }
    public DateTime FechaNac1 { get => FechaNac; set => FechaNac = value; }
    public int Edad1 { get => Edad; set => Edad = value; }
    public int Salud1 { get => Salud; set => Salud = value; }
}


public class Personaje
{
    public Datos datos;
    public Caracteristicas caracteristicas;



    DateTime Now = DateTime.Today;
    public int Edad = 0;
    public int calcularEdad(DateTime fechaNac)
    {
        Edad = Now.Year - fechaNac.Year;

        if(fechaNac.Month > Now.Month)
        {
            Edad = Edad-1;
        }

        return Edad;
    }

    public Personaje cargarPersonajes()
    {
        Personaje NPersonaje = new Personaje();
        Random rand = new Random();


        NPersonaje.caracteristicas.Velocidad1 = rand.Next(1, 11);
        NPersonaje.caracteristicas.Destreza1 = rand.Next(1, 6);
        NPersonaje.caracteristicas.Fuerza1 = rand.Next(1, 11);
        NPersonaje.caracteristicas.Nivel1 = rand.Next(1, 11);
        NPersonaje.caracteristicas.Armadura1 = rand.Next(1, 11);
        
        int dato = rand.Next(1, 9);

        switch (dato)
        {
        case 1:
            NPersonaje.datos.Tipo1 = Tipos.SueroSupersoldado;
            NPersonaje.datos.Nombre1 = Nombres.SteveRogers;
            NPersonaje.datos.Apodo1 = Apodos.CaptainAmerica;
            break;
        case 2:
            NPersonaje.datos.Tipo1 = Tipos.Vuela;
            NPersonaje.datos.Nombre1 = Nombres.TonyStark;
            NPersonaje.datos.Apodo1 = Apodos.IronMan;
            break;
        case 3:
            NPersonaje.datos.Tipo1 = Tipos.ArtesMarciales;
            NPersonaje.datos.Nombre1 = Nombres.NatashaRomanoff;
            NPersonaje.datos.Apodo1 = Apodos.BlackWidow;
            break;
        case 4:
            NPersonaje.datos.Tipo1 = Tipos.SueroSupersoldado;
            NPersonaje.datos.Nombre1 = Nombres.BruceBanner;
            NPersonaje.datos.Apodo1 = Apodos.Hulk;
            break;
        case 5:
            NPersonaje.datos.Tipo1 = Tipos.Magia;
            NPersonaje.datos.Nombre1 = Nombres.StephenStrange;
            NPersonaje.datos.Apodo1 = Apodos.DrStrange;
            break;
        case 6:
            NPersonaje.datos.Tipo1 = Tipos.PiedaDelInfinito;
            NPersonaje.datos.Nombre1 = Nombres.WandaMaximoff;
            NPersonaje.datos.Apodo1 = Apodos.ScarletWich;
            break;
        case 7:
            NPersonaje.datos.Tipo1 = Tipos.ArtesMarciales;
            NPersonaje.datos.Nombre1 = Nombres.ClintBarton;
            NPersonaje.datos.Apodo1 = Apodos.Hawkeye;
            break;
        case 8:
            NPersonaje.datos.Tipo1 = Tipos.ArtesMarciales;
            NPersonaje.datos.Nombre1 = Nombres.PeterParker;
            NPersonaje.datos.Apodo1 = Apodos.SpiderMan;
            break;
        default:
            break;
        }

        NPersonaje.datos.FechaNac1 = new DateTime(rand.Next(1710, 2011), rand.Next(1, 13), rand.Next(1, 29));

        NPersonaje.datos.Edad1 = NPersonaje.calcularEdad(NPersonaje.datos.FechaNac1);

        NPersonaje.datos.Salud1 = 100;

        return NPersonaje;
    }

    public void mostrarDatos()
    {
        Console.WriteLine("\n\n----------PERSONAJE----------");
        Console.WriteLine("Tipo: " + datos.Tipo1);
        Console.WriteLine("Nombre: " +  datos.Nombre1);
        Console.WriteLine("Apodo: " + datos.Apodo1);
        Console.WriteLine("Fecha de nacimiento: " + datos.FechaNac1.ToShortDateString());
        Console.WriteLine($"Edad: [{datos.Edad1}] años");
        Console.WriteLine($"Salud: [{datos.Salud1}] vida/s");
        Console.WriteLine($"Velocidad: [{caracteristicas.Velocidad1}] km/h");
        Console.WriteLine($"Destreza: [{caracteristicas.Destreza1}]");
        Console.WriteLine($"Fuerza: [{caracteristicas.Fuerza1}]");
        Console.WriteLine($"Nivel: [{caracteristicas.Nivel1}]");
        Console.WriteLine($"Armadura: [{caracteristicas.Armadura1}]");
    } 

    public void mostrarApodo()
    {
        Console.WriteLine(datos.Apodo1);
    }

    public void mejoraDeHabilidades(Personaje ganador){
        if (ganador.datos.Salud1 == 100)
        {
            Random rand = new Random();
            int agregarFuerza = rand.Next(5, 11);
            ganador.caracteristicas.Fuerza1 = ganador.caracteristicas.Fuerza1 + (ganador.caracteristicas.Fuerza1 / agregarFuerza);
        } else
        {
            ganador.datos.Salud1 = ganador.datos.Salud1 + (ganador.datos.Salud1 / 10);
            if (ganador.datos.Salud1 > 100)
            {
                ganador.datos.Salud1 = 100;
            }
        }
    }

}