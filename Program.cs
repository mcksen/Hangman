using SFML.Graphics;
using SFML.System;
using SFML.Window;
VideoMode poop = new VideoMode(500,500);
RenderWindow window = new RenderWindow(poop, "SFML.NET");


window.Closed += HandleClose; //when close button is pressed just close the window

void HandleClose(object? sender, EventArgs e)
{
    window.Close();
}

window.KeyPressed += HandleKeyPress;

void HandleKeyPress(object? sender, KeyEventArgs e)
{
    if (e.Code == Keyboard.Key.Escape)
    {
        window.Close();
    }  
}


string path = "C:\\temp\\Equipment_Popup_Detail2.png";
Texture texture = new Texture (path);
texture.Repeated = true;


// Shape square = new RectangleShape (new Vector2f (100f,100f));

// square.Texture = new Texture("C:\\Users\\kseni\\Professional coding\\SFML\\GUI PRO Kit - Casual Game\\GUI PRO Kit - Casual Game\\Preview\\_Common_Icons.png");

Shape square1 = new RectangleShape (new Vector2f (100f,100f));
Shape square2 = new RectangleShape (new Vector2f (100f,100f));
Shape square3 = new RectangleShape (new Vector2f (100f,100f));
Shape square4 = new RectangleShape (new Vector2f (100f,100f));
Shape [] squares = new Shape [] {square1, square2, square3, square4};

for (int i = 0; i<squares.Length; i++)
{
    Shape square = squares [i];
    
    float squarseHeight = square.GetLocalBounds().Height;
    float squareWidth = square.GetLocalBounds().Width;
    square.Scale = new Vector2f(0.4f,0.4f);
    square.FillColor = new Color(Color.White);
    square.OutlineColor = new Color (255,0,0);
    square.Origin = new Vector2f(squareWidth/2f,0);
    float space = i*60f;
    square.Position = new Vector2f((window.Size.X/2f)+space, window.Size.Y/2f);

}


Sprite pic = new Sprite (texture);
float picWidth = pic.GetLocalBounds().Width;
float picHeight = pic.GetLocalBounds().Height;


pic.Origin = new Vector2f(picWidth, picHeight / 2f);
pic.Position = new Vector2f (window.Size.X, window.Size.Y/2f);
pic.Scale = new Vector2f(0.1f,0.1f);

Font font = new Font("C:/Windows/Fonts/arial.ttf");
Text text = new Text("KI!", font);
Text pro = new Text ("ksen is pro", font);
text.CharacterSize = 60;
pro.CharacterSize = 37;
float textWidth = text.GetLocalBounds().Width;
float textHeight = text.GetLocalBounds().Height;

float proWidth = pro.GetLocalBounds().Width;
float proHeight = pro.GetLocalBounds().Height;

float xOffset = text.GetLocalBounds().Left;
float yOffset = text.GetLocalBounds().Top;

text.Origin = new Vector2f(textWidth / 2f + xOffset, textHeight / 2f + yOffset);
text.Position = new Vector2f(window.Size.X / 2f, window.Size.Y / 2f);

pro.Origin = new Vector2f(0, proHeight / 2f);
pro.Position = new Vector2f(0, window.Size.Y / 2f);

// float xPos = (window.Size.X / 2f) - (textWidth/2f);
// float yPos = (window.Size.Y / 2f) - (textHeight/2f);
// text.Position = new Vector2f (xPos, yPos);
// string poops = "x=" + xPos + "win=" + textWidth;
// Console.WriteLine (poops);

Clock clock = new Clock();
float delta = 0f;
float angle = 0f;

float angleSpeed = 90f;

while (window.IsOpen)
{
    delta = clock.Restart().AsSeconds();
    angle += angleSpeed * delta;
    window.DispatchEvents();
    window.Clear(Color.Green);
    text.Rotation = angle;
    for (int i =0; i<squares.Length; i++)
    {
    window.Draw(squares[i]);
    };
    // window.Draw(text);
    // window.Draw(pro);
    window.Display();
    // window.Draw (pic);
}
