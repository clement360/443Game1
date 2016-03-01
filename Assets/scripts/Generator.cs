using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{

    public int updateRate;
    public int waveRate;
    public int enemyRate;

    private int frame;
    private int frame2;
    private int frame3;

    private int randomX;
    private int randomY;

    public static Generator instance = null;
    [NonSerialized] public BlockController prevBlock;
    [NonSerialized] public BlockController stoppedBlock;

    public GameObject block1;
    public GameObject block2;
    public GameObject waveBlock;
    public GameObject enemyBlock;

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
    void Start()
    {
        frame = 0;
        frame2 = 0;
        frame3 = 0;
    }

    public void generateBlock()
    {
        randomX = Random.Range(PlayerManager.instance.playerPosX - 3, PlayerManager.instance.playerPosX + 3);
        randomY = Random.Range(PlayerManager.instance.playerPosY - 3, PlayerManager.instance.playerPosY + 3);

        GameObject right = Instantiate(block1, new Vector3(-11, randomY, 0), Quaternion.identity) as GameObject;
        BlockController rightController = (BlockController)right.GetComponent<BlockController>();
        rightController.setDirection(Vector3.right);

        GameObject down = Instantiate(block2, new Vector3(randomX, 8, 0), Quaternion.identity) as GameObject;
        BlockController downController = (BlockController)down.GetComponent<BlockController>();
        downController.setDirection(Vector3.down);
    }

    IEnumerator generateWave() {
        int xVal = PlayerManager.instance.playerPosY;
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
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator generateEnemy()
    {
        if (PlayerManager.instance.playerPosX > -4)
        {
            Vector3 position = new Vector3(-11, PlayerManager.instance.playerPosY, 0);

            GameObject right = Instantiate(enemyBlock, position, Quaternion.identity) as GameObject;
            BlockController rightController = (BlockController)right.GetComponent<BlockController>();
            rightController.setDirection(Vector3.right);

            yield return new WaitForSeconds(.1f);
        }
    }

    void FixedUpdate()
    {
		if (frame == updateRate + GameManager.instance.Level*2) 
		{
            generateBlock();
			frame = 0;
		}

        if (frame2 == waveRate * updateRate + GameManager.instance.Level * 2)
        {
            StartCoroutine(generateWave());
            frame2 = 0;
        }

        if(frame3 == enemyRate * updateRate && GameManager.instance.Level >= 3)
        {
            StartCoroutine(generateEnemy());
            frame3 = 0;
        }

        frame3++;
        frame2++;
		frame++;
    }

}