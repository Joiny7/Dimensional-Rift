using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int health = 100;
    public bool testing; 									//Set active in editor to make player invulnerable
	private AudioSource playerGetHit;
    private AudioClip hitBySphere;
    private AudioClip hitByBomb;
    private MeleeWeaponTrail trail;
    public SwordScript sword;
    public GameObject highScore;
    public LevelController LC;
	public HealthBarScript healthScript;
	public HighScore HS;
    public string playerName;
    public Right_WandController controller;
    public GameObject endGameMenu;


    public int getHealth() {
        return health;
    }

    public void setHealth(int damage)
    {
        health += damage;
    }

	public void gameOverUI() {
		if (!testing) {
			Debug.Log("Player has successfully DIED");
            endGameMenu.SetActive(true);                //Activate end game menu screen
            //highScore.SetActive(true);                //Activate high score screen 
            controller.ActivatePointer();               //Activate menu pointer
            controller.GetComponent<BoxCollider>().enabled = true; //Need this for pointing
            HS.Save(); //Save High Score (TEMP. saves one score)
            
            //Set spawners/spheres/level inactive on gameOver:
            GameObject[] Spawners = GameObject.FindGameObjectsWithTag("Spawners");  //FindGameObject = very heavy
            foreach (GameObject spawner in Spawners)
            {
                spawner.SetActive(false);
            }
            GameObject[] Spheres = GameObject.FindGameObjectsWithTag("Sphere");     //FindGameObject = very heavy
            foreach (GameObject sphere in Spheres)
            {
                sphere.SetActive(false);
            }
            GameObject LevC = GameObject.FindGameObjectWithTag("LevelController");
            LevC.SetActive(false);

            
        }
	}

    public void SubmitName(string input) //Used for setting player name for highscore, get name from input field
    {
        playerName = input;
        Debug.Log(input);
    }

    void OnTriggerEnter(Collider collider)
	{    
		if (collider.CompareTag("Sphere")) { //Sphere & Laser
            playerGetHit.PlayOneShot(hitBySphere);
            setHealth(-10);
            healthScript.takeDamage ();
			sword.comboBreak ();
			if (health <= 0 & !testing) { //Check if player dies and remove all spawners and spheres           
				gameOverUI ();
			}
		}
		if (collider.CompareTag("Bomb")) { 					//If the sword collides with an object tagged as bomb
			setHealth (-10);
			healthScript.takeDamage ();
			setHealth (-10);
			healthScript.takeDamage ();
			sword.comboBreak ();
            if (health <= 0 & !testing) { //Check if player dies and remove all spawners and spheres
				gameOverUI ();
				}
		}
	}

    public string getName()
    {
        return playerName;
    }

    public bool getTesting()
    {
        if (testing)
        {
            return testing = true;
        }
        
        else 
            return testing = false;

    }

    void OnGUI()															//Prints ui to outside GUI
    {
        GUI.Label(new Rect(0, 0, 100, 100), "Health: " + health.ToString());
        int score = sword.getScore();
        GUI.Label(new Rect(0, 10, 100, 100), "Score: " + score.ToString());
		double combo = sword.getComboMultiplier ();
		GUI.Label(new Rect(0, 20, 100, 100), "COMBO: " + combo.ToString() + "x");    
        GUI.Label(new Rect(0, 30, 100, 100), LC.getLevelName());
        GUI.Label(new Rect(0, 40, 100, 100), "High Score: " + HS.getHighScore().ToString()); //+ HS.getDifficulty());
    }

    // Use this for initialization
    void Start()
    {
        endGameMenu.SetActive(false);
        playerGetHit = GetComponent<AudioSource>();
        hitBySphere = (AudioClip)Resources.Load("PlayerHitBySphere");
        hitByBomb = (AudioClip)Resources.Load("/BombExplosion/Bomb1");
        HS.Load(); //Load singular high score
        highScore.SetActive(false);
        GetComponent<AudioSource>().volume = VolumeControllerScript.getEffectsVolume(); //Set volume to whats set in the options
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 100)
        {
            health = 100;
        }
    }
}
