# rpg-2022-juanigramajo

Bueno basicamente el juego es así:
- Si no hay cargados personajes en el JSON:
Se crean 8 personajes con características y datos aleatorios.
- Si hay cargados personajes en el JSON:
El usuario elije jugar con los del JSON o crear nuevos.
Ademas se le pregunta si quiere editar la lista anterior de personajes en el JSON

- Se juega de a dos personas.
- Los jugadores no pueden repetir el personaje.
- Si el personaje muere, hace que el jugador perdedor elija otro con los que van quedando.
- Cuando queda 1 solo personaje lo muestra como ganador y la cantidad de vidas que le quedaron.
- Además, con la API muestro información del personaje ganador, su descripción y en cuantos comics de MARVEL aparece.





Datos del código:
- Para crear el JSON tuve que editar un par de variables del personaje.
- Cuando creo el JSON, el tipo nombre y apodo del personaje se guarda con enteros porque uso enums para esa carga.