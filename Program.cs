using SFML.Graphics;
using SFML.System;
using SFML.Window;
VideoMode poop = new VideoMode(1300, 700);
RenderWindow window = new RenderWindow(poop, "SFML.NET");
Game mygame = new Game(window);


while (window.IsOpen)
{
	mygame.Play();
}


