# Reflection

Directions: Adjust obstacle, start, and goal locations in the inspector and press Spacebar when you want to finalize your changes and a new path will be created.

A* uses heuristics to prioritize nodes as a more efficient method that just searches between point A to point B. How it works is it will look at all possible spots on a grid that can be travelled to and it will at these points to a list.
These points then have their distance from the previous node measured and added to another list identifying it has already been checked. Once all points have been checked, the checked list then picks the node with the least amount of
distance from the previous node, and repeats the process again for the next node until it reaches the goal.

When updating in real time I had to reset the gizmos because otherwise the paths would just overlap eachother if I changed the path. 

I noticed in some instances where I could see a path from start to goal for myself the grid did not register a path. For larger grids im not sure if using Dijkstra's would be better due to performance but it also depends on what you
want your ai to do and how you want them to react.

If I'm understanding difficult terrain right (my idea is like an obstacle that you could walk through but it would be more of a hassle like mud) I would say that for however the ai measures distance between point to point, if it is measuring by
grid tiles those "difficult terrain" tiles could add extra distance to the final distance measure compared to a regular tile. For example a tile could be worth 1 unity unit and a difficult terrain tile would be worth 2 unity units.
