using SFML.Graphics;
using SFML.System;

public class TextListAdder
{
	public List<Text> AddTexttoList(List<string> sp, Font font)
	{
		List<Text> boom = new List<Text>();
		for (int i = 0; i < sp.Count; i++)
		{
			Text letters = new Text(sp[i], font);
			boom.Add(letters);

			letters.CharacterSize = 190;
			float letterHeight = letters.GetLocalBounds().Height;
			float letterWidth = letters.GetLocalBounds().Width;
			letters.Origin = new Vector2f(letterWidth / 2f, 0);

		}
		return boom;

	}
}