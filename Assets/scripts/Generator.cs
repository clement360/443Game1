using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class Generator : MonoBehaviour
{
    private bool oneIsStopped;

	// Use this for initialization
	void Start ()
	{
	    oneIsStopped = false;
	}

    public void SetOneIsStopped(bool moving)
    {
        oneIsStopped = moving;
    }

    public bool GetOneIsStopped()
    {
        return oneIsStopped;
    }

	public void generateBlocks ()
	{
		
	}
}