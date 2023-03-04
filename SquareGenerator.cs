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
            figure.Scale = new Vector2f(0.7f, 0.7f);
            figure.FillColor = new Color(Color.White);
            figure.OutlineColor = new Color (255,0,0);
            float squarseHeight = figure.GetLocalBounds().Height;
            float squareWidth = figure.GetLocalBounds().Width;
            figure.Origin = new Vector2f(0,squarseHeight/2f);
            
        }
        return array;
        
    }

    
}