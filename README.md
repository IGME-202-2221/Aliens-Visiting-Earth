# Project 1

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: Madeline Boussa
-   Section: 05

## Game Design

-   Camera Orientation: side view
-   Camera Movement: stationary camera
-   Player Health: the player has a health bar, and each hit from bullet damages the player
                    <br>-the player also has i-frames, that give the player about 1 second of invincibility after being hit
-   End Condition: -level ends when the player has lost all their health
                   <br>-no win condition, this is an arcade style game with a highschore system instead
-   Scoring: each time you kill an enemy, you get a certain number of points (10 pts)

### Game Description

Name: Aliens Visiting Earth

You are an alien coming to visit this pale blue dot! Oh no! Look's like the humans aren't so welcoming after all. Fight your way through humanity's strongest defences
in this side-scrolling, arcade-style shoot-em-up to set a new highschore and bring the anthropecene to a close.


### Controls

-   Movement
    -   Up: w
    -   Down: s
    -   Left: a
    -   Right: d
-   Fire: left click

## You Additions

Highscore system: A highscore system was created utilizing unity's PlayerPrefs class that saves an int representing the highest score achieved

<br>Menus:
<br>-Start menu created as its own scene with a UI canvas, highscore display and buttons; clicking the play button loads the gameplay scene
<br>-Game over menu created as a UI panel that is set to unactive until the player dies; upon death, the menu has clickable buttons that give the player the option to play again or return to the main menu, and does so by loading their respective scenes

<br>There is a cooldown placed on the player's firing, so they can't spam fire too many bullets at once
<br>-this was done by creating a variable that increments in update using Time.deltaTime in order to track if enough time has passed in between player fires

<br>When the player damages an enemy, the enemy flashes red for short period of time, indicating a shot has landed

<br>Enemy Types:
<br>-Basic Enemy: flies horizontally across the game screen and fire bullets at the player
<br>-Homing Enemy: doesn't fire bullets, but moves toward player and damages player on collision

<br>Scaling Difficulty: As the game progresses and totalElapsedTime is incremented, the game will get harder due to an increased spawn rate of enemies

## Sources

-Alien Sprite: https://www.kenney.nl/assets/alien-ufo-pack
<br>-Enemy and Bullet Sprites: https://www.kenney.nl/assets/simple-space
<br>-Space Background: https://opengameart.org/content/planet-orbit-background

## Known Issues

Known Bug: When the game over screen is active and the player hovers over the menu buttons, the paused enemies and player objects in the screen are drawn in front of canvas overlay
<br>-I would also liked to have fixed the slight delay between when a player gets hit by an enemy bullet and when the actual health bar is updated

Highscore bug: I utilized PlayerPrefs to save highscores, but noticed that the highscore I achieved within the unity editor did not transfer to the WebGL version, and I had to achieve a separate highscore there. I'm not totally sure if it will save the highscore across devices when others play the WebGL build, or if it will just save the highscores of individual player devices.

### Requirements not completed

all requirements completed

