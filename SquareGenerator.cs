using SFML.Graphics;
using SFML.System;
using SFML.Window;
public class SquareGenerator
{
    public Shape [] GetShape (Vector2f size, uint numberoffigures )
    {
        Shape [] array = new Shape [numberoffigures];
        for (int i = 0; i<numberoffigures; i++)
        {
            
            Shape figure = new RectangleShape(size);
            array [i] = figure;
        }
        return array;
        
    }
}