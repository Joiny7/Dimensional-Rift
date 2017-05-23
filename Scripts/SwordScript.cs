using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour {
    private int score;
    private int comboCounter;
	private float comboMultiplier = 1.0f;
    private AudioSource healthPackSource;
    private AudioClip healthPackPickup;
    private AudioSource sphereDestructionSoundPlayer;   //Source for playing sphere sounds
	private AudioSource bombExplosion;          //Source for playing bomb sounds so they dont collide
	private AudioClip[] bombExplosionsList;     //List of bomb sounds
    private AudioClip[] spherePopperList;       //List of sphere sounds
    public Right_WandController RW;
    public PlayerScript player;
    public HealthBarScript healthScript;
    public TextScriptCombo textScriptCombo;
    public TextScriptComboSword swordText;

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag ("Sphere")) 													//If the sword collides with an object tagged as sphere
        {
            comboCounter++;
            calculateMultiplier();
            score = score + (int)(100 * comboMultiplier);

            int x;
            x = Random.Range(0, bombExplosionsList.Length);
            sphereDestructionSoundPlayer.PlayOneShot(spherePopperList[x], 0.1f); 		//Pick a random sound from the array and play it once
            RW.TriggerHapticPulse();

        }

        if (collider.CompareTag("Health"))												//If the sword collides with an object tagged as health
        {
            comboCounter++;
            calculateMultiplier();
            score = score + (int)(100 * comboMultiplier);
            healthPackSource.PlayOneShot(healthPackPickup);
            RW.TriggerHapticPulse();

            if (player.getHealth() <= 100)
            {
             healthScript.getHealed();
             player.setHealth(30);  
            }
        }

         if (collider.CompareTag("Bomb"))                                                //If the sword collides with an object tagged as bomb
            {
                int x;
                x = Random.Range(0, bombExplosionsList.Length);
                bombExplosion.PlayOneShot(bombExplosionsList[x], 0.9f);                     //Pick a random sound from the array and play it once
                RW.TriggerHapticPulse();

                player.setHealth(-10);    //Take 10 damage
                healthScript.takeDamage();      //Decrease healthbar by 1, flashs screen
                player.setHealth(-10);    //Take 10 damage
                healthScript.takeDamage();      //Decrease healthbar by 1, flashs screen
                comboBreak();

            if (player.health <= 0)  //Check if player dies
            { 
                player.gameOverUI();
            }
        }
        
    }

void calculateMultiplier() 															//Calculate the combo multiplier
    {
		comboMultiplier = 1 + (comboCounter / 10) * 0.5f;

        if (comboCounter == 10 | comboCounter == 20 | comboCounter == 30 | comboCounter == 40 | comboCounter == 50 | comboCounter == 60
            | comboCounter == 70 | comboCounter == 80 | comboCounter == 90 | comboCounter == 100 | comboCounter == 110 | comboCounter == 120
            | comboCounter == 130 | comboCounter == 140 | comboCounter == 150) //Ugly ass if. As if i'd make it pretty. Fuck you.
        {
            textScriptCombo.getTextObject().SetActive(false);
            textScriptCombo.spawnCombo();
        }
    }

    public void comboBreak() 															//When a combobreak occurs, reset counter to 0
    {
        if (comboCounter >= 10) {                                                       //Make sure there is a combo to break before displaying text
            textScriptCombo.getTextObject().SetActive(false);
            textScriptCombo.spawnComboBreak();
        }
        comboCounter = 0;
		calculateMultiplier ();
        swordText.setText();

    }
    public void addCombo(int i)
    {
        comboCounter = comboCounter + i;
        calculateMultiplier();
    }

    void Start () {
        healthPackPickup = (AudioClip)Resources.Load("HealthPack2");
        healthPackSource = GetComponent<AudioSource>();

        spherePopperList = new AudioClip[] { 											//Initialize destroySphere sounds
            (AudioClip)Resources.Load("Sphere/DestroySphere1"),
			(AudioClip)Resources.Load("Sphere/DestroySphere2"),
			(AudioClip)Resources.Load("Sphere/DestroySphere3"),
			(AudioClip)Resources.Load("Sphere/DestroySphere4"),
			(AudioClip)Resources.Load("Sphere/DestroySphere5"),
			(AudioClip)Resources.Load("Sphere/DestroySphere6"),
            };
        sphereDestructionSoundPlayer = GetComponent<AudioSource>();

		bombExplosionsList = new AudioClip[] {
			(AudioClip)Resources.Load ("BombExplosion/Bomb1"),
			(AudioClip)Resources.Load ("BombExplosion/Bomb2"),
			(AudioClip)Resources.Load ("BombExplosion/Bomb3"),
		};
        bombExplosion = GetComponent<AudioSource>(); 									//Initialize destroyBomb sounds
        calculateMultiplier();
    }

	public int getScore() //Getter for score
	{
		return score;
	}

	public double getComboMultiplier() //Getter for comboMultiplier
	{
        if (comboMultiplier < 1.5)
        {
            return comboMultiplier = 1.0f;
        }
        else {
            return comboMultiplier;
        }
	}

	void Update () {
	}
}