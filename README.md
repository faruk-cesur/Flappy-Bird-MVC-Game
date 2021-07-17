# Flappy Bird with MVC Design Pattern
### This repository is created for Patika.dev Mobile Game Bootcamp V (Week 3 Homework)
---
https://user-images.githubusercontent.com/74262200/126029982-672478e4-8eb2-4fe2-b3ee-064b08a5d84a.mp4


---
# I developed a clone of the Flappy Bird game from scratch with to improve myself. I used MVC Design Pattern for it. I hope you like it :)
- Articles about MVC Design Pattern =>
[Reference Link 1](https://www.toptal.com/unity-unity3d/unity-with-mvc-how-to-level-up-your-game-development)
[Reference Link 2](https://www.jacksondunstan.com/articles/3092)

### What is Model View Controller (MVC) Design Pattern?
- Model View Controller (MVC) Design Pattern
The model view controller is a very common design pattern that has been around for quite some
time. This pattern focuses on reducing spaghetti code by separating classes into functional parts.
Recently I have been experimenting with this design pattern in Unity and would like to lay out a
basic example.
A MVC design consists of three core parts: Model, View and Controller.

### Model: 
The model is a class representing the data portion of your object. This could be a player,
inventory or an entire level. If programmed correctly, you should be able to take this script and use
it outside of Unity.
### Note a few things about the Model:
- It should not inherit from Monobehaviour
- It should not contain Unity specific code for portability
- Since we are avoiding Unity API calls, this can hinder things like implicit converters in the
Model class (workarounds are required)

### View: 
The view is a class representing the viewing portion tied to the model. This is an appropriate
class to derive from Monobehaviour. This should contain code that interacts directly with Unity
specific APIs including OnCollisinEnter, Start, Update, etc...
- Typically inherits from Monobehaviour
- Contains Unity specific code

### Controller: 
The controller is a class that binds together both the Model and View. Controllers keep
both Model and View in sync as well as drive interaction. The controller can listen for events from
either partner and update accordingly.
- Binds both the Model and View by syncing state
- Can drive interaction between partners
- Controllers may or may not be portable (You might have to use Unity code here)
- If you decide to not make your controller portable, consider making it a Monobehaviour to
help with editor inspecting

![](http://www.stardust.ch/wp-content/uploads/2016/06/MVC1.png)
