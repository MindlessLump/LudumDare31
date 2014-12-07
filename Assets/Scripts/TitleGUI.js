public var f : Font;
public var logo : Texture;

function OnGUI()
{
	GUI.skin.font = f;
	GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), logo);

	if(GUI.Button(Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "Start Game"))
	{
		Application.LoadLevel("scene");
	}
	if(GUI.Button(Rect(Screen.width/2 - 100, Screen.height/2 + 60, 200, 100), "Credits"))
	{
		Application.LoadLevel("credits");
	}
}