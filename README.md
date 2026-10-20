# JustShoot

**JustShoot** is a 2D top-down survival shooter developed with Unity and C#. Players choose a character, move around an arena, aim with the mouse, and pick up weapons to fight enemies that chase them.

The game combines fast combat with a progression system. Players earn coins by defeating enemies, keep their coins after each run, and use them to unlock new characters in the shop.

## Game Links

- **Play on itch.io:** [PLAY GAME](https://hoangdn1908.itch.io/just-shoot)
- **Gameplay Video:** [WATCH GAME PLAY](https://www.youtube.com/watch?v=--V4peisJfo)

## My Contributions

I led the game's development, defined its concept, and made the final gameplay and system design decisions.

The art were created by external creators. [Asset Credits](https://rgsdev.itch.io/free-cc0-modular-animated-vector-characters-2d)

## Gameplay Screenshots

### Gameplay

![Gameplay: Combat, health/ammo/coin HUD, and weapon pickup](Screenshots/Playing.png)

### Main Menu

![Main Menu](Screenshots/MainMenu.png)

### Character Selection

![Character Selection Screen](Screenshots/SelectCharacterAndPlay.png)

### Shop

![Character Shop](Screenshots/Shop.png)

## About the Game

Players start from the `MainMenu`, buy or select an owned character, and then enter the `PlayingScene`. The character can move freely, aim with the mouse, shoot enemies, and pick up weapon icons that appear randomly around the arena.

Enemies spawn over time from different spawn points. They move toward the player and deal damage when they make contact. When an enemy dies, the player earns a random amount of coins for the current run. When the player dies, the coins earned during that run are added to the saved wallet for future shop purchases.

### Gameplay Loop

1. Open the shop and buy a character if needed.
2. Select an owned character to enter the game.
3. Move, aim, shoot enemies, and collect weapon pickups.
4. Earn coins by defeating enemies.
5. When the player dies, transfer the coins earned during the run to the saved wallet.
6. Use the coins to unlock more characters and play again.

## Gameplay Features

- **Movement and Mouse Aiming:** Move in eight directions, aim the weapon with the mouse, and fire bullets in the direction of the weapon.
- **Three Weapon Types:** Two guns fire one bullet per shot, while the shotgun fires two bullets at different angles.
- **Weapon Pickups:** Weapon icons appear around the player at set intervals. They move up and down slightly and disappear if not collected in time.
- **Chasing Enemies:** Each enemy type has its own movement speed, health, and damage. Enemies chase the player and deal damage at regular intervals when in contact.
- **Coins and Character Shop:** Defeated enemies give coins for the current run. Players can unlock three additional characters for 150 coins each, while the default character is free.
- **HUD and Game States:** The UI displays health, ammo, coins earned during the current run, and saved coins. The game also supports pause and lose screens.

## Technical Highlights

### 1. Save and Load System for Player Progression

The game saves player progression as a local JSON file at `Application.persistentDataPath/save.json`. `GameSaveManager` is a singleton that stays active when changing scenes and manages the `SaveData` object, which stores:

- `totalCoin`: The total coins in the player's wallet.
- `selectedCharacterId`: The ID of the selected character.
- `ownedCharacterIds`: The IDs of unlocked characters.

When the game starts, `GameSaveManager.Load()` reads the JSON file using `JsonUtility`. If the save file does not exist or cannot be read, the game creates new save data through `ResetSave()`.

The character unlock and selection process works as follows:

1. `CharacterShopUI` requests to buy a character.
2. `PlayerWalletController.TrySpendCoin()` checks the wallet balance and spends coins if the player has enough.
3. `CharacterOwnerShipController.UnlockCharacter()` adds the character ID to the save data and saves the file.
4. `SelectedCharacterSave.SetSelectedCharacter()` saves the selected character ID.
5. When `PlayingScene` opens, `SelectedCharacterSpawner` checks character ownership, finds the `CharacterData` in `CharacterDatabase`, and spawns the correct prefab.

This system keeps player progression separate from the UI and gameplay prefabs. The shop, character selection screen, and gameplay scene use `characterId` to identify characters instead of depending on UI card indexes.

**Problem and approach:** Players needed to keep their saved coins and unlocked characters after closing the game. I explored JSON saving as a learning exercise because it was straightforward to implement and easy to read. I implemented save and load functionality so this progress carries over between sessions.

### 2. Weapon Component Composition and Polymorphism

Each weapon prefab uses separate components for different tasks:

- `GunInput` reads left mouse button input.
- `GunAim` rotates the weapon toward the mouse in world space.
- `GunAmmo` manages ammunition and raises an event when the ammo count changes.
- `GunAnimation` controls the shooting animation.
- `GunShoot` gets bullets from the pool, sets their speed and damage, and fires them toward the aiming direction.

`GunController` manages the common shooting process: receive input, use ammo, play the shooting animation, call `Fire()`, and disable the weapon when it runs out of ammo.

Different weapon types change the shooting behavior through inheritance:

- `BasicGunController` fires one bullet toward the aiming direction.
- `ShotgunController` fires two bullets at opposite angles around the aiming direction.

When the player collects a weapon icon, `WeaponManager` receives the `weaponId`, disables the other weapons, resets the ammo, and activates the new weapon. New weapon types can reuse the existing components and override `Fire()` to implement different shooting rules.

**Problem and approach:** The three guns share common behavior but use two firing styles: one bullet or two bullets per shot. To keep the code manageable, I split weapon behavior into focused components coordinated by `GunController`. Two subclasses handle the different firing styles while reusing the shared logic.

### 3. State Machines for Player, Enemy, and Game Flow

The player and enemies use separate state classes to organize their behavior, while `GameManager` uses an enum-based state machine to control the game flow.

**Player State Machine**

The player has three states: `PlayerIdleState`, `PlayerWalkState`, and `PlayerDeathState`.

- `PlayerController` reads input in `Update()`, updates the current state, and handles physics movement in `FixedUpdate()`.
- `PlayerIdleState` stops the Rigidbody, plays the idle animation, and switches to the walk state when the player moves.
- `PlayerWalkState` calls `PlayerMovement.Move()` using the input and movement speed from `PlayerData`. When there is no movement input, it returns to the idle state.
- Both idle and walk states check `PlayerHealth`. When health reaches zero, the player enters the death state. This state stops movement, plays the death animation, and disables the player.

**Enemy State Machine**

The enemy has two states: `EnemyChaseState` and `EnemyDeathState`.

- `EnemySpawner` gets an enemy from the pool and calls `EnemyController.PrepareForSpawn()` to reset health, assign the player target, reset the animation, and start the chase state.
- `EnemyChaseState` moves toward the player using `EnemyMovement.MoveToTarget()` and checks the enemy's health.
- When the enemy runs out of health, `EnemyDeathState` stops movement, plays the death animation, and returns the object to the pool.

This design keeps the controllers focused on managing components and object lifecycles. Each state handles its own behavior and state changes. Using a similar structure for both the player and enemies also makes the gameplay code more consistent.

**Game Flow State Machine**

`GameManager` manages three states using the `GameStates` enum: `Playing`, `Pause`, and `Lose`.

- `Playing`: Sets `Time.timeScale = 1` and hides the pause and lose panels.
- `Pause`: Sets `Time.timeScale = 0` and shows the pause panel.
- `Lose`: Transfers the coins earned during the run to the saved wallet, waits 0.5 seconds using scaled time, then pauses the game and shows the lose panel.

Pressing `Escape` switches between Playing and Pause, unless the game is already in the Lose state. `UiController` only controls panel visibility, while `GameManager` decides when to change the game state.

**Learning goal and approach:** I wanted player behavior, enemy behavior, and game flow to be easier to read, maintain, and switch between. I applied state machines to give each state a clear responsibility and make transitions explicit, such as moving from walking to death or from playing to pause.

### 4. Object Pooling for Enemies, Bullets, and Weapon Pickups

`ObjectPool` creates objects in advance and stores them in a `Queue<GameObject>`. `GetFromPool()` gets an object, activates it, and removes it from the pool. `ReturnToPool()` disables the object and adds it back to the queue for reuse.

Object pooling is used for objects that spawn frequently:

- `EnemySpawner` gets enemies from the pool and resets their data before each spawn.
- `GunShoot` gets bullets from the weapon's bullet pool.
- `BulletController` returns bullets to the pool when their lifetime ends or when they hit an enemy.
- `WeaponIconSpawner` creates weapon pickups from the pool. `WeaponIconController` returns them when their lifetime ends or when the player collects them.

`ObjectPool` uses a `HashSet<GameObject>` to prevent the same object from being returned to the queue more than once. If the queue is empty, the pool creates more objects so gameplay can continue without waiting for an available instance.

**Problem and approach:** Enemies, bullets, and weapon pickups spawn frequently during gameplay. I implemented object pooling to reuse these objects, reducing repeated creation and destruction as they enter and leave play.

### 5. Data-Driven Gameplay with ScriptableObject

Important gameplay settings are stored in ScriptableObjects. This allows me to change values in the Unity Inspector without changing the main gameplay logic.

- `EnemyData` stores movement speed, maximum health, and damage for each enemy type.
- `PlayerData` stores player movement speed and maximum health.
- `CharacterData` stores the character ID, shop price, icon, and prefab.
- `CharacterDatabase` contains the list of `CharacterData` assets used by the shop and character selection screen.

Enemy prefabs reference `EnemyData`, which is used by `EnemyController` and `EnemyHealth` when enemies spawn. The shop creates character cards from `CharacterDatabase`, while `SelectedCharacterSpawner` uses the same database to find the correct character prefab.

**Learning goal and approach:** I wanted to separate gameplay settings from behavior and make values easier to adjust. I used ScriptableObjects to store basic player, enemy, and character data, allowing me to tune these settings in the Unity Inspector without editing gameplay code.

### 6. Event-Driven Communication for UI and Economy

Gameplay components raise events when their data changes. UI components subscribe to these events in `OnEnable()` and unsubscribe in `OnDisable()`.

- `PlayerHealth.OnHealthChanged` updates the health bar, while `OnPlayerDied` tells `GameManager` to enter the lose state.
- `GunAmmo.OnAmmoChanged` updates the ammo UI.
- `EnemyHealth.OnEnemyDied` provides the coin reward, and `LevelCoinManager` listens for the event to add coins to the current run.
- `LevelCoinManager.OnLevelCoinChanged` updates the coins displayed during gameplay.
- `PlayerWalletController.OnTotalCoinChanged` updates the saved coin balance in the menu.
- `WeaponIconCollision.OnWeaponIconHit` tells `WeaponManager` to switch weapons.

When the player dies, `GameManager` gets `LevelCoinManager.CurrentLevelCoin`, calls `PlayerWalletController.AddCoin()`, and displays the lose UI. Combat, the coin system, and the UI communicate through events, so the HUD does not need direct references to bullet or enemy controllers.

**Learning goal and approach:** I wanted gameplay and UI components to depend less on each other. I used events to notify other components when health, ammo, or coins change, reducing direct connections between them. Some direct dependencies remain, so this is an area I still want to improve.

## Controls

| Action | Function |
|---|---|
| `W` / `A` / `S` / `D` or Arrow Keys | Move the player |
| Move the mouse | Aim and rotate the weapon |
| Left Mouse Button | Fire one shot |
| Touch a weapon icon | Pick up and equip a weapon |
| `Escape` | Pause or resume the game |
| Resume / Restart / Main Menu | Continue, restart, or return to the main menu using the UI |
