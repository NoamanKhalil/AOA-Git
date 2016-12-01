using UnityEngine;
using System.Collections;

// written By Noaman
public class Mouse : MonoBehaviour
{
	// takes in the cursors Texture
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	//cursors position 
	public Vector2 hotSpot = Vector2.zero ; 

	void Awake ()
	{
		Cursor.SetCursor(cursorTexture, hotSpot , cursorMode);
	}
}
