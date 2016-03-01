using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public float levelStartDelay = 2f;
	public static GameManager instance = null;
	public Generator generator;
	public BoardManager boardScript;

    public GameObject levelText;
    private GameObject tempTextBox;
    public int Level;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

        Level = GameManager.instance.Level;

        generator = GetComponent<Generator> ();
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
        DontDestroyOnLoad(gameObject);
    }

    public void displayText()
    {
        if(Level > 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Level"));
        }

        //Instantiates the Object
        tempTextBox = (GameObject)Instantiate(levelText, new Vector3(0, -4, 0), Quaternion.identity);

        //Grabs the TextMesh component from the game object
        TextMesh theText = tempTextBox.transform.GetComponent<TextMesh>();

        //Sets the text.
        theText.text = "Level: " + Level;
    }


	void InitGame ()
	{
		boardScript.SetupScene ();
        displayText();
        Generator.instance.updateRate++;
        if (Level + 1 % 2 == 0)
            Generator.instance.waveRate++;
        if (Level <= 3)
            Generator.instance.enemyRate--; 
        if (Generator.instance.enemyRate < 4)
            Generator.instance.enemyRate = 4;
        Debug.Log("InitGame Level: " + Level);
    }

	// Update is called once per frame
	void Update () {

	}
}
