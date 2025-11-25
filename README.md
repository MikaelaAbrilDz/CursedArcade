El proyecto consiste en un juego al estilo Pokémon Mundo Misterioso, pero con una ambientación de Arcade y en 3D.

Hay una serie de turnos y un mundo creado en base a casillas.

## Casillas

Cada casilla referencia las 4 casillas que la rodean horizontal y verticalmente al inicio de la partida. Para hacer esto, se usa este método dentro del script Checker, incluido en cada una de las casillas.

![](/ReadmeContent/Code_SetSideCheckers.PNG)

Se asignan las casillas en un array en el que se colocan en el orden de las agujas del reloj.

El sistema de array para las referencias de las casillas permite almacenar direcciones como un único int o incluso invertir la dirección con la fórmula: (("int de la dirección actual" + 2) % 4).

## Clases para la interacción con las casillas

Partiendo del sistema base de de casillas, existe BasicEntity, que es la clase de la que heredan todos los scripts de entidades que se van a mover en el sistema de casillas, desde personajes hasta objetos.

De BasicEntity heredan CharacterOnGround y ObjectOnGround.

### CharacterOnGround

Empezando por CharacterOnGround, esta clase contiene esencialmente el método para el movimiento.

El método de movimiento tiene un único parámetro que es el int de la dirección a moverse.

![](/ReadmeContent/Code_Movement.PNG)

El método devuelve true o false dependiendo de si el movimiento se ha podido realizar o no.

Este método es usado tanto por la IA de enemigos como por los inputs del player.

El resultado, junto a animaciones y la mencionada IA de los enemigos es este.

![](/ReadmeContent/Movement.gif)

El player es el cubo verde y los enemigos son los niños.

### ObjectOnGround

## Pathfinding e IA de enemigos

Hay una sola IA de enemigo ahora mismo, que es la del niño (la idea es hacer 1 o 2 más).

También está la clase EnemyAI, de la que heredan todas las IAs concretas de enemigos y que tiene el pathfinding y algunos métodos más.

Empezando por el pathfinding, usa recursividad para buscar a un target (que se define por su clase, pudiendo ser player, un tipo de enemigo en concreto o incluso un objeto).

![](/ReadmeContent/Code_Pathfinding.PNG)

El método recursivo devuelve los pasos que sobran en el camino más corto y asigna el primer paso de dicho camino a una variable int.

Este método sirve tanto para buscar al player por parte de los enemigos, como para ver si hay algo en sus inmediaciones.

Por ejemplo, el enemigo niño huye del player, a menos que encuentre a un otro enemigo niño cerca, en cuyo caso persigue al player.

![](/ReadmeContent/Code_KidAI.PNG)

En este método, se comprueba que hay un camino posible hasta algún enemigo de tipo niño y si no lo hay, huye.

El resultado es el siguiente.

![](/ReadmeContent/EnemyKidAI.gif)

Este método usa métodos de EnemyAI que usan el método de pathfinding junto a otros métodos para generar acciones algo más complejas.

## Preparación del mundo al iniciar partida

Pese a que el mapa del mundo (que aún no se ha creado) será estático, los objetos y enemigos en él se generarán aleatoriamente en cada partida.

Ambos spawnearán al principio de la partida mediante este script, que ahora mismo solo está funcionando para los objetos.

![](/ReadmeContent/Code_ObjSpawn.PNG)

Esto spawnea un objeto en una de cada diez casillas (proporción por determinar).

## Objetos

Actualmente el juego cuenta con 2 objetos.
    Punch: Aumenta 0.2 los golpes
    HealthKit: Al activarse cura 20 de salud
