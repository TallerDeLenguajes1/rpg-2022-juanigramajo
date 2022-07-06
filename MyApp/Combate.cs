

public class Combate{

    private int pD;  // Poder de disparo
    private int eD;  // Efectividad de disparo
    private float vA;  // Valor de ataque
    private int pDEF;  // Poder de defensa
    private int mDP;  // Máximo daño provocable
    private float dP;  // Daño provocado

    public int PD { get => pD; set => pD = value; }
    public int ED { get => eD; set => eD = value; }
    public float VA { get => vA; set => vA = value; }
    public int PDEF { get => pDEF; set => pDEF = value; }
    public int MDP { get => mDP; set => mDP = value; }
    public float DP { get => dP; set => dP = value; }



    public int combate(Personaje atacante, Personaje defensor){
        
        PD = atacante.caracteristicas.Destreza1 * atacante.caracteristicas.Fuerza1 * atacante.caracteristicas.Nivel1;

        Random rand = new Random();
        ED = rand.Next(1,100);

        VA = (PD * ED) / 100;

        PDEF = defensor.caracteristicas.Armadura1 * defensor.caracteristicas.Velocidad1;

        MDP = 50000;
        
        DP = ((VA * ED - PDEF) / MDP) * 100;

        defensor.datos.Salud1 = defensor.datos.Salud1 - Convert.ToInt32(DP);

        return defensor.datos.Salud1;
    }
}