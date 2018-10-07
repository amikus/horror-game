# Testing

## Assertions and Unit Tests

##### Player Boundary Checks
* Assert first person camera (player) z-coordinate > z-coordinate of bottom boundary collider
* Assert first person camera (player) z-coordinate < z-coordinate of top boundary collider
* Assert first person camera (player) x-coordinate > x-coordinate of left boundary collider
* Assert first person camera (player) x-coordinate < x-coordinate of right boundary collider
* Assert first person camera (player) y-coordinate < 300 (implicit boundary height)

##### Game Menu Checks
* Assert Start menu's canvas.enabled value is set to true
* Assert Quit menu's canvas.enabled value is set to true


## Manual and Integration Tests
##### Key Spawn Points Test
1. Temporarily disable random key spawning.
2. Manually set key spawn point to one of the 12 standard spawn points.
3. Manually navigate to the spawn point and collide with the key.
4. Verify that key vanishes from game world.
5. Verify that key image appears in top right corner of screen.
6. Repeat steps 2-5 for each of the other 11 key spawn points.

##### Key GUI Image Functioning Correctly
1. Temporarily disable random key spawning.
2. Manually set key to spawn in center of map, near player character.
3. Manually navigate to the key and collide with it.
4. Verify that the key vanishes from the game world.
5. Verify that key image appears in top right corner of screen.

##### Door Functioning Correctly.
1. Temporarily disable random key spawning.
2. Manually set key to spawn in center of map, near player character.
3. Manually navigate to door on two-story building and collide with it.
4. Verify that door does not open.
5. Manually navigate to key spawn point in center of map and collide with key.
6. Verify that key vanishes from world.
7. Verify that key image appears in top right corner of screen.
8. Manually navigate to door on two-story building and collide with it.
9. Verify that door opens.

##### Player Health Test combined with Monster1 Damage Test
1. Manually navigate to Monster1-type enemy.
2. Without attacking back, allow Monster1-type enemy to attack.
3. Verify that player health drops toward zero with each attack.
4. Verify that Monster1-type enemy animations and sounds appear to be playing correctly.
5. Verify that when player health reaches zero, end game screen is triggered.

##### Player Health Test combined with Ghoul Damage Test
1. Manually navigate to Ghoul-type enemy.
2. Without attacking back, allow Ghoul-type enemy to attack.
3. Verify that player health drops toward zero with each attack.
4. Verify that Ghoul-type enemy animations and sounds appear to be playing correctly.
5. Verify that when player health reaches zero, end game screen is triggered.

##### Monster1 Health Test combined with Player Damage Test
1. Manually navigate to Monster1-type enemy.
2. Attack Monster1-type enemy by holding left mouse button and aiming at any part of enemy's body.
3. Verify that after several seconds, Monster1-type enemy falls to ground.
4. Wait several seconds and verify that Monster1-type enemy vanishes from scene.


##### Ghoul Health Test combined with Player Damage Test
1. Manually navigate to Ghoul-type enemy.
2. Attack Ghoul-type enemy by holding left mouse button and aiming at any part of enemy's body.
3. Verify that after several seconds, Ghoul-type enemy falls to ground.
4. Wait several seconds and verify that Ghoul-type enemy vanishes from scene.

##### Monster1 Blood Splatter Test
1. Manually navigate to Monster1-type enemy.
2. Attack Monster1-type enemy by clicking left mouse button one time while aiming at a part of the enemy's body.
3. Verify that a blood splatter particle is generated at aimed-at location.
4. Repeat steps 2-3 for other locations on enemy's body until enemy's life reaches 0.

##### Ghoul Blood Splatter Test
1. Manually navigate to Ghoul-type enemy.
2. Attack Ghoul-type enemy by clicking left mouse button one time while aiming at a part of the enemy's body.
3. Verify that a blood splatter particle is generated at aimed-at location.
4. Repeat steps 2-3 for other locations on enemy's body until enemy's life reaches 0.

##### Blood Splatter and Bullet Hole Test
1. Manually navigate to Monster1-type enemy.
2. Attack Monster1-type enemy by clicking left mouse button while aiming at a part of enemy's body.
3. Verify that a blood splatter particle is generated at aimed-at location.
4. Manually navigate to Ghoul-type enemy.
5. Attack Ghoul-type enemy by clicking left mouse button while aiming at a part of enemy's body.
6. Verify that a blood splatter particle is generated at aimed-at location.
7. Manually navigate to a tree or other solid non-enemy object.
8. Attack solid object by clicking left mouse button wihle aiming at the object.
9. Verify that a bullet hole is generated at aimed-at location.
