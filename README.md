# FallingShapes
A simple falling shapes game


Describe any important assumptions that you have made in your code.

With a game this simple, there weren’t a lot of considerations needed, though I suppose one assumption made is that falling shapes that the player doesn’t collect will always hit the killzone below. I didn’t encounter any situations where this didn’t occur due to the screenwrap code I added.


What edge cases have you considered in your code? What edge cases have you yet to handle?

I’m not sure if it can be considered an edge case, but in a literal sense, the edges of the screen where the wrapping occurs can get a little tricky. In this case, I transport the player and the falling objects to the opposite side of the screen if they move bast the visual bounds of the play area.


What are some things you would like to do if you had more time? Is there anything you would have to change about the design of your current code to do these things? Give a rough outline of how you might implement these ideas.

I would implement a proper UI Panel Management system and an Event System to handle things like updating the score. In my usual development projects I have full featured systems for both of these points.

