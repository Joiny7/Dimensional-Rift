using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFlash : MonoBehaviour {

	public Image damageImage;										//Image for damage
	public GameObject dmgImg;
	private float flashSpeed = 6f; 									//How fast the damage will flash
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);			//Color of damage
	private bool damaged; 											//Check if player took damage for activating flash

	private float flashSpeedHeal = 6f; 								//How fast the damage will flash
	public Color flashColourHeal = new Color(0f, 1f, 0f, 0.1f);		//Color of damage
	private bool healed;											//Check if player got healed

	public void Damage(){
		if (!damaged) {
			damaged = true;
		} else {
			damaged = false;
		}
	}

	public void Heal(){
		if (!healed) {
			healed = true;
		} else {
			healed = false;
		}
	}
			

	// Use this for initialization
	void Start () {
		damaged = false;
        dmgImg.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		if(damaged) {
            dmgImg.SetActive(true);
            damageImage.color = flashColour;
		}
		else{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            dmgImg.SetActive(false);
        }
		damaged = false;

        if (healed) {
            dmgImg.SetActive(true);
            damageImage.color = flashColourHeal;
		}
		else{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeedHeal * Time.deltaTime);
            dmgImg.SetActive(false);
        }
		healed = false;
	}
}
		



