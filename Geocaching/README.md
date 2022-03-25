## Introduction
In the exploration games, the avatar usually will walk into an artificial world and start exploring the world. For example, in No Man's Sky, players explore the planet-like world with mass procedures. Those exploration games usually feature with mass decent graphics to keep players immersed in the game. In the meantime, players may lose self-awareness that they are actually in a game.

There could be an alternative way to design an exploration game. There are reasons I think this game is different than other exploration games.

1. Instead of creating vivid virtual graphics that match our daily life, why not guild players explore the real world. Human society usually has mass interest attractions that could be explored. Places like national parks, historical sites, and iconic landmarks are some examples players may want to explore. The control mechanics are different, in this case, we use GPS tracking to replace mouse and keyboard control.

2. The game also introduces exercise mechanics into the game.

3. A lot of exploration games lack social factors, but this game will introduce social gameplay.

## Example
| Map View | Street View | Scene Challenge | 
| ----------- | ----------- | ----------- | 
| <img width="200" alt="select" src="https://user-images.githubusercontent.com/16947266/160051739-7696fcce-971c-45e1-983d-aac7db0294cc.png"> |   <img width="200" alt="map" src="https://user-images.githubusercontent.com/16947266/160051775-e379e475-e88d-4830-86d1-d445b362856c.png">  | <img width="200" alt="portal" src="https://user-images.githubusercontent.com/16947266/160051795-423efcf9-fc31-45b8-9886-9a338081fcf4.png"> |

- Map View: This is a normal view people look at the map. The red person drawing mean the current location.
- Street View: This is a street view which is very close to what people can see in the real world.
- Scene Challenge: This is a list of available scene challenges. For the demo, I only add one scene chalnege.

## Core mechanics
### Core mechanics 1 - Geocaching
The protagonist will walk in the digital world that was rendered based on the real world. This part design is fairly similar to Pokemon Go in that the player has to walk on the map to explore its game world. In this game, geocaching is not limited to just walking, users can drive a vehicle, take a vehicle or take the air/water. Sometimes, the user can choose where he/she want to go ahead of time. Once they arrive at the place, the task will complete, and they will be rewarded. 

### Core mechanics 2 - Activity tracking
The player also can decide to use their activity data to help complete tasks in the game. The mobile app will synchronize their data including moving distance, calories burned and moving steps. The health data could give a privilege for players to uncover more areas of an image.

## Gameplay
In the game, there is no clear win-lose condition. On the home page, the player will see a gallery of photos photographed by other users. A player could either initiate the challenge to claim he/she will "complete the mission" or invite his/her friends to join. In this case, "**complete mission**" means deducting to right the location, and taking the photo at the right angle. 

The idea originally comes from a mobile game called "GeoGuessr" (they seem changed the name, the original name I thought was the app called Where am I). In that game, the player's goal is to guess which country/city it is by browsing google street view panorama. The player uses google street view panorama as a hint to deduct where the photo was taken. However, there are some limitations with this game, for example, not all locations have street views available, it heavily relies on a third-party API and maintenance fees are high. The new game adopts the image guessing challenge and modifies it to fit into the geocaching mechanic. Here are some reasons why I made this decision:
- the interface of image guessing is wildly known. Players guess and answer questions by just giving limited information.
- scene images are free and can be easily access
- visiting scenes to experience real ambience can be an ideal incentive 

Based on the residential location of each player, the game will automatically generate 10 scenes tokens. Each scene token represents a different scene. In order to completely get the scene token, the player can select one scene, and start accepting the challenge to "complete the mission".

Build-in scene vs Players' scene: at the beginning, players only can select the scene challenge which was designed by the designer. Once they are more familiar with the game, they can start organizing their own scene challenge, and eventually public to other players. This setting extends the game life because it is likely the pre-program challenge can eventually run out. In order to make the challenge more difficult, for example, the scene designer can add time limitations, hide more areas on the photo, and use summer scenes in the wintertime. The game will have an algorithm to ranking which scene is good base on various factors, like popularity, successful rate, and so on.

**note**: scene challenge means all challenges involved to deduct to right the location, and taking the photo at the right angle

