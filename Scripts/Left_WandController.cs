using UnityEngine;
using System.Collections;

public class Left_WandController : MonoBehaviour {

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
    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)trackedObject.index);} } // get the index of the device
    private SteamVR_TrackedObject trackedObject;
   
	void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	
	}
	
	void Update () {
	    if(Controller == null) {
            Debug.Log("Our controller is not initilised.");
            return;
        }

        gripButtonDown = Controller.GetPressDown(gripButton);
        gripButtonUp = Controller.GetPressUp(gripButton);
        gripButtonPressed = Controller.GetPress(gripButton); // button being held down continously

        triggerButtonDown = Controller.GetPressDown(triggerButton);
        triggerButtonUp = Controller.GetPressUp(triggerButton);
        triggerButtonPressed = Controller.GetPress(triggerButton); // button being held down continously

		if (gripButtonPressed) { //Testing
			//Time.timeScale = 0;
		}

	}

	public void TriggerHapticPulse()
	{
		Controller.TriggerHapticPulse(3000);
	}
}
