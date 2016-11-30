using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero ; 

	void Awake ()
	{
		Cursor.SetCursor(cursorTexture, hotSpot , cursorMode);
	}


	void Update ()
	{
		
	}


	void Start ()
	{
		
	}
//	void OnMouseEnter() {
//		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
//	}
//	void OnMouseExit() {
//		Cursor.SetCursor(null, Vector2.zero, cursorMode);
//	}
}
