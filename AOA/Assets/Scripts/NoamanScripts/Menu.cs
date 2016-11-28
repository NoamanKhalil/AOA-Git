using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void LoadScene (string xyz)
	{
		// dont use additive 
		SceneManager.LoadScene (xyz, LoadSceneMode.Single);
	}

	public void quit ()
	{
		Application.Quit (); 
	}
}
