using SFML.Graphics;
using SFML.System;
using SFML.Window;
VideoMode poop = new VideoMode(1300,700);
RenderWindow window = new RenderWindow(poop, "SFML.NET");

Vector2f windowSize = new Vector2f (1300,700);
ListCreator Dict = new ListCreator();
// paddding adding

Padding padding = new Padding();
Vector2f startingPoint = new Vector2f (0f,0.5f);
float padSize = 100f;
Vector2f paddedPos = padding.GetPadding (windowSize, startingPoint, padSize);

// Adding a list
string [] allWords = File.ReadAllLines("C:\\Users\\kseni\\Documents\\HANGMAN.txt");
List <string> dictionaryONE = Dict.RemoveWords (allWords,5);

// Choosing a random word
WordChooser Ran = new WordChooser();
string targetWord = Ran.chooseTargetWord(dictionaryONE);
Console.WriteLine (targetWord);

//Showing the letters on the screen

Font font = new Font("C:/Windows/Fonts/arial.ttf");


// text.Color = new Color (Color.Black);
// text.CharacterSize = 60;

// float textWidth = text.GetLocalBounds().Width;
// float textHeight = text.GetLocalBounds().Height;

//Placing letters into each box
 LetterGetter jon = new LetterGetter ();
 List <string> sp = jon.GetLetters (targetWord);
 List <Text> boom = new List<Text>();
for (int i=0; i< sp.Count; i++)
{
    Text letters = new Text (sp[i], font);
    boom.Add (letters);

    letters.Color = new Color (Color.Black);
    letters.CharacterSize = 100;
    float letterHeight = letters.GetLocalBounds().Height;
    float letterWidth = letters.GetLocalBounds().Width;  
    letters.Origin = new Vector2f (0, letterHeight/2f);
    
    Vector2f space = new Vector2f (i*220f, 0);
    letters.Position = paddedPos +space;
}


// Closing window
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


// string path = "C:\\temp\\Equipment_Popup_Detail2.png";
// Texture texture = new Texture (path);
// texture.Repeated = true;


// Shape square = new RectangleShape (new Vector2f (100f,100f));

// square.Texture = new Texture("C:\\Users\\kseni\\Professional coding\\SFML\\GUI PRO Kit - Casual Game\\GUI PRO Kit - Casual Game\\Preview\\_Common_Icons.png");


SquareGenerator sh = new SquareGenerator();
Vector2f boxSize = new Vector2f (300f,300f);
Shape [] squares = sh.GetShape(boxSize,5);

for (int i = 0; i<squares.Length; i++)
{
    Shape square = squares [i];  
    Vector2f space = new Vector2f (i*220f, 0);
    square.Position = paddedPos +space;
}

// Sprite pic = new Sprite (texture);
// float picWidth = pic.GetLocalBounds().Width;
// float picHeight = pic.GetLocalBounds().Height;
// pic.Origin = new Vector2f(picWidth, picHeight / 2f);
// pic.Position = new Vector2f (window.Size.X, window.Size.Y/2f);
// pic.Scale = new Vector2f(0.1f,0.1f);


// float proWidth = pro.GetLocalBounds().Width;
// float proHeight = pro.GetLocalBounds().Height;

// float xOffset = text.GetLocalBounds().Left;
// float yOffset = text.GetLocalBounds().Top;

// text.Origin = new Vector2f(textWidth / 2f + xOffset, textHeight / 2f + yOffset);
// text.Position = new Vector2f(window.Size.X / 2f, window.Size.Y / 2f);

// pro.Origin = new Vector2f(0, proHeight / 2f);
// pro.Position = new Vector2f(0, window.Size.Y / 2f);

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
    // text.Rotation = angle;
    for (int b =0; b<squares.Length; b++)
    {
    window.Draw(squares[b]);
    };
    for (int b =0; b<boom.Count; b++)
    {
        window.Draw(boom[b]);
    }
    // window.Draw(pro);
    window.Display();
    // window.Draw (pic);
}
