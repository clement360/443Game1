using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public GameObject startBlock;
	public GameObject finishBlock;

	public void SetupScene()
	{
		Instantiate(startBlock, new Vector3(-8f, 0, 0), Quaternion.identity );
		Instantiate(finishBlock, new Vector3(8f, 0, 0), Quaternion.identity );
	}

}
