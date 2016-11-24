using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void LoadScene (string xyz)
	{
		SceneManager.LoadScene (xyz, LoadSceneMode.Additive);
	}

	public void quit ()
	{
		Application.Quit (); 
	}
}
