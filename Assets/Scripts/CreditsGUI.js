public var f : Font;
public var logo : Texture;

function OnGUI () {
	GUI.skin.font = f;
	GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), logo);

	GUI.Label(Rect(Screen.width/2 - 200, Screen.height/2 - 50, 400, 200), "Game Design:\tErik Martin\nCode:\t\tErik Martin\nArt:\t\tErik Martin\nEverything Else:\tErik Martin");
}