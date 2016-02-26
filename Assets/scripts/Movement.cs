using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private GameObject generator;
    [SerializeField] private float speed;
   // private Generator generatorScript;
    private Rigidbody rb;
    private Vector3 normalVelocity;
    private bool moving;

    //private static bool oneIsStopped;
    // Use this for initialization
    private void Start()
    {
        generator = GameObject.FindGameObjectWithTag("Generator");
        //oneIsStopped = false;
        rb = GetComponent<Rigidbody>();
        moving = true;
        normalVelocity = rb.velocity = Vector3.left*speed;
<<<<<<< HEAD
        //generatorScript = generator.GetComponent<Generator>() ;
        //Debug.Log("oneIsStopped is " + generator.GetComponent<Generator>().GetOneIsStopped());
=======
>>>>>>> origin/master
    }

    private void ResumeMoving()
    {
        rb.velocity = normalVelocity;
        moving = true;
        SetOneIsStopped(false);
    }

    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
        moving = false;
        SetOneIsStopped(true);
    }

    private void SetOneIsStopped(bool isMoving)
    {
        generator.GetComponent<Generator>().SetOneIsStopped(isMoving);
    }

    void ToggleMovement()
    {
        Debug.Log("Moving is " + moving + " ,oneIsStopped is " + generator.GetComponent<Generator>().GetOneIsStopped());
        if (moving && !generator.GetComponent<Generator>().GetOneIsStopped())
        {
            Debug.Log("About to StopMoving");
            StopMoving();
        }
        else if (!moving)
        {
            Debug.Log("About to ResumeMoving");
            ResumeMoving();
        }
    }

    private void DetectMouseClick()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            ToggleMovement();
        }

    }

    void OnMouseOver()
    {
        DetectMouseClick();
    }
}
