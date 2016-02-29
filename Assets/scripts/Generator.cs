using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEditorInternal;

public class Generator : MonoBehaviour
{

	public int updateRate;
	private int frame;
    private int randomX;

    public static Generator instance = null;
    [NonSerialized] public BlockController prevBlock;
	[NonSerialized] public BlockController stoppedBlock;
	public GameObject block;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        stoppedBlock = null;
        prevBlock = null;
    }

    // Use this for initialization
    void Start ()
	{
		frame = 0;
	}

    public void generateBlock()
	{
        if (GameManager.instance.playerPos < 0)
            randomX = Random.Range(GameManager.instance.playerPos+2, GameManager.instance.playerPos + 6);
        else
			randomX = Random.Range(GameManager.instance.playerPos+2, Random.Range(GameManager.instance.playerPos+3,GameManager.instance.playerPos + 6));

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