using System;
using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class Generator : MonoBehaviour
{

    public static Generator instance = null;
	[NonSerialized] public BlockController stoppedBlock;
	[SerializeField] private GameObject block;

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

	}

    public void generateBlocks()
    {
        Instantiate(block, new Vector3(0, 0, 5), Quaternion.identity );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            generateBlocks();
        }
    }

}