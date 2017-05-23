using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    public GameObject health100; 
	public GameObject health90;
	public GameObject health80;
	public GameObject health70;
	public GameObject health60;
	public GameObject health50;
	public GameObject health40;
	public GameObject health30;
	public GameObject health20;
	public GameObject health10;
	public Material[] Materials;
	public ScreenFlash flashScreen;
    public PlayerScript player;

	public void takeDamage() {
		int health = player.getHealth();
		switch (health) {
		case 90:
			health100.SetActive (false);
			break;
		case 80:
			health90.SetActive(false);
			break;
		case 70:
			health80.SetActive(false);
			break;
		case 60:
			health70.SetActive(false);
			health60.GetComponent<Renderer>().material = Materials [1];
			health50.GetComponent<Renderer>().material = Materials [1];
			health40.GetComponent<Renderer>().material = Materials [1];
			health30.GetComponent<Renderer>().material = Materials [1];
			health20.GetComponent<Renderer>().material = Materials [1];
			health10.GetComponent<Renderer>().material = Materials [1];
			break;
		case 50:
			health60.SetActive(false);
			break;
		case 40:
			health50.SetActive(false);
			break;
		case 30:
			health40.SetActive(false);
			health30.GetComponent<Renderer>().material = Materials [2];
			health20.GetComponent<Renderer>().material = Materials [2];
			health10.GetComponent<Renderer>().material = Materials [2];
			break;
		case 20:
			health30.SetActive(false);
			break;
		case 10:
			health20.SetActive(false);
			break;
		case 0:
			health10.SetActive(false);
			break;
		default:
			break;
		}
		flashScreen.Damage();
	}

	public void getHealed() {
		int health = player.getHealth();

        switch (health) {

        case 90:
			health100.SetActive (true);
			break;
		case 80:
                health100.SetActive(true);
                health90.SetActive(true);
			break;
		case 70:
                health100.SetActive(true);
                health90.SetActive(true);
                health80.SetActive(true);
			break;
		case 60:
                health90.SetActive(true);
                health80.SetActive(true);
                health70.SetActive(true);
			health60.GetComponent<Renderer>().material = Materials [0];
			health50.GetComponent<Renderer>().material = Materials [0];
			health40.GetComponent<Renderer>().material = Materials [0];
			health30.GetComponent<Renderer>().material = Materials [0];
			health20.GetComponent<Renderer>().material = Materials [0];
			health10.GetComponent<Renderer>().material = Materials [0];
			break;
		case 50:
                health80.SetActive(true);
                health70.SetActive(true);
                health60.SetActive(true);
                health60.GetComponent<Renderer>().material = Materials[0];
                health50.GetComponent<Renderer>().material = Materials[0];
                health40.GetComponent<Renderer>().material = Materials[0];
                health30.GetComponent<Renderer>().material = Materials[0];
                health20.GetComponent<Renderer>().material = Materials[0];
                health10.GetComponent<Renderer>().material = Materials[0];
                break;
		case 40:
                health70.SetActive(true);
                health60.SetActive(true);
                health50.SetActive(true);
                health60.GetComponent<Renderer>().material = Materials[0];
                health50.GetComponent<Renderer>().material = Materials[0];
                health40.GetComponent<Renderer>().material = Materials[0];
                health30.GetComponent<Renderer>().material = Materials[0];
                health20.GetComponent<Renderer>().material = Materials[0];
                health10.GetComponent<Renderer>().material = Materials[0];
                break;
		case 30:
                health60.SetActive(true);
                health50.SetActive(true);
                health40.SetActive(true);
			    health30.GetComponent<Renderer>().material = Materials [1];
			    health20.GetComponent<Renderer>().material = Materials [1];
			    health10.GetComponent<Renderer>().material = Materials [1];
			break;
		case 20:
                health50.SetActive(true);
                health40.SetActive(true);
                health30.SetActive(true);
                health30.GetComponent<Renderer>().material = Materials[1];
                health20.GetComponent<Renderer>().material = Materials[1];
                health10.GetComponent<Renderer>().material = Materials[1];
                break;
		case 10:
                health40.SetActive(true);
                health30.SetActive(true);
                health20.SetActive(true);
                health30.GetComponent<Renderer>().material = Materials[1];
                health20.GetComponent<Renderer>().material = Materials[1];
                health10.GetComponent<Renderer>().material = Materials[1];
                break;
		default:
			break;
		}
		flashScreen.Heal();

    }
}