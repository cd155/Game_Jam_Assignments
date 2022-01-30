## Introduction
### At Start
In the beginning, a snail character will display on the left bottom position.

<img width="480" alt="Screen Shot 2022-01-29 at 6 35 12 PM" src="https://user-images.githubusercontent.com/16947266/151689384-eda60846-42da-458d-9eda-01bd76776ad0.png">

Figure 1

- On the left top, there are three hearts, which means the player has three chances to be hit by a rock or fall out from the ground.
- On the middle top, there are target fruits the player needs to collect. Once the snail hits it, this target fruit will disappear, and the target move to next. 

### Jumping
The snail can jump in three heights. Press keyboard **Z**, **X**, and **C** to achieve them.
- small jump: press **Z**
- middle jump: press **X**
- large jump: press **C**

<img width="480" alt="Screen Shot 2022-01-29 at 6 41 05 PM" src="https://user-images.githubusercontent.com/16947266/151683070-83710ae8-77f1-4d80-bcce-4c81fcd39626.png">

### Basic rule
1. The fruit will be collected once the snail hits the fruit.
2. On the right top middle, there will be a display(target fruits) showing what fruits need to be collected. See Figure 1
3. The fruits need to be collected in order, and the order will be displayed in the top middle.

#### Winning condition
- The snail hit all targets before lose conditions meet.

#### Lose condition
- The rocket serves as the obstacle, the player has certain limitations hit by it. Once the number limitation is reached, it is game over.
- The snail will be pushed to the left edge if it is hit by an object before landing on the ground. The player has certain limitations that the snail falls out from the ground. If the number of times that the snail falls out from the ground reaches, it is game over. 

## Mechanics
### Main character mechanics
The main character can jump to various heights. (valid distance: distance between the ground and the ceiling of the screen)
- Small Jump
    - cover 1/3 valid distance
- Middle Jump
    - cover 2/3 valid distance
- Larger Jump
    - cover 3/3 valid distance

#### Why made this decision 
This decision is the main focus on the assignment's constraints which jumping is the only mechanic. Three jumps distance is evenly distributed based on on-screen height. With three distances, it will cover all valid distances. This allows the player to jump at desired distance to hit the target. Also, this help player to avoid unnecessary jump, and reduce the chance be hit by a rocket. 

### Background mechanics
There will be objects floating from right to left. Once the character touch object, the object will be collected. There are various object
- various fruits: the player needs to hit the targeted fruit to move to the next target
- rocket: the player needs to avoid being hit by a rocket, otherwise it will lose one chance.

#### Why made this decision 
Since jumping is the only mechanic, I introduced some background mechanics to enrich the game. The fruits and rocket elements will help to create different actions to accomplish challenges.

## Gameplay
This is a survival game, which is similar to a lot of mobile 2D survival games in the current mobile game market. In order to make the game playable, I have to design the game base on the following criteria
- There must exist a jump pattern to accomplish the goal
    - the speed of floating objects cannot be too fast
    - the quantity of the float objects needs to be in a reasonable number based on screen size.
- The character will have related animation in different statuses (jump/idle/hit)
    - related animation make the character more vivid 

### Challenge and Action
The character needs to stay on the ground, and avoid falling out of the ground. When the character hit by objects in the air, there will be some force to move the character to the left, and eventually, the character can be fall out of the ground. The player has to make the character jump to hit the target. At the same time, the player has to make sure the character would not be hit so hard, and move to the left.

#### Why made this decision 
This challenge will make players observe the jump pattern, and use the right jump to hit the right target. Most time, the character has limited time to jump before falling out of the ground. This constraint will increase the difficulty of the game. It will also increase the flexibility of the game. At the easy level, there can be a large surface of the ground. In the advanced level, I can only give a small surface of the ground, so the player is harder to win.

## Player Experience
The game is designed for young kids, not for adults. The level of difficulty is flexible. The player can either choose easy or difficult, though this feature has not been implemented in the prototype.
- Easy level (implemented): the player can cozy discover this game, it only has three jump actions. There have fewer obstacles at this level. 
- Hard level (not implemented): this is a more intense player experience. The player has to remember the height of each jump, recognized the pattern of landing, and discover the hidden rule to achieve the goal. Simply increasing the force of each fruit will result in a larger force in the collision, so the snail will be pushed on the left more. This means the player will have fewer chances to make mistakes.

For easy level, the player will experience a cozy and relaxed game environment. On other hand, at a hard level, this may make the player frustrated. Some players might give up, but some people may try to observe the pattern and hints from the game and move to the next level. 

My main goal for player experience
- Easy level: relax, and kill time.
- Hard level: wanting the player could build up some achievement once they complete the hard level of the game. 

## Aesthetics
The model of character, background, tilemap and the model of fruits are carefully selected in free open-source websites. The aesthetic elements are chosen for young kids, not for adults.
### Cartoon
- snail: kids friendly snail character
- fruits: kids friendly fruit images
- tilemap: green ground match the scene background
- background: sky background, indicate an open world.

### Animation
Each animation related to actions that made
- Jumping animation
- hiding animation
- hitting animation

Those animations help to improve the aesthetics. It makes the player feel natural about each action. Also, animations made related to a snail are very natural. These animations mimic how a snail could do in the real world.

### React soundtrack
React sound further make the game more natural,  it is also a signal to confirm whether a target is hit or obstacles.

## Hidden rule
After a snail jump, it can land in a fruit. During this time, the snail can continue to jump before fruit land on the ground. In such an event, the snail could jump a high distance and leave the main display. The hidden rule will be triggered, and it will transform the snail to the original position.

#### Why made this decision 
The hiddle rule is made for players to discover the game even deeper. It is not hard to find out. Once the player spends a couple of minutes in the game and accidentally lands in fruit, then jump again. This design is aiming to make the player feel they may take advantage of this discovery, and try it on a more advanced level.

## Future work 
The further work is to try to make more content in the game, so the player can move to the next level, and discover for mechanics of this game.
###  More Rule
Those rule is for more advanced thinking, and may not be realistic to implement in a week.
1. The objects can float from both right to left and left to right. The player can change the face direction both on the ground or during jumping.
2. There will be an object containing a "superfruit", which means the player can collect it at any time to move the next target.
3. There will be the next level.
4. New Hidden rule: Once the player completes a certain pattern of jumping, the superpower skill will be activated. For example, the snail can grab/suck the object on the horizon no matter how far the fruit is.
