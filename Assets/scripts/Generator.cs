using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{

	public int updateRate;
    public int waveRate;
	private int frame;
    private int frame2;
    private int randomX;
	private int randomY;

    public static Generator instance = null;
    [NonSerialized] public BlockController prevBlock;
	[NonSerialized] public BlockController stoppedBlock;

	public GameObject block1;
    public GameObject block2;
    public GameObject waveBlock;

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
		randomX = Random.Range (GameManager.instance.playerPosX-2, GameManager.instance.playerPosX+2);
		randomY = Random.Range (GameManager.instance.playerPosY - 2, GameManager.instance.playerPosY + 2);

		GameObject down = Instantiate(block1, new Vector3(randomX, 8, 0), Quaternion.identity) as GameObject;
		BlockController downController = (BlockController)down.GetComponent<BlockController> ();
		downController.setDirection (Vector3.down);

		GameObject right = Instantiate(block2, new Vector3(-11, randomY, 0), Quaternion.identity ) as GameObject;
		BlockController rightController = (BlockController)right.GetComponent<BlockController> ();
		rightController.setDirection(Vector3.right);
	}

    IEnumerator generateWave() {
        int xVal = GameManager.instance.playerPosY;
        bool rand = Random.Range(0, 20) % 2 == 0;
        Vector3 position;

        for (int i = 0; i < 5; i++)
        {
            if (rand) {
                position = new Vector3(-11, xVal + i * .5f, 0);
            } else {
                position = new Vector3(-11, xVal - i * .5f, 0);
            }
            GameObject right = Instantiate(waveBlock, position, Quaternion.identity) as GameObject;
            BlockController rightController = (BlockController)right.GetComponent<BlockController>();
            rightController.setDirection(Vector3.right);
            yield return new WaitForSeconds(.3f);
        }
    }

    void FixedUpdate()
    {
		if (frame == updateRate) 
		{
			generateBlock();
			frame = 0;
		}

        if (frame2 == waveRate * updateRate)
        {
            StartCoroutine(generateWave());
            frame2 = 0;
        }
        frame2++;
		frame++;
    }

}