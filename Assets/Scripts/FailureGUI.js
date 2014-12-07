public var f : Font;
public var logo : Texture;

function OnGUI () {
	GUI.skin.font = f;
	GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), logo);

	GUI.Label(Rect(Screen.width/2 - 200, Screen.height/2 - 50, 400, 100), "You failed, but you did manage to kill a few enemies.\nBetter luck next time.");
	if(GUI.Button(Rect(Screen.width/2 - 100, Screen.height/2 + 60, 200, 100), "Main Menu")) {
		Application.LoadLevel("main");
	}
	if(GUI.Button(Rect(Screen.width/2 - 100, Screen.height/2 + 170, 200, 100), "Credits")) {
		Application.LoadLevel("credits");
	}
}