using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector3 normalVelocity;
	private bool touchingPlayer;

    //private static bool oneIsStopped;
    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalVelocity = rb.velocity = Vector3.down*speed;
		touchingPlayer = false;
    }

	private void ResumeMoving(BlockController block)
    {
        block.rb.velocity = normalVelocity;
        if(block == Generator.instance.stoppedBlock)
            Generator.instance.stoppedBlock = null;
    }

	private void StopMoving(BlockController block)
    {
        block.rb.velocity = Vector3.zero;
        Generator.instance.stoppedBlock = this;
    }

    void ToggleMovement()
    {
		// this prevents the player block from moving if another block is selected
		if(Generator.instance.stoppedBlock != null)
			if (Generator.instance.stoppedBlock.tag == "Player")
				return;
		
		if (Generator.instance.stoppedBlock == this)
        {
            ResumeMoving(this);
        }
        else
        {
			if(Generator.instance.stoppedBlock != null)
				ResumeMoving (Generator.instance.stoppedBlock);
            StopMoving(this);
        }
    }

    private void DetectMouseClick()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
			// if you click the player block again it should not move
			if (this.tag == "Player")
				return;

			if (touchingPlayer) {
                ToggleMovement();
                Vector3 myCenter = this.transform.position;
				GameManager.instance.MovePlayer (myCenter);

				Destroy(GameObject.FindGameObjectWithTag ("Player"));
				this.tag = "Player";
				Generator.instance.stoppedBlock = null;
			}
        }

    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boundry") {
			Destroy (gameObject);
		} else if (other.gameObject.tag == "Player") {
			touchingPlayer = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			touchingPlayer = false;
		}
	}


    void OnMouseOver()
    {
        DetectMouseClick();
    }
}
