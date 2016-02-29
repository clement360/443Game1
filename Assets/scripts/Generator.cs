using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEditorInternal;

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
        int randomX = Random.Range(GameManager.instance.playerPos, GameManager.instance.playerPos + 9);
		Instantiate(block, new Vector3(randomX, 8, 0), Quaternion.identity );
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