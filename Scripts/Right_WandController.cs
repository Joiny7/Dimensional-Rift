using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Right_WandController : MonoBehaviour {
    /* Grip button initialisation. */
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    private bool gripButtonDown = false;
    private bool gripButtonUp = false;
    private bool gripButtonPressed = false;

    /* Trigger button initialisation. */
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private bool triggerButtonDown = false;
    private bool triggerButtonUp = false;
    private bool triggerButtonPressed = false;

    /* Controller intilisation + bound to the correct track object's indexes. */
    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } } // get the index of the device
    private SteamVR_TrackedObject trackedObject;

    //Bools for checking which button is hovered
    private bool retryTriggered = false;
    private bool menuTriggered = false;
    private bool exitTriggered = false;

    public GameObject pointer;

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    public void ActivatePointer() //Activates pointer from PlayerScript when game over is triggered
    {
        pointer.SetActive(true);
    }

    void Update()
    {
        if (Controller == null)
        {
            Debug.Log("Our controller is not initilised.");
            return;
        }

        if (Controller.GetPressDown(triggerButton)) //If trigger pressed
        {
            if(retryTriggered) //Retry button
            {
                Debug.Log("RetryTriggered");
                SceneManager.LoadScene("DimensionalRift");
                resetTriggers();
            }
            else if (menuTriggered) //Menu button
            {
                Debug.Log("MenuTriggered");
                SceneManager.LoadScene("StartMenu");
                resetTriggers();
            }
            else if (exitTriggered) //Exit button
            {
                Debug.Log("ExitTriggered");
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else   
                Application.Quit();
#endif
            }
        }


        }

    private void OnTriggerEnter(Collider collider) //Collision check
    {
        if (!collider.CompareTag("Untagged")) //Don't change color on border
            Controller.TriggerHapticPulse(500);
        {
            collider.GetComponent<Renderer>().material.color = new Color(0.16f, 0.23f, 0.28f, 1); //Change color when hovering a button
            if (collider.CompareTag("RetryButton"))
            {
                retryTriggered = true;
                Controller.TriggerHapticPulse();
            }
            else if (collider.CompareTag("MenuButton"))
            {
                menuTriggered = true;
                Controller.TriggerHapticPulse();
            }
            else if (collider.CompareTag("ExitButton"))
            {
                exitTriggered = true;
                Controller.TriggerHapticPulse();
            }
        }
    }

    private void OnTriggerExit(Collider collider) //Collision check
    {
        if (!collider.CompareTag("Untagged"))   //Don't change color on border
        {
            collider.GetComponent<Renderer>().material.color = new Color(0.27f, 0.38f, 0.46f, 1); //Change color when stop hovering a button

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
    }


    private void resetTriggers()                //Resets all triggers to false in order to maintain proper funcitonality
    {
        menuTriggered = false;
        retryTriggered = false;
        exitTriggered = false;
    }

    public void TriggerHapticPulse()
	{
		Controller.TriggerHapticPulse(3000);
	}

}