- Image matching challenge
    - players will be given a partial image (Some parts be covered). Their goal is to figure out where is the image taken
    - When players approach a stop station, the map will hint whether you guess the location right or wrong. If you guess the location is near the Stop Stations, this will trigger to remove the cover area on the photo. In this way, you can focus on taking the photo.

- Discovering challenge
    - once the player figures out the location of where the image is taken, they need to arrive at the scene. After that, they have to take a photo that matches the previous image.
 
- Fitness challenge: 
   - players can use their health data (synchronize from their smartphones) to accumulate game points. The game points can help players uncover more space from the image, so in this way, the player can see more areas of the image.

### Action
- Doing various exercises
    - work out (5 mins)
    - running (10 mins)
    - walking (15 mins)etc

- It might be tricky to take the photo once arrive at the scene. The player has to figure out what angle and position this photo was taken. At the end of the day, they have to use a mobile camera to take a photo.  

As I may mention before, there are terms called "game points" in this game. Currently, there are only a few ways to earn a game point. 
- Each time when players "complete a mission"
- Collect scene tokens
- Visit a stop station

Players can use game points to buy customized features for their avatar. In addition, players could buy a virtual residential place in the game world. 

## Game World
The game world is a world rendered with the real world. A protagonist will show on the screen if the player walks on the street, the protagonist will move respectively. There will be stop stations on the map, here are functions for stop stations:
- players visit the stop station to collect game points. 
- the stop station will hint you whether you should do your mission in the nearby area.
- players can send out postcards to their friends or the public. The postcard contains a note and a photo of the scene. In addition, they decide whether use this photo to create a scene challenge.

In this game world, players can decide to change the geographical layout later. For example, a player could decide to buy a digital house in a certain location. Once the player bought a new house, they can decorate the house and place it in a designated location. Therefore, the real world is not 100% the same as the digital world. In the postcard, players also can invite people to visit their house. 

## Player Experience
- Curiosity: the reason to cover some part of the photo is to simulate players' **curiosity** to uncover the photo. When players look at a partial scene image, it is very likely some key information has been hidden. This will prevent players to access key information to guess where the location is. With hidden information, some players who like this type of scene challenge feel curious about what the whole photo looks like or where the location it is. The curiosity will promote players to do a fitness challenge because it is a way to remove the obstacle on the photo.

- Chasing beauties: In the scene challenge home page, the design choice is to have a gallery look page. With some text notes on the top, and a list of photos below. It will similar to what the Facebook app has. The player can scroll down to search desired scene challenge. This type of setting is very straight for players to browsing material, and it is very user-friendly. The interface is there, but somehow players ignored it. Another reason to use images as the poster of challenges is that it is a very efficient way to communicate with players. In addition, it is human nature that we all like to chase something beautiful. The image is very intuitive to access information. Adding a play-made scene challenge will enrich the content of the game. With customized content and pre-build content all together in one page, it gives players a thought that our society still has a lot of places worth discovering and they are **welcome** to discover them. 

