Space Shooter (15 Points) 
Pew Pew. The assets can be found on the Assets tab, but you are free to use your own. You can change the control layout, as long as you make it clear how your game is controlled.
Important: From now on all games should use the Universal Render Pipeline (project template 2D (URP)) and the Input Manager / Input System.

1) Player Controller (4 Points) 
Choose a spaceship and implement the basic movement using the physics system. In the example game () the ship is on the left and can only move up and down. But you can also put the player on the bottom of the screen, or even make the ship movable in any direction. The only requirement is that the player can not leave the screen.
The player can shoot lasers with Space or the Left Mouse Button. Lasers are shot continously while either button is held down. Each shot plays a sound effect.
The player can shoot three lasers at once with 1 or the Right Mouse Button. This attack has a short cooldown window, which is shown as an Image of type Filled in the UI.
[Hard] The player has one special attack per group member that can be shot with 2, 3 or 4. This attack also has a cooldown that is shown on the screen. The effect should be more complex than the previous two, e.g. a bomb that explodes into smaller bombs, multiple bullets that move in a sine wave, or a projectile that bounces between enemies. Try to be creative! (Adding another laser to the previous attack or just changing its sprite doesn't count).

2) Enemies (6 Points) 
The player is attacked by enemies that move around continuously and shoot lasers every few seconds. Create at least four different enemies with a different amount of hit points (HP).
When the player is hit, an explosion sound effect is played, the music fades out over a second, and the player is returned to the menu from 3a).
Pressing G toggles God Mode on and off. In God Mode the player cannot be hit be enemy attacks. Activating God Mode plays a sound effect and shows a text or some other indicator on the screen.
When an enemy is hit by the player, it takes damage and a sound effect is played. An enemy is destroyed once their HP reach zero. The damage is shown as a floating text above their sprite.
Enemies spawn in waves. A wave consists of one or multiple enemies that have to be destroyed before the next wave can spawn.
[Hard] Build one boss per group member out of multiple sprites from the Boss Parts folder. This enemy has more HP and uses attacks that are much harder to avoid than the regular lasers. Every 5th wave contains a boss.

3) Menu and Effects (3 Points) 
Create a main menu that is shown at the start of the game. The menu contains a text that shows the highest wave the player has reached so far. This highscore is saved persistently in PlayerPrefs.
Create a star field using particle systems and add it to your game and your menu. (Hint: the example game uses two systems that are moved from right to left. The second system has reduced particle size and speed.)
Add an explosion particle effect whenever an enemy or the player is destroyed. Make sure that the enemies can't be hit anymore while the explosion effect is playing.
