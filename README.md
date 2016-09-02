# Simulador de Georeferencia
Segundo Proyecto del curso de Introducción a la Programación (Universidad Rafael Landívar)

## Enunciado
Se ha encargado la creación de un simulador de ciudades con funciones básicas. La
ciudad será un rectángulo donde las calles se mostrarán de forma horizontal y las avenidas
de forma vertical. La cantidad mínima de calles es 10, y máxima de 50; para las avenidas
mínima de 10, y máxima de 100. Sólo se puede definir un número par de calles y de
avenidas (para evitar callejones sin salida). La distancia entre calles (y entre avenidas) es
de 100 metros.

## Objetivos del Proyecto
- Representación estática de elementos (edificios, automóviles, personas, etc.)
dentro de la ciudad. Los elementos se deben ubicar dentro de la ciudad, sin tener
ningún movimiento (se supone que los vehículos estarán estacionados, las personas no
se moverán de la posición definida). Estos elementos se cargarán por medio de un
archivo cuyo formato se explica más adelante.
- Determinar la ruta y tiempo que tomará en partir de un elemento de la ciudad hasta
otro elemento.

### Inicio
Al inicio, el programa debe solicitar al usuario el número de calles y avenidas que se desean para la simulación.
*Notar: que el número de posiciones en el mapa será de: (calles – 1) x (avenidas – 1)*
Ejemplo: Si el usuario define 4 calles y 4 avenidas, habrá 9 posiciones
en el mapa: 

### Dirección de calles para vehículos
Para los vehículos: el sentido de las calles impares es a la derecha y de las calles pares esa la izquierda. El 
sentido de las avenidas impares es hacia arriba y para las pares es hacia abajo. Para las personas no hay dirección 
obligatoria que seguir.

### Simulación de tiempo y velocidades
Después el programa debe solicitar el día, hora y minuto en el cual comenzará la simulación.
El tiempo del simulador debe ser 60 veces más rápido al tiempo real. (1 hora simulador = 1
minuto real).

### Velocidad de automóvil de acuerdo a horario
La velocidad con que se moverán los automóviles dentro de la ciudad se regirán de acuerdo
al siguiente horario:
* Lunes a viernes
  * 10:01 PM a 5:00 AM: 40 KM/H
  * 5:01 AM a 6:00 AM: 20KM/H
  * 6:01 AM a 9:00 AM: 5KM/H
  * 9:01 AM a 1:00PM: 30KM/H
  * 1:01 PM a 3:00PM: 15KM/H
  * 3:01 PM a 5:00PM: 20KM/H
  * 5:01 PM a 8:00PM: 5KM/H
  * 8:01PM a 10:00PM: 30KM/H

* Sábados y Domingos
  * : 40KM/H a cualquier horario
### Velocidad de personas:
El movimiento de una persona en la ciudad siempre será de 3
KM/H.

## Elementos de la ciudad
En el mapa indicado anteriormente se deben ubicar los diversos elementos que se listan
a continuación, incluyendo las características mínimas que lo deben de definir:
* Vehículo (mínimo 1 vehículo, máximo 100)
  * Número de Placa
  * Número de avenida en que se encuentra
  * Número de calle en que se encuentra
  * Se encuentra sobre: Avenida o Calle
  * Marca
* Municipalidad
  * Número de avenida que se encuentra: será siempre de 9
  * Número de calle que se encuentra: será siempre de de 9
  
*Por motivos de simplicidad, se asumirá que cada edificio (municipalidad,
restaurante, hospital, gasolinera) ocupa una cuadra completa, y por ello no es
necesario señalar si está sobre calle o avenida, ya que está en ambos). Aunque
cada edificio estará sobre 2 calles y 2 avenidas, para ubicarlo siempre se señalará
la calle y avenida menor.*

* Restaurante (mínimo 5, máximo 50 restaurantes)
  * Nombre del restaurante
  * Tipo de alimentos:
    * Comida rápida – Tipo número 1
    * Pizzerías – Tipo número 2
    * Comida gourmet– Tipo número 3
  * Dirección representada por el número de calle y avenida.
  
* Hospitales (mínimo 3, máximo 20 hospitales)
  * Nombre del hospital
  * Indicar si es público o privado.
  * Dirección representada por el número de calle y avenida. 
  
* Gasolinera (mínimo 3, máximo 50 gasolineras)
  *¨Nombre
  * Precio de la gasolina
  * Dirección representada por el número de calle y avenida.
  
* Oficial de policía (mínimo 3, máximo 20 oficiales)
  * Nombre
  * Ubicación basado en calle y avenida
  * Esta sobre calle o sobre avenida

* Bombero: mínimo 3, máximo 20 bomberos
  * Nombre
  * Ubicación basado en calle y avenida
  * Esta sobre calle o sobre avenida

## Carga e ingreso de elementos
El sistema debe cargar por medio de un archivo de texto los distintos elementos. La carga
de datos sólo debe llevar a cabo dos validaciones importantes:
* Cada elemento tiene un dato diferenciador (que será indicado más adelante con un
asterisco*) el cual no debe repetirse. De haber dos elementos con el mismo dato
diferenciador se debe indicar al usuario que sólo se cargará el primero encontrado.
* No se pueden repetir elementos del mismo tipo en la misma dirección, por ejemplo no
pueden existir dos restaurantes en la misma ubicación, si en el proceso de carga se
encuentran elementos del mismo tipo y en la misma dirección se debe indicar al
usuario que solamente se cargó el primer elemento encontrado.


##Autores
- David Munguía
- Mynor Xico
