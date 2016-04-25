#Program Structure
###Structure of the Unity program, including a brief description of code organization and functionality

##Scenes

* **Sam's Scene** - Used for Normal gameplay mode. Win condition is finding the key and navigating to the door of the two-storied building. Can transition to either the Game Over or Victory screens.
* **SurvivalMode** - Used for survival mode. No win condition. Can only transition to Game Over screen.
* **Title Scene** - Used to start game. Can transition to either to normal gameplay mode (Sam's Scene) or to SurvivalMode scene.
* **Game Over** - Used to display "You Died!" when lose condition is met.
* **UnitTesting** - Used for additional testing
* **Victory** - Used to display "You WIN!" when win condition is met in normal gameplay mode.

##Major Game Objects

* **Main Camera** - Primary camera through which player sees the game, and in non-menu scenes, this is nested within the FPSController
* **Start Menu** - Main start screen (UI)
* **Quit Menu** - Main quit screen (UI)
* **Mode Select** - Allows player to select between Normal and Survival modes
* **Music Player** - Plays background music
* **EventSystem** - Can be used to handle major game events but was not utilized heavily by our team
* **EnemyManager** - Used to govern instantiation of enemies in game
* **MonsterSpawnPoints** - Parent object which contains a number of spawn points for enemies, utilized by EnemyManager
* **Terrain** - Contains environment through which character moves, including:
 * **Boundaries** - Parent object containing edges of the map, beyond which player cannot tranverse
 * **KeySpawnPoints** - Parent object containing all possible key spawn locations
 * **Environment** - Contains main environmental features like trees, walls, etc.
 * **ghoulprefab** - An instantiation of the ghoul prefab, intended to stand directly behind the door at the end of the game
* **FPSController** - The main player character object, handling movement logic, player health, etc., including:
 * **Main Camera** - Primary camera through which player character (and player) sees the game
  * **FPV_Camera** - Primary logic for camera
  * **Flashlight** - Light source for player
  * **Weapons** - Including PPQ22, Shotgun, Ak-47
* **HUDCanvas** - Heads Up Display for player, including:
 * **HealthUI** - Displays health information about player character
 * **WeaponUI** - Displays basic weapon information
 * **DamageImage** - Tints screen red when attacked
 * **CrosshairUI** - Crosshair for weapon
 * **KeyUI** - Displays key icon on screen when key is picked up

##Scripts

* **AI** - Controls overall behavior of enemy objects
* **CameraFollow** - Controls camera behavior
* **EnemyAttack** - Controls enemies' ability to attack player
* **EnemyHealth** - Controls enemies' health
* **EnemyManager** - Controls spawning of enemies in level
* **EnemyMovement** - Controls movement of enemies through level
* **GameVariables** - Contains global game variables
* **menuScript** - Controls functioning of menu system
* **MusicPlayer** - Controls background music
* **PickupController** - Controls the player's ability to pick up objects
* **PlayerAttack** - Controls player's ability to attack enemies
* **PlayerController** - Controls player character
* **PlayerHealth** - Controls player's health
* **WeaponPickup** - Control's players ability to pick up weapons


