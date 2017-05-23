using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public GameObject cylinderPointer;
    public PlayerScript player;

    private bool retryTriggered = false;
    private bool menuTriggered = false;
    private bool exitTriggered = false;
	private bool isActive = false;

    AudioSource audioPlayer;

    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;

    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        //cylinderPointer.transform.Find("[CameraRig]/Controller (right)/SciFiSword/SciFiSword/Cylinder");
        cylinderPointer = GameObject.FindGameObjectWithTag("GameOverPointer");
        cylinderPointer.SetActive(false);
    }
	
	void Update () {
        if (Controller == null)
        {
            Debug.Log("Our controller is not initilised.");
            return;
        }

        if (player.getHealth() <= 0) {
            //cylinderPointer.transform.Find("[CameraRig]/Controller (right)/GameObject/SciFiSword/SciFiSword/Cylinder");
            //rwc.GetComponent<GameOverController>().enabled = true;
            cylinderPointer.SetActive(true);
        }


        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchpad = (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
            if (touchpad.y > 0.7f) //UP
            {
                resetTriggers();
            }
            else if (touchpad.y < -0.7f) //DOWN
            {
                resetTriggers();
                menuTriggered = true;
            }
            if (touchpad.x > 0.7f) //RIGHT
            {
                resetTriggers();
            }
            else if (touchpad.x < -0.7f) //LEFT
            {
                resetTriggers();
            }
            else if (touchpad.x < 0.7f & touchpad.x > -0.7f & touchpad.y < 0.7f & touchpad.y > -0.7f)
            {
                resetTriggers();  
                retryTriggered = true;
            }
        }
        if (Controller.GetPressDown(triggerButton))
        {
            if (retryTriggered)
            {
             // RE-START GAME
            }
            else if (menuTriggered)
            {
                SceneManager.LoadScene("StartMenu");
            }
            else if (exitTriggered)
            {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
            }
        }
    }//update

    private void resetTriggers()
    {
        retryTriggered = false;
        menuTriggered = false;
        exitTriggered = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Controller.TriggerHapticPulse(500);
        collider.GetComponent<Renderer>().material.color = Color.blue;
        if (collider.CompareTag("RetryButton"))
        {
            retryTriggered = true;
        }
        else if (collider.CompareTag("MenuButton"))
        {
            menuTriggered = true;
        }
        else if (collider.CompareTag("ExitButton"))
        {
            exitTriggered = true;
        }
    }


    private void OnTriggerExit(Collider collider)
    {
        collider.GetComponent<Renderer>().material.color = Color.magenta;
        if (collider.CompareTag("RetryButton"))
        {
            retryTriggered = false;
        }
        else if (collider.CompareTag("MenuButton"))
        {
            menuTriggered = false;
        }
        else if (collider.CompareTag("ExitButton"))
        {
            exitTriggered = false;
        }
    }

}//class
