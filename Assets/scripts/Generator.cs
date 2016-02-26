using System;
using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class Generator : MonoBehaviour
{
    private bool oneIsStopped;
    [SerializeField] private GameObject block;

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