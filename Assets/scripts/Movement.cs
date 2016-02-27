using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private GameObject generator;
    [SerializeField] private float speed;
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
    }

    private void ResumeMoving()
    {
        rb.velocity = normalVelocity;
        moving = true;
        SetOneIsStopped(false);
        Generator.instance.stoppedBlock = null;
    }

    private void StopMoving()
    {
        if (Generator.instance.stoppedBlock != null)
        {
            Generator.instance.stoppedBlock.rb.velocity = normalVelocity; ;
        }

        rb.velocity = Vector3.zero;
        moving = false;
        SetOneIsStopped(true);
        Generator.instance.stoppedBlock = this;
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
