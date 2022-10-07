# Project PROJECT_NAME

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: Madeline Boussa
-   Section: 05

## Game Design

-   Camera Orientation: side view
-   Camera Movement: stationary camera with scrolling background
                    <br>-stationary ceiling and floor
-   Player Health: the player has 3 lives, each time they get hit they lose a life
-   End Condition: -level ends when the player has lost all 3 lives
                   <br>-no win condition, this is an arcade style game with a highschore system instead
-   Scoring: each time you kill an enemy, you get a certain number of points
            <br>-point amounts increment as time goes on
            <br>-secondary (harder) enemy time gives more points

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

-highscore system and start menu that displays highscores
<br>-additional enemy type that causes vertical beams to shoot from above
<br>-3 types of blockades that will spawn in --vertical beams (from enemy), floating block obstacles, and diagonal beams
<br>(inspired by Jetpack Joyride)

<br>There is a cooldown placed on the player's firing, so they can't spam fire too many bullets at once
<br>-this was done by creating a variable that increments in update using Time.deltaTime in order to track if enough time has passed in between player fires

<br>Enemy Types:
<br>-Basic Enemy: fire bullets at player
<br>-Homing Enemy: doesn't fire bullets, but moves toward player and damages player on collision

## Sources

-Alien Sprite: https://www.kenney.nl/assets/alien-ufo-pack
<br>-Enemy and Obstacle Sprites: https://www.kenney.nl/assets/space-shooter-extension
<br>-Obstacle Sprites: https://www.kenney.nl/assets/simple-space

## Known Issues

_List any errors, lack of error checking, or specific information that I need to know to run your program_

### Requirements not completed

_If you did not complete a project requirement, notate that here_

