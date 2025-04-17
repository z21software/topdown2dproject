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

Day 7:
- Refactor code. It's now more component oriented. 1 component for 1 task
- Fixed bugs with health & hunger parametres
- Added new UI for inventory (but it is not working correct)
- Added inventory
Next day, I'll work more with UI and effects. Maybe rework inventory logic (grid inventory idk)

Day 8:
I experimented with the inventory. I couldn't make something that I liked, so I decided to abandon the inventory for now and focus on other mechanics.

Day 9:
Tried again to work with inventory, but I still dont't like the result. 
- Refactor player properties (health, hunger, thirsty), add new base class
- Add new property "thirsty"
- Added "drinkable item" script & interface IDrinkable
Next day I want to create lake to refill thirsty parameter. I want to deepen the survival mechanics and after that develope weapons

Day 10:
Night code before going to sleep:
- Rework IDrinkable
- Add lake
- Add Player interaction with lake to drink water
Water can have different qualities and may even harm the player. This mechanic makes drinkable items or water sources more unique. For example:
- Water from a lake is unsafe but can fully replenish thirst from 0 to 100.
- Water from a well is safe and can replenish thirst from 0 to 50. However, if the player drinks enough to reach 100 thirst using well water, it grants a stamina bonus.
This mechanic will be implemented after I get some sleep. 😊
I’ll also add radiation and radioactive zones, as well as mechanics for cold and overheating.

Day 11:
-Added inventory
I changed my mind about making a full system of radiation, overheating and hypothermia. I decided to make an inventory system after all. A GRID system similar to Tarkov. Within 2 days the inventory will be fully functional.

Day 12:
I forgot to commit yesterday, so added today

Day 13:
Trying to fix an error

Day 14:
Stuck with an issue. trying to fully rework system, because my solution didn't work

