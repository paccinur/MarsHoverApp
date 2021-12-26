# MarsHoverApp

This repository is my solution to the Google coding challenge **#marsrovertechchallenge** (https://code.google.com/archive/p/marsrovertechchallenge/). 

In this console application, you can define an area on Mars and also define your Hover(s) on top of it to give directions(one time per hover).

## How to Run the Program

Simply download the repository to your local machine and open it with Visual Studio, then run the code. It will pop up a console for you to interact with it.
No further download required.

## How to Play
All you need to do is to first input length and the width of the area to create, leftmost bottom is the 0,0 coordinates. Afterwards, program will ask you to also define a starting position for the Hover(s) with the given coordinates and which way it is facing.

An example is as follows:

* 5 5

* 1 2 N

These two commands create a 5x5 area, and place a hover on the grid with X axis 1, Y axis 2 facing north. 

You cannot place the hover outside the created grid area.

Afterwards program will wait on a command to move this hover to anywhere that it is **able** to go. An example is as follows;

- MLMR

This command moves the hover once (M) from where it is facing onwards, then turns it to its current Left(L), moves it once, then turns it to its current Right (R).

So for 1 2 N starting point hover, it becomes 2 1 N.

You can add as much hovers (and move each **once**) as you want in the grid, as long as they do not clash with each other.

You can quit the by typing "exit", after any round of hover initiation (create, move).
