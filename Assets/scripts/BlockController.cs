﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BlockController : MonoBehaviour
{
    public float speed;
	private Vector3 direction;

    private Rigidbody2D rb;
    private Vector3 normalVelocity;
	private bool touchingPlayer;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		normalVelocity = rb.velocity = direction * (speed+GameManager.instance.Level);
		touchingPlayer = false;
    }

	public void setDirection (Vector3 dir)
	{
		this.direction = dir;
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
			if (Generator.instance.stoppedBlock.tag == "Current Block")
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
		if (Input.GetKeyDown ("mouse 0")) {
			// if you click the player block again it should not move
			if (this.tag == "Current Block")
				return;

			if (touchingPlayer) {
				ToggleMovement ();
				Vector3 myCenter = this.transform.position;
                PlayerController.instance.MovePlayer (myCenter);
                PlayerManager.instance.playerPosX = (int)myCenter.x;
                PlayerManager.instance.playerPosY = (int)myCenter.y;

				if (Generator.instance.prevBlock == null) {
					Destroy (GameObject.FindGameObjectWithTag ("Start"));
				} else {
					Destroy (GameObject.FindGameObjectWithTag ("Current Block"));
				}
                
				this.tag = "Current Block";
				Generator.instance.prevBlock = Generator.instance.stoppedBlock;
				Generator.instance.stoppedBlock = null;
			}
		}

    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boundry") {
			Destroy (gameObject);
		} 
        else if (other.gameObject.tag == "Current Block" || other.gameObject.tag == "Start") {
            touchingPlayer = true;
        }
	}

 	void OnTriggerExit2D(Collider2D other)
	 {
		if (other.gameObject.tag == "Current Block" || other.gameObject.tag == "Start") {
			touchingPlayer = false;
		}
	 }

    void OnMouseOver()
    {
        DetectMouseClick();
    }
}
