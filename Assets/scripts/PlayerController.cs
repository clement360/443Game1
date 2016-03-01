using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance = null;
	public bool touchingFinish;
    public AudioClip stepBlip;
    public AudioClip deathClip;
    public AudioClip goal;

    // Use this for initialization
    void Start () {
		touchingFinish = false;
        instance = this;
    }


    public void MovePlayer(Vector3 dest)
    {
        SoundManager.instance.RandomizeSfx(stepBlip);
        PlayerManager.instance.playerObject.transform.position = dest + new Vector3(0f, .3f, 0f);
    }


    void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Finish") {
            SoundManager.instance.RandomizeSfx(goal);
            GameManager.instance.Level++;
			Invoke ("Restart", (float)0.1);
        } else if(other.gameObject.tag == "Enemy Block")
        {
            SoundManager.instance.RandomizeSfx(deathClip);
            Invoke("Restart", (float)0.1);
        }
	}

	private void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
