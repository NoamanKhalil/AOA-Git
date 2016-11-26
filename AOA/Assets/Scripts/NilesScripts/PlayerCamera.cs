using System.Collections;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	// Use this for initialization
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
	public float zMDF;

	Transform Player;

	void LateUpdate () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		transform.position = new Vector3(Mathf.Clamp(Player.position.x, xMin, xMax), transform.position.y, Mathf.Clamp(Player.position.z-zMDF, zMin, zMax));
	}
}
