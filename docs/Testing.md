#Testing

##Assertions and Unit Tests
#####Unit Test 1

#####Unit Test 2

##Manual and Integration Tests
#####Spawn Points Test
1. Create 12 spawn points that create 4 boxes.
2. Launch game.
3. Navigate to a box and collide with it.
4. Make sure script detected collision and destroyed the object.
5. Make sure that a new box was spawnied in a different location.
6. Repeat steps 3-5 to be sure that the destroyed objects are freeing up that location.
7. Interact with otehr objects to make sure that they are not being destroyed, too.
#####PlayerHealth Test 1 (10 damage per .5 seconds)
1. Create an object with a sphere collider with a trigger set to do damage.
2. Sphere does 10 damage every .5 seconds to player.
3. Quickly depletes player health by tens until player health is 0. Player is dead, and health stops at 0.
#####PlayerHealth Test 2 (25 damage per 5 seconds)
1. Create an object with a sphere collider with a trigger set to do damage.
2. Sphere does 25 damage every 5 seconds to player.
3. Player health is depleted in increments of 25 until player health is 0. Player is dead, and health stops at 0.
#####PlayerHealth Test 3 (50 damage per 5 seconds)
1. Create an object with a sphere collider with a trigger set to do damage.
2. Sphere does 50 damage every 5 seconds to player.
3. Player health is depleted in increments of 50 until player health is 0. Player is dead, and health stops at 0.
#####PlayerHealth Test 4 (Instadeath)
1. Create an object with a sphere collider with a trigger set to do damage.
2. Sphere does 100 damage.
3. Player health is immediately reduced to 0. Player is dead, and health stops at 0.