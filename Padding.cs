    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;
    
public class Padding
{

    public Vector2f GetPadding (Vector2f windowSize, Vector2f startingPoint, float padding)
    {
     Vector2f inner = new Vector2f (windowSize.X - (2* padding), windowSize.Y- (2* padding));
       float padpx =  (inner.X*startingPoint.X)+ padding;
       float padpy =  (inner.Y*startingPoint.Y) + padding;
       Vector2f paddedPos = new Vector2f (padpx, padpy);
      
        
     return paddedPos;
    }
}