- Biological Happiness: Exercising is very important to human life. According to [webmd](https://www.webmd.com/depression/guide/exercise-depression) "_When you exercise, your body releases chemicals called endorphins. These endorphins interact with the receptors in your brain that reduce your perception of pain. Endorphins also trigger a positive feeling in the body, similar to that of morphine._". The designer really wants to link biological happiness with playing the game. Both discovering challenges and fitness challenges require players to do some degree of exercising, either indoor or outdoor. In general, the ideology of exercising is on the positive side. This gives players reasons to believe that what they have been doing in the game contributes to both their mental and physical health. Each exercise challenge that gives to the player is relatively easy to accomplish. The designer gives a small chuck of exercise because it will increase the success rate of completing the challenge. Once people complete the fitness challenge and uncover the image, players wouldn't feel they are wasting time. In the bottom line, if they can't figure out the location, they exercised. It is good for players' health and nothing hurt. This is a win-win situation for players and the game.

- Frustrated and less frustrated: Finding the right angle to photograph the right photo can be very frustrated. In this game, we don't want players to feel so frustrated. During the time, when they submit a photo, the camera mode will assist players to move the position. For example, there will be a hint given shows move up/move down/move left/ move right. If the player found the right angle, the camera mode will have a green checker indicating this place is accepted. In this design, the game tries to avoid try-and-error scenarios. Giving feedback about camera position will ease the **frustrated** feeling players have and make the challenge more interesting.

- Empathy and Connection: in each stop station, players could send postcards to their friends or the public. They also can share their story with others in postcards. So why do people want to send postcards? 1. remember the happiness 2. share the happiness with others. The game encourages the idea of spreading happiness and sharing your own story about this place. In such a way, some players may feel connected with other players if they have a similar feeling about the place. **Encouragement** and **empathy** also can emerge if players feel the challenge/story is touching.

- Ownership: One significant difference between this game and other geocaching games, for example, Pokemon Go, is that the digital world here is not 100% reflect in the real world. In the beginning, the game world is close to the real world, but the designer gives the power to players to design his/her fiction world. At the start, all streets and roads are mapped 100% the same as the real world, but buildings on them could be different. For example, in the game, a player could buy a house on Damdus Street. Then, other players visit Damdus Street, they will see this player's house. It is very likely the building is different than the one in the real world. The player experience is that the game empowers players to make a decision to influence other players. Once a house is bought (use game points), other players can't buy it in this location. This gives players a chance to change history and fill in their desires where the real world may not give to them. This also creates ownership of land to a player. The property work as a trophy tool to incent players to do more scene challenges or visit more stop station. This setting makes the player feel **secured** in the game world, and they could have a shelter to rest.

## Aesthetics
There are several game components I rank them based on the importance I believed

Most important: the following components are basic components to run this game. Without the following components, the game will be extremely different.
- Challenge gallery
    - scene challenge page is a page players will frequently visit. For the interface, it is more like a social app like the Facebook app. This is because it is an efficient way for players to retrieve information from each post. In this case, the player experience is more close to the user experience.

- Map world
    - Bring the map renderer in Pokemon Go to here is consistent with the gameplay in this game. The game's core mechanics are about moving, exercising, and exploring. However, the artworks in Pokemon Go are too childish. In order to increase the harmony, the artwork style can be simplicity. Here is one example: 
    - <img width="200" alt="Screen Shot 2022-01-29 at 6 35 12 PM" src="https://cdn.shopify.com/s/files/1/0511/6860/8409/files/ANNE_SCANLAN_480x480.jpg?v=1615233008">
    - the image gave sufficient information about what the object looks like but exclude some details. The decision to make this kind of artwork to be mainstream will give players a contrast between the real world and the game world. This constantly reminds players that they are in a game world. From players' point of view, they are more willing to commit things in the game.
  
Second important: the following game components are add-on components that enrich the game content, and support gameplay and player experience.
- Scene collection:
    - scene collection is a trophy collection for all scene challenges. It is a place where players can check back what happened during the time of completing challenges. It will have metadata about how long the player completes the task, their memo, any photos they took. By doing this setting, it will remind players what good happened at that moment. A good memory collection usually will give a strong impression on players, and increase the bonding between the player and the game.
- Housing and Avatar customization
    - Adding customization to the game will increase players' engagement. The house setting is allied with geocaching mechanics. The player will move physically, so they will see the building, landmark, and anything in front of them. When someone has their digital house in one location, there will be players to check out their house because they are looking different.
- Postcard
    - This is a smart way to connect players and their friends who are both in-game or not in the game. From the designer's point of view, writing a postcard to someone means the sender wants to share happiness with others. The way we write in a physical postcard is just a way to express it. In the game, the player writes an electrical postcard. The postcard could contain a story, photos, and blessings, they are very personal information. For the receiver, it could mean a lot for them.

Less important: components can be almost ignored entirely.
- Audio 
    - the audio plays a minimal role in this game. Firstly, the game almost has no storyline. Secondly, the game has very little/no control over what the environment would be in the designated location. Last, most time players need to be outdoor to play this game, it could be noisy to use a mobile phone speaker for a couple of reasons. 1. phone speakers are generally not high-quality. 2. the audio can distract players when they are driving, walking or taking a bus. 

## Future work

## Reference
- [No Man's Sky](https://en.wikipedia.org/wiki/No_Man%27s_Sky)
- [GeoGuessr](https://www.geoguessr.com/)
- [Pokemon Go](https://en.wikipedia.org/wiki/Pok%C3%A9mon_Go) 
- [Exercise and Depression](https://www.webmd.com/depression/guide/exercise-depression)
