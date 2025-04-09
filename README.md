# topdown2dproject-study

Joining the 150 days challenge. In this project you will see my progress in learning C# & Unity

Second day:
- Added simple enemies, they can hit player and decrease the score. If score = 0 and player hits enemy -> both die
- Added some visual effects
- Refactor few parts of code..It's still not good.
Next day will add new features, rework AI and refactore all remaining parts of code

 Day 3:
 - Reworked enemies behaviour, was Sin-like moving. Now enemies got patrol route
 - Added Nodes to the main scene
 - Refactor remaining parts of code
Next day, I will revise the patrol route. I want enemies to dynamically change their path after reaching the final node in their current sequence.
For example: Suppose there are 10 nodes. An enemy might follow a route like 8 → 5 → 1 initially. Once they reach the final node (Node 1), the system should generate a new randomized sequence of nodes for their updated patrol route.

Day 4:
- Reworked enemy behavior. Now they change patrol route after reaching last (in my case 3d) node
Next day, I'll refactor some parts of code and play with enemies behaviour again, cause it's not ideal.

Day 5:
- Effect for coins. Now it's has simple "Boom" effect
- Shake effect. When the enemy touches the player the camera shakes a little
- Effect for player. When the player touches the enemy the player starts blinking for time..
Next day, I'ff refactor some parts of code, add effects to enemy and add UI (menu, loose screen and death screen)
Forgot to add day5 commit :D

Day 6:
- Added player properties (Healthm, Hunger, Stamina). Hunger can decrease/incresase (decreases every frame & increases if player eats smthg).
- Reworked effects logic. It's now depends on new script
- Added interface IEatable
- Reworked UI (for debugging)
- Added script EatableItem (for future items)
Next day, I'll add debug for enemy (OnDrawGizmos()), add Increase/Decrease for stamina, add Inventory and some effects 
