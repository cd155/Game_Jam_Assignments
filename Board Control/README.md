## Introduction
Many new students or graduates from their programs may feel curious about different paths of taking courses. What happened if I decide to take my Chemistry I class before my Calculus I class? Could the new path reduce terms length from fours years and a half to just four years? Many programs have their curriculum, and it has some restrictions for taking courses.

- Prerequisite: course A must have been taken before taking course B.
- Corequisite: course A must be taken with course B at the same time unless the student has already taken course A.
- Freshman/Sophomore/Junior/ Status: courses need to be taken at specific years
- A student may only take 18 credits per semester, over 18 credits course is just too much.
- Some classes are only offered in Fall/Spring semester.

The game will be turn-based. Each term mimic one semester. The goal is to complete the program with as few semesters as possible because an additional semester will cost more money. 
### Example
This is the start UI. In options A, B, C, you can select classes you want to take this semester, and then click confirm to move next semester.

<img width="200" alt="Screen Shot 2022-01-29 at 6 35 12 PM" src="https://user-images.githubusercontent.com/16947266/153955186-9f2f8bf6-7f6f-4933-bf3f-582631f3e8b9.png">

In the end, the question board will announce how many semesters you took to graduate.

<img width="200" alt="Screen Shot 2022-01-29 at 6 35 12 PM" src="https://user-images.githubusercontent.com/16947266/153955602-fed60916-7317-400c-b771-d29c251bb9ff.png">

### Board Control mechanics
#### Board
In each turn, the player will decide which course will take. The board is the curriculum, and players have to plan smartly to complete all the required courses to graduate. The player has to guess what is the Prerequisite or Corequisite based on the title name of the class and availability of options. For example,
- Math I => Math II => Math III

it is not hard to guess that Math I is the prerequisite of Math II. Once the class be taken, it will display on the graph diagram.

#### Control
The player control what class will take in each turn. With limited resources (Max 18 credits) in one term. The player has to try to make reasonable decisions to maximize course taking and minimize the program length. In other words, it is also an optimization problem.

The order of taking each class can result in different paths. There will be a bottleneck if players don't diversify their courses. Avoiding the bottleneck help players have more options to choose more optimized choices.

## Gameplay
This is a strategy game aiming to give players a chance to re-play or simulate their curriculum path.

### Challenge and Action
- Deduction Challenge
  - the player has to deduct what could be a prerequisite or corequisite based on the availability in each turn. Successfully guessing the prerequisite and corequisite helps the player to plan the course.
- Memory Challenge
  - the player may have to remember what course he/she already took, this information help to plan the course because some course will have multiple prerequisite or corequisite. This makes the situation more complicated.
- Calculation Challenge
  - each course will have certain credits. The player has to sum up all credits and make sure it is not excess to the limitation.

#### Why made this decision 
- For players who play this game, I assume they have some background knowledge about the curriculum they choose.  The deduction challenge fit in this scenario because he/she already knows some norm of the curriculum and able to deduct the curriculum.
- The memory challenge balance the level of difficulties. Adding memory challenges will increase the difficulties of the game as some advanced players may enjoy more difficult challenges.
- The calculation challenge is more like a side effect. Max 18 credits rule mimics a real-world situation that students are only able to take a certain amount of work in a semester. It makes the game to be more real and reasonable.

## Player Experience
The average time of one game is about 5-8 minutes. During this time, the player has to figure out how to graduate. It is designed for a competitive game. The winning condition is to try to click the confirm button as little as possible. Each click means one semester. The designer can set different thresholds which represent the level of difficulties. At the highest level, there are probably only have one/two paths to graduate in minimum terms. This somehow makes players stressed because the shortest path usually is not easy to find out. Some people have failed multiple times to recognize the course pattern. Some players may need to use a pen or paper to draw/write the relationship between classes down on the paper.

#### Why made this decision 
The game simulates the real-world curriculum and gives players another chance to simulate each decision they made in the past. Graduating from university/college usually means a milestone to students, so they may want to find out what they can do differently. The player may feel **empathy** with the designer if some parts of the game context are similar to his/her experience.

This game is targeted at a small group of people who are interesting in the deduction scene of the game. With more content added on, the path of graduation can be increasingly significant. The designer needs to carefully think about the level of difficulties because it could reach a level only computers can solve the problem. This is **bad** if it happened.

## Aesthetics
With one week limitation, this game will be more like a text-based game with some UI, like buttons, a display board. In the future, I intend to replace all text with related animation and pictures.

#### Why made this decision 
The text-based game seems very boring because most people really don't like to read texts. With property images/icons, some text-based UI can be replaced in the future. This is aiming to increase the readability. The following is the graph node about the relationship for some courses. This is just a demo of how to transfer some text into a graph.

<img width="480" alt="Screen Shot 2022-01-29 at 6 35 12 PM" src="https://user-images.githubusercontent.com/16947266/152694139-73e7e0ef-8a48-453f-b590-ae3005058516.png">

- ----> single arrow means a prerequisite
- <---->> double arrow means a corequisite

How to draw the graph can be a difficult task as well. Currently, the graph is hard-coded at the UI level. This is not ideal, because I can't reuse most code. If I want to add more content, the current UI is very likely to be useless. **A better design to visualize the graph is necessary.**

#### Future work
- The arrow should be hidden. 
  - How to display the arrow between nodes can be difficult. It involves the relationship between the two nodes. 
- All nodes currently are hard-coded, there should be a generic way to generate these nodes, so more contents can be added easier.
- Audio can be added
- More rules
  - Due to time limitations, only prerequisites be added to current rules.
- Credit limitation should be introduced
  - players can choose more classes as long as all classes don't excess 18 credits in one term.

## Reference
[ISE Curriculum and Courses](https://ise.engineering.uiowa.edu/sites/ise.engineering.uiowa.edu/files/ise_ug_curriculum_ay2020-2021_updated_march_2021.pdf)
