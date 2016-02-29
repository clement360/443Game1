using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

	public Text finishText;
	 
	private List<GameObject> touchingFinish = new List<GameObject>();

	// Use this for initialization
	void Start () {
		finishText.text = "";
		finishText.gameObject.SetActive (false);
		touchingFinish.Clear ();
	}

	private bool touchingPlayer() {
		for (int i = 0; i < touchingFinish.Count; i++) {
			if (touchingFinish[i].tag == "Player")
				return true;
		}

		return false;
	}

	private void DetectMouseClick()
	{
		if (Input.GetKeyDown("mouse 0"))
		{
			if (touchingPlayer()) {
				finishText.text = "Goal Reached!";
				finishText.gameObject.SetActive (true);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Block")
			touchingFinish.Add (other.gameObject);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Block")
			touchingFinish.Remove (other.gameObject);
	}

	void OnMouseOver()
	{
		DetectMouseClick();
	}
}
