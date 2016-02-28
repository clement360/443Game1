using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public GameObject startBlock;
	public GameObject finishBlock;


	public void SetupScene()
	{
		// place the start block and put the penguin on top
		Instantiate(startBlock, new Vector3(-8f, 0, 0), Quaternion.identity );
		startBlock.tag = "Player";

		Instantiate(finishBlock, new Vector3(8f, 0, 0), Quaternion.identity );
	}

}
