# Courier

**Courier** es un juego RPG de consola desarrollado en C# (.NET) donde
el jugador asume el rol de un mensajero que debe completar misiones a
través de edificios llenos de enemigos, salas especiales y desafíos de
habilidad.

El juego combina combate por turnos, eventos interactivos y progresión
permanente del personaje.

------------------------------------------------------------------------

## Características

-    Sistema de combate por turnos
-    Golpes críticos
-    Sistema de esquiva
-    Armadura y reducción de daño
-    Salas de puzzles matemáticos
-    Salas de contraseñas con límite de tiempo
-    Enemigos escalados por planta
-    Sistema de recompensas permanentes al completar misiones
-    Guardado y carga de partida mediante archivos JSON

------------------------------------------------------------------------

## Arquitectura del Proyecto

El proyecto sigue una estructura organizada por responsabilidades:

    Courier
    │
    ├── Controllers
    │   ├── GameController.cs
    │   ├── RoomController.cs
    │   └── HelperController.cs
    │
    ├── Model
    │   ├── Player.cs
    │   ├── Enemy.cs
    │   ├── Item.cs
    │   ├── Room.cs
    │   ├── Mission.cs
    │   └── CourierClass.cs
    │
    ├── View
    │   └── MenuView.cs
    │
    ├── Data
    │   ├── Classes.json
    │   ├── Couriers.json
    │   ├── Enemies.json
    │   ├── Items.json
    │   ├── Missions.json
    │   └── Rooms.json
    │
    └── Program.cs

### 🔹 Controllers

Gestionan la lógica principal del juego.

### 🔹 Model

Contiene las entidades y estructuras de datos.

### 🔹 View

Muestra la interfaz de consola e interacción con el usuario.

### 🔹 Data

Archivos JSON que almacenan datos del juego.

------------------------------------------------------------------------

## Sistema de Combate

El combate funciona por turnos:

1.  El jugador ataca (posible crítico).
2.  El enemigo recibe daño reducido por armadura.
3.  El enemigo ataca.
4.  El jugador puede esquivar el ataque.
5.  Se repite hasta que uno cae.

El daño se calcula usando:

    Daño = Ataque - Armadura (mínimo 1)

Incluye: - Probabilidad de crítico del jugador - Probabilidad de
esquiva - Críticos enemigos

------------------------------------------------------------------------

##  Eventos Especiales

###  Sala de Contraseña

El jugador debe escribir correctamente una palabra antes de que se acabe
el tiempo.

### Sala de Puzzle

Operaciones matemáticas que deben resolverse en tiempo limitado.

Si fallas, recibes daño porcentual.

------------------------------------------------------------------------

## Progresión

Al completar una misión:

-   Se incrementan permanentemente:
    -   Vida
    -   Ataque
    -   Armadura
-   Se guarda automáticamente el personaje en JSON.

------------------------------------------------------------------------

## Persistencia

Los datos se guardan en archivos JSON utilizando `System.Text.Json`.

El juego carga automáticamente: - Clases - Enemigos - Objetos -
Misiones - Personajes guardados

------------------------------------------------------------------------

## Tecnologías Utilizadas

-   C#
-   .NET
-   System.Text.Json
-   LINQ
-   Programación orientada a objetos

------------------------------------------------------------------------

##  Autor

Proyecto desarrollado como práctica de desarrollo en .NET y diseño de
arquitectura de videojuegos en consola.
