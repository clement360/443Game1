using System;
using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class Generator : MonoBehaviour
{

    public static Generator instance = null;
    private bool oneIsStopped;
    [SerializeField] private GameObject block;
    public Movement stoppedBlock;

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
	    oneIsStopped = false;
        
        //Debug.Log("oneIsStopped is " + oneIsStopped);
	}

    public void SetOneIsStopped(bool moving)
    {
        oneIsStopped = moving;
    }

    public bool GetOneIsStopped()
    {
        return oneIsStopped;
    }

    public void generateBlocks()
    {
        Debug.Log(oneIsStopped);
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