using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject generator;
    [SerializeField] private float speed;

    
    private Rigidbody rb;
    private Vector3 normalVelocity;
    private bool moving;

    //private static bool oneIsStopped;
    // Use this for initialization
    private void Start()
    {
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
        if (moving && !generator.GetComponent<Generator>().GetOneIsStopped())
        {
            StopMoving();
        }
        else if (!moving)
        {
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
