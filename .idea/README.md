# Turk Invaders


**Turk Invaders** takes inspiration from the iconic 1978 video game **Space Invaders**, blending nostalgic mechanics with unique twists to create a fresh and thrilling experience. Players assume the role of a courageous female bystander as the Maltese fortress crumbles under the assault of the Turkish Invasion. This Player vs. Environment (PvE) game challenges your decision-making, reaction time, precision, and patience.

## Installation Instructions

1. **Clone the Repository**:
    ```bash
    git clone https://github.com/yourusername/space-invaders.git
    ```
2. **Navigate to the Project Directory**:
    ```bash
    cd space-invaders
    ```
3. **Install Dependencies**:
    - Ensure you have [Unity](https://unity.com/) installed.
    - Open the project in Unity.
4. **Run the Game**:
    - In Unity, open the project and click the Play button.

## Usage Instructions

### Movement

- Use the **A** and **D** keys to move left and right.
- Alternatively, use the **Left** and **Right** arrow keys for movement.

### Shooting

- Press the **Spacebar** to launch a projectile upwards from the player's current position.

### Enemies

- Use the movement keys and the spacebar to align your shots and target the incoming fleet of enemies.

### Health

- The player has **3 lives**.
- The fortress has **10 lives**.
- Use this information strategically to defend the fortress for as long as possible.

## Features

- **Nostalgic Gameplay**: Inspired by the classic Space Invaders game.
- **Dynamic Mechanics**: Side-to-side movement, shooting mechanics, and enemy formations.
- **Challenging PvE**: Test your decision-making, reaction time, and precision.
- **Health Management**: Balance your lives and fortress health to survive the invasion.

## Technologies Used

- **Unity**: Game development platform.
- **C#**: Programming language for game scripts.
- **Pixel Art**: Visual style for characters and environments.

## Code Structure (For Developers)

### Key Components

---

#### EnemyController.cs

This script manages enemy behavior, including moving towards the player, handling shooting mechanics, and detecting collisions with player projectiles.

- **MoveTowardsPlayer**: Calculates the direction to the player and moves the enemy accordingly.
- **HandleShooting**: Controls the timing for enemy shooting.
- **Shoot**: Instantiates enemy projectiles and sets their initial position and orientation.
- **DestroyEnemy**: Handles enemy destruction and interaction with the `CubeController`.

---

#### GameManager.cs

This script handles the overall game state management, including game over conditions and high score management.

- **GameOver**: Triggers the game over sequence, saves the elapsed time, and compares it to the high score.
- **LoadGameOverSceneDelayed**: Loads the Game Over scene after a short delay.

---

#### GameOverSceneController.cs

Controls the display and functionality of the game over scene, including showing the time survived and high score, and handling the "Play Again" functionality.

- **PlayAgain**: Restarts the game by loading the main scene.

---

#### Health.cs

Manages the health points for the player and fortress, including updating the UI and handling invincibility frames after taking damage.

- **OnTriggerEnter2D**: Detects collisions with projectiles and updates health points accordingly.
- **UpdatePlayerHealthText**: Updates the UI text displaying the player's health.
- **UpdateStaticSpriteHealthText**: Updates the UI text displaying the fortress's health.
- **Invincibility**: Provides temporary invincibility after taking damage.

---

#### HighScoreManager.cs

Manages saving and loading high scores using PlayerPrefs and JSON serialization.

- **SaveHighScore**: Saves the current high score to PlayerPrefs.
- **LoadHighScore**: Loads the high score from PlayerPrefs.

---

#### CubeController.cs

Handles player movement, shooting mechanics, and updates the UI for the number of projectiles and player lives.

- **HandleMovement**: Manages player movement based on input.
- **Shoot**: Launches a projectile and updates the UI.
- **EnemyDestroyed**: Updates the projectile count when an enemy is destroyed.
- **UpdateUIText**: Updates the UI text for projectiles and lives.

---

#### Projectile.cs

Controls the behavior of projectiles, including their movement and destruction upon leaving the screen.

- **Start**: Sets the initial velocity of the projectile.
- **OnBecameInvisible**: Destroys the projectile when it leaves the screen.

---

#### Spawner.cs

Manages enemy spawning at random intervals and adjusts spawn rates over time to increase difficulty.

- **SpawnEnemies**: Spawns enemies at random intervals.
- **AdjustSpawnRate**: Periodically increases the spawn rate.
- **SpawnEnemy**: Instantiates enemies at random spawn points.

---

#### StartScreenController.cs

Handles the start screen and the transition to the main game scene.

- **StartGame**: Loads the main game scene.

---

#### Timer.cs

Tracks and displays the elapsed time during gameplay, updating the UI and stopping when the game ends.

- **UpdateUIText**: Updates the UI text displaying the elapsed time.
- **RunStopwatch**: Increments the elapsed time and updates the UI.

## Credits

- **Lead Game Programmer**: Riedle Azzopardi


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact Information

For questions or feedback, please reach out to:
- **Email**: riedle.azzopardi.c11588@mcast.edu.mt
- **GitHub**: [Reedze6060](https://github.com/Reedze6069)

## Future Updates

Planned updates and features will be listed here as development progresses.
