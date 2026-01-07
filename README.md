Integrantes:

Mika Ibáñez - MikaelaAbrilDz

Raúl Bertullo - RaulBertullo

Aroa Navarro - arnamo230

Hugo Enríquez - RompeTibias

María Belloch - mariabelloch


El proyecto consiste en un juego al estilo Pokémon Mundo Misterioso, pero con una ambientación de Arcade y en 3D.

Hay una serie de turnos y un mundo creado en base a casillas.

## Uso de probabilidad

Antes de nada, se ha usado la probabilidad normal en varios scripts, pero como ejemplo se usará la implementación en el script CharacterOnGround, en la corrutina AtackCo.

Se usa para calcular el daño que hace cualquier ataque, ya que esta clase es padre de todos los personajes, tanto enemigos como jugador y esta corrutina es usada por todos
ellos con distintos parámetros para atacar.

En base al valor de ataque del personaje usado como media, se hace una desviación estándar dependiendo del ataque, que normalmente ha sido de 2 o 3, dependiendo del ataque
específico. Esto ha hecho que el daño de los ataques no sea completamente predecible.

![](/ReadmeContent/NormalDistributionDamage.gif)

En el gif se puede ver como cada ataque hace un daño sutilmente diferente. (El ataque base del enemigo es de 8 y el del jugador es de 7, pero tiene un multiplicador de x1.2
tras aplicar la distribucución normal.)

## Algoritmo voraz

También hemos implementado un algoritmo voraz en el pathfinding de los enemigos. Este pathfinding está implementado en el script EnemyAI, concreatamente en el método
CheckForPath.

El objetivo de este método es encontrar el camino más óptimo en un número de pasos limitado hacia un tipo de target determinado. Una vez hecho eso, devuelve el número de pasos sobrantes
del camino más óptimo (o devuelve -1 si no hay camino posible) y asigna el primer paso de dicho camino a una variable externa para que el enemigo realice dicho paso si así se desea.

Para hacer esto, coge la casilla donde está situado el enemigo que va a buscar un camino y empieza a buscar recursivamente en las 4 casillas adyacentes.

Cada casilla tiene referenciadas sus cuatro casillas adyacentes y un int referente al número de pasos que le sobraban al algoritmo que más pasos tenía de sobra cuando
pasó por ahí.

Antes de empezar el algoritmo, la casilla inicial se marca con 99 pasos sobrantes para no volver a ella en ningún caso, y el resto se marcan con 0 pasos sobrantes de modo que acepten
cualquier camino por poco óptimo que sea.

A partir de ahí, cuando el algoritmo pasa por una casilla, comprueba si le sobran más pasos que los que marca la casilla. Si esto es así, sigue buscando el camino en esa dirección. Si no,
se asume que otro camino ya llegó a esa casilla de manera más óptima y se deja de buscar en esa rama de la recursión.

Finalmente, cuando se encuentra el objeto, se devuelve el valor de los pasos sobrantes y se va comparando con otros caminos cogiendo siempre el camino al que más pasos le han sobrado.

Además de devolver el número de pasos sobrantes, se guarda en una variable externa el primer paso que se dio para llegar al camino óptimo.

El peor caso del coste espacial de este algoritmo está determinado por el número de pasos máximos que se le permita dar. En este juego nunca se hacen búsquedas de más de 10 pasos. En cualquier caso,
no hace falta tener la lista de pasos totales (ya que la situación de juego cambiará en el siguiente turno de todas formas y habrá que volver a calcular). Por eso, el coste espacial se mitiga
ligeramente no usando listas. Sería orden de N.

El coste temporal también está determinado por el número de pasos máximos, pero por cada paso de multiplica por 4, ya que ese es el número de casillas adyacentes que tiene cada casilla. Sin embargo,
debido a que las búsquedas nunca tienen más de 10 pasos y teniendo en cuenta que al haber pasillos y no ser una rejilla de casillas sin agujeros, muchas casillas no tienen 4 casillas adyacentes de verdad,
el coste es asumible. Sería orden de N^2.

## Método iterativo pasado a recursivo

Se ha usado una parte del algoritmo de pathfinding que era iterativa (el decidir entre las cuatro direcciones iniciales, cuál ha devuelto un mejor resultado para usar esa dirección como siguiente paso).

![](/ReadmeContent/Code_MetodoIterativo.PNG)

Este era el método iterativo original, que está dentro del script EnemyAI en el método CheckForPath. Aunque CheckForPath es un método recursivo, esta parte es iterativa.

![](/ReadmeContent/Code_MetodoRecursivo.PNG)

Y este es el método recursivo.

El objetivo en ambos casos es coger el resultado que ha dado el pathfinding en cada dirección y escoger aquel con un valor de pasos sobrantes mayor.

El método iterativo tiene un coste temporal de orden de n, aunque a nivel práctico siempre va a recorrer el bucle 4 veces, ya que no hay más direcciones iniciales. Por otro lado, el coste espacial es
orden de 1.

El método recursivo tiene un coste temporal de orden de n, pero también tiene un coste espacial de orden de n.

Teniendo en cuenta que en este caso siempre van a haber 4 direcciones y que incluso si el sistema permitiese movimiento diagonal estaríamos en tan solo 8 direcciones, no tiene demasiado sentido usar
el método recursivo, ya que pierde legibilidad y resulta más confuso.

Podría tener más sentido si hubiese muchas direcciones en algún juego que funcionase por nodos interconectados y que además cada nodo tuviese un número variable de conexiones, pero para algo tan simple
resulta más intuitivo un acercamiento iterativo.

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

De esta clase heredan los objetos y contendrá funcionalidades genéricas a todos los objetos como podría ser recogerlos.

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

Pese a que el mapa del mundo será estático, los objetos y enemigos en él se generarán aleatoriamente en cada partida.

Ambos spawnearán al principio de la partida mediante este script.

![](/ReadmeContent/Code_Spawn.PNG)

Esto spawnea un objeto en el porcentaje de casillas determinado por la variable percentageOfObjects y un enemigo en el porcentaje de casillas
determinado por la variable percentageOfEnemies.

El sistema de spawneo como tal lo gestiona el script de la propia casilla, lo que hipotéticamente permitiría que distintas casillas pudiesen spawnear distintos
objetos o enemigos si fuesen elegidas como spawner, aunque un sistema así no ha sido implementado y todas son idénticas.

## Objetos

El juego cuenta con 4 objetos.
    
    Punch (rojo): Aumenta el ataque en una cantidad calculada por la distribución normal de una media de 5 y una desviación estándar de 4.
    Helmet (azul): Aumenta la vida máxima en una cantidad calculada por la distribución normal de una media de 25 y una desviación estándar de 10.
    Boots (amarillo): Aumenta la velocidad en una cantidad calculada por la distribución normal de una media de 2 y una desviación estándar de 2, con un mínimo de 1 para evitar 0.
    HealthKit (verde): Al activarse cura 25 de salud.
