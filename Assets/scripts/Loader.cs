using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public GameObject gameMananger;

	void Awake () {
		if (GameManager.instance == null)
			Instantiate (gameMananger);
	}

}
