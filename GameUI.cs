using SFML.Graphics;
using SFML.System;

public class GameUI
{
	private Vector2f windowSize;
	private float boxSize;
	private Padding padding;
	private Vector2f startingPoint;
	private float padSize;
	private Vector2f paddedPos;
	private Font font;
	private TextListAdder textList;
	private List<Text> targetCHARlist;
	private ContentGenerator content;
	private Vector2f size;
	private Shape[] squares;
	private GameData data;
	public GameUI(GameData wind)
	{
		windowSize = new Vector2f(1300, 700);

		padding = new Padding();
		padSize = 100f;
		startingPoint = new Vector2f(0, 0.5f);
		paddedPos = padding.GetPadding(windowSize, startingPoint, padSize);
		font = new Font("C:/Windows/Fonts/arial.ttf");
		content = new ContentGenerator();

		data = wind;
	}




	public void ToDraw()

	{
		data.window.Clear(Color.Green);
		DrawCharArray();



		data.window.Display();
		// window.Draw (pic);

	}
	// /Adding letters of the targetWord to a new Text list for further Drawing
	// textList = new TextListAdder();
	// targetCHARlist = textList.AddTexttoList(sp, font);


	private void DrawCharArray()
	{
		if (data != null && data.ifMatch != null)
		{
			char[] array = data.ifMatch.ToCharArray();
			ContentGenerator content = new ContentGenerator();
			Vector2f initialpos = paddedPos;
			float space = 0;

			for (int i = 0; i < array.Length; i++)
			{
				string oneChar = Convert.ToString(array[i]);
				Text letter = content.MakeLetters(oneChar, font);
				Shape square = content.MakeSquare();
				square.Position = initialpos + new Vector2f(space, 0);
				space += 220f;
				float height = square.GetGlobalBounds().Height;
				float width = square.GetGlobalBounds().Width;
				letter.Position = new Vector2f(square.Position.X + width / 2f, (square.Position.Y - height / 2f) - 20f);

				data.window.Draw(square);
				data.window.Draw(letter);
			}
		}
	}

	// for (int i = 0; i<targetCHARlist.Count; i++)
	// {

	// 	Vector2f space = new Vector2f(i * 220f, 0);
	// 	targetCHARlist[i].Position = singleSpace + paddedPos + space;
	// 	if (pi)
	// 	{
	// 		targetCHARlist[i].Color = new Color(Color.Black);
	// }

	// 	else
	// {
	// 	targetCHARlist[i].Color = new Color(Color.Transparent);
	// }
	// }


	// delta = clock.Restart().AsSeconds();
	// angle += angleSpeed * delta;



}