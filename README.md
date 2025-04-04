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
