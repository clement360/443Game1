using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{

	public int updateRate;
	private int frame;

    public static Generator instance = null;
	[NonSerialized] public BlockController stoppedBlock;
	public GameObject block;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        stoppedBlock = null;
    }

    // Use this for initialization
    void Start ()
	{
		frame = 0;
	}

    public void generateBlock()
	{
		int randomX = Random.Range(-9, 9);
		GameObject down = Instantiate(block, new Vector3(randomX, 8, 0), Quaternion.identity ) as GameObject;
		BlockController downController = (BlockController)down.GetComponent<BlockController> ();
		downController.setDirection (Vector3.down);


		int randomY = Random.Range (-5, 5);
		GameObject right = Instantiate(block, new Vector3(-11, randomY, 0), Quaternion.identity ) as GameObject;
		BlockController rightController = (BlockController)right.GetComponent<BlockController> ();
		rightController.setDirection(Vector3.right);
	}

    void FixedUpdate()
    {
		if (frame == updateRate) 
		{
			generateBlock();
			frame = 0;
		}
		frame++;
    }

}