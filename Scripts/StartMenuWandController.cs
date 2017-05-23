using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class StartMenuWandController : MonoBehaviour
{

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    //public DataPasserScript DScript;
    // MAIN MENU BUTTONS
    private bool startButtonTriggered = false;
    private bool exitButtonTriggered = false;
    private bool backButtonTriggered = false;
    private bool optionsButtonTriggered = false;
    private bool highScoreButtonTriggered = false;
    private bool instructionsButtonTriggered = false;

    //INSTRUCTIONS
    private bool HealthBarToggle = false;
    private bool ShieldToggle = false;
    private bool SwordToggle = false;
    private bool PurpleToggle = false;
    private bool YellowToggle = false;
    private bool HealthToggle = false;
    private bool CyanToggle = false;
    private bool LaserToggle = false;
    private bool BombToggle = false;
    private bool BlueToggle = false;

    // TUTORIAL & DIFFICULTY BUTTONS
    private bool tutorialStartTriggered = false;
    private bool easyTriggered = false;
    private bool normalTriggered = false; //Also quick start
    private bool hardTriggered = false;
    private bool insaneTriggered = false;

    private bool MasterVolumeIncreaseTriggered = false;
    private bool MasterVolumeDecreaseTriggered = false;
    private bool VoiceVolumeIncreaseTriggered = false;
    private bool VoiceVolumeDecreaseTriggered = false;
    private bool EffectsVolumeIncreaseTriggered = false;
    private bool EffectsVolumeDecreaseTriggered = false;

    //Set menus as game objects
    public GameObject menuBackground;
    public GameObject optionsBackground;
    public GameObject instructionsBackground;
    public GameObject difficultyBackground;
    public GameObject highScoreBackground;

    private Object Voice_script;

    AudioSource audioPlayer;
    private AudioClip[] menuSounds;

    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        audioPlayer = GetComponent<AudioSource>();
        Voice_script = gameObject.GetComponent<VoiceOverController>();

        //Set the AudioSource
        menuSounds = new AudioClip[] {                                      //Load all menu sounds into an array
        (AudioClip)Resources.Load("StartMenuSounds/StartGame"),
        (AudioClip)Resources.Load("StartMenuSounds/Exit Game"),
        (AudioClip)Resources.Load("StartMenuSounds/HighScore"),
        (AudioClip)Resources.Load("StartMenuSounds/Instructions"),
        (AudioClip)Resources.Load("StartMenuSounds/Options"),
        (AudioClip)Resources.Load("StartMenuSounds/ButtonHover"),
        (AudioClip)Resources.Load("StartMenuSounds/ExitGameSound"),
        (AudioClip)Resources.Load("StartMenuSounds/ButtonClick"),
        (AudioClip)Resources.Load("StartMenuSounds/StartGameSound")
        };
        gameObject.GetComponent<VolumeControllerScript>();

        AudioClip introduction = (AudioClip)Resources.Load("VoiceOver/Menu/Menu_1_Welcome_to_the_game");
        audioPlayer.PlayOneShot(introduction); //Play introduction voice

    }


    void Update()
    {
        if (Controller == null)
        {
            Debug.Log("Our controller is not initialised.");
            return;
        }

        //Functions for navigating menu using touchpad (not functioning properly)
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchpad = (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
            if (touchpad.y > 0.7f) //UP
            {
                resetTriggers();
                audioPlayer.PlayOneShot(menuSounds[4]);
            }
            else if (touchpad.y < -0.7f) //DOWN
            {
                resetTriggers();
                audioPlayer.PlayOneShot(menuSounds[1]);
                exitButtonTriggered = true;
            }
            if (touchpad.x > 0.7f) //RIGHT
            {
                resetTriggers();
                audioPlayer.PlayOneShot(menuSounds[2]);
            }
            else if (touchpad.x < -0.7f) //LEFT
            {
                resetTriggers();
                audioPlayer.PlayOneShot(menuSounds[3]);
            }
            else if (touchpad.x < 0.7f & touchpad.x > -0.7f & touchpad.y < 0.7f & touchpad.y > -0.7f)
            {
                resetTriggers();
                audioPlayer.PlayOneShot(menuSounds[0]);
                normalTriggered = true;
            }
        }

        //Check what button is being pressed with the triggerButton
        if (Controller.GetPressDown(triggerButton))
        {
            if (startButtonTriggered)
            {
                StartCoroutine(DifficultyMenu());
            }
            else if (exitButtonTriggered)
            {                   //Run the exit routine
                StartCoroutine(ExitGame());
            }
            else if (highScoreButtonTriggered)
            {
                audioPlayer.volume = 0.4f;
                audioPlayer.PlayOneShot(menuSounds[7]); //ClickSound
                StartCoroutine(HighScoreMenu());

            }
            else if (optionsButtonTriggered)
            {
                StartCoroutine(OptionsMenu());         // calls ChangeDifficulty routine 
            }
            else if (instructionsButtonTriggered)
            {
                audioPlayer.volume = 0.4f;
                audioPlayer.PlayOneShot(menuSounds[7]); //ClickSound

                StartCoroutine(InstructionsMenu());
            }
            else if (normalTriggered)
            {
                DifficultyLevel.setDifficultyLevel(3);
                StartCoroutine(ChangeLevel());
            }

            else if (backButtonTriggered)
            {
                audioPlayer.volume = 0.4f;
                audioPlayer.PlayOneShot(menuSounds[7]); //ClickSound
                StartCoroutine(BackButton());
            }

            else if (easyTriggered)
            {
                DifficultyLevel.setDifficultyLevel(2);
                StartCoroutine(ChangeLevel());
            }
            else if (tutorialStartTriggered)
            {
                DifficultyLevel.setDifficultyLevel(1);
                StartCoroutine(ChangeLevel());
            }
            else if (hardTriggered)
            {
                DifficultyLevel.setDifficultyLevel(4);
                StartCoroutine(ChangeLevel());
            }
            else if (insaneTriggered)
            {
                DifficultyLevel.setDifficultyLevel(5);
                StartCoroutine(ChangeLevel());
            }

            else if (MasterVolumeIncreaseTriggered)
            {
                VolumeControllerScript.increaseMasterVolume();
            }
            else if (MasterVolumeDecreaseTriggered)
            {
                VolumeControllerScript.decreaseMasterVolume();
            }

            else if (EffectsVolumeIncreaseTriggered)
            {
                VolumeControllerScript.increaseEffectsVolume();
            }
            else if (EffectsVolumeDecreaseTriggered)
            {
                VolumeControllerScript.decreaseEffectsVolume();
            }

            else if (VoiceVolumeIncreaseTriggered)
            {
                VolumeControllerScript.increaseVoiceVolume();
            }
            else if (VoiceVolumeIncreaseTriggered)
            {
                VolumeControllerScript.decreaseVoiceVolume();
            }
            else if (BlueToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[0], 1f);
                }
            }
            else if (YellowToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[1], 1f);
                }
            }
            else if (PurpleToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[2], 1f);
                }
            }
            else if (CyanToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[3], 1f);
                }
            }
            else if (SwordToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[4], 1f);
                }
            }
            else if (ShieldToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[5], 1f);
                }
            }
            else if (HealthToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[6], 1f);
                }
            }
            else if (BombToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[7], 1f);
                }
            }
            else if (LaserToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[8], 1f);
                }
            }
            else if (HealthBarToggle)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                    audioPlayer.PlayOneShot(gameObject.GetComponent<VoiceOverController>().instructionMenuList[9], 1f);
                }
            }
        }
    }

    //This is where the good stuff happens
    IEnumerator ChangeLevel()
    {
        VoiceOverController.setMenuFalse();
        print("changing levels");
        audioPlayer.volume = 0.4f;
        audioPlayer.PlayOneShot(menuSounds[8]);	//StartGameSound
        yield return new WaitForSeconds(audioPlayer.clip.length + 0.5f);
        SceneManager.LoadScene("DimensionalRift");
    }

    /* Switches between Main menu background to the options menu background. */
    IEnumerator OptionsMenu()
    {
        resetTriggers(); 									//Reset all triggers when entering the options menu
        print("Opening options menu.");
        audioPlayer.volume = 0.4f;
        audioPlayer.PlayOneShot(menuSounds[7]);	//ClickSound
        yield return new WaitForSeconds(audioPlayer.clip.length);
        menuBackground.SetActive(false);
        instructionsBackground.SetActive(false);
        difficultyBackground.SetActive(false);
        optionsBackground.SetActive(true);
    }

    IEnumerator InstructionsMenu()
    {
        Debug.Log("Opening instructions menu...");
        resetTriggers();                                                //Reset all triggers when entering the options menu
        audioPlayer.volume = 0.4f;
        audioPlayer.PlayOneShot(menuSounds[7]); //ClickSound
        yield return new WaitForSeconds(audioPlayer.clip.length);
        menuBackground.SetActive(false);
        optionsBackground.SetActive(false);
        difficultyBackground.SetActive(false);
        instructionsBackground.SetActive(true);
    }

    IEnumerator DifficultyMenu()
    {
        Debug.Log("Opening difficulty menu...");
        resetTriggers();                                                //Reset all triggers when entering the options menu
        audioPlayer.volume = 0.4f;
        audioPlayer.PlayOneShot(menuSounds[7]); //ClickSound
        yield return new WaitForSeconds(audioPlayer.clip.length);
        menuBackground.SetActive(false);
        optionsBackground.SetActive(false);
        instructionsBackground.SetActive(false);
        difficultyBackground.SetActive(true);

    }

    IEnumerator HighScoreMenu()
    {
        Debug.Log("Opening high score menu...");
        resetTriggers();                                                //Reset all triggers when entering the options menu
        audioPlayer.volume = 0.4f;
        audioPlayer.PlayOneShot(menuSounds[7]); //ClickSound
        yield return new WaitForSeconds(audioPlayer.clip.length);
        menuBackground.SetActive(false);
        optionsBackground.SetActive(false);
        instructionsBackground.SetActive(false);
        difficultyBackground.SetActive(false);
        highScoreBackground.SetActive(true);

    }

    IEnumerator BackButton()
    {
        Debug.Log("Going back...");
        resetTriggers();                                                //Reset all triggers when pressing back
        audioPlayer.volume = 0.4f;
        audioPlayer.PlayOneShot(menuSounds[7]);	//ClickSound
        yield return new WaitForSeconds(audioPlayer.clip.length);
        optionsBackground.SetActive(false);
        instructionsBackground.SetActive(false);
        difficultyBackground.SetActive(false);
        highScoreBackground.SetActive(false);
        menuBackground.SetActive(true);
    }

    IEnumerator ExitGame()
    {
        audioPlayer.volume = 0.4f;
        audioPlayer.PlayOneShot(menuSounds[6]);     //ExitGameSound
        yield return new WaitForSeconds(4);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }

    private void resetTriggers()                //Resets all triggers to false in order to maintain proper funcitonality
    {
        startButtonTriggered = false;
        exitButtonTriggered = false;
        optionsButtonTriggered = false;
        highScoreButtonTriggered = false;
        instructionsButtonTriggered = false;
        backButtonTriggered = false;
        tutorialStartTriggered = false;
        easyTriggered = false;
        normalTriggered = false;
        hardTriggered = false;
        insaneTriggered = false;
        MasterVolumeIncreaseTriggered = false;
        MasterVolumeDecreaseTriggered = false;
        VoiceVolumeIncreaseTriggered = false;
        VoiceVolumeDecreaseTriggered = false;
        EffectsVolumeIncreaseTriggered = false;
        EffectsVolumeDecreaseTriggered = false;
        HealthBarToggle = false;
        ShieldToggle = false;
        SwordToggle = false;
        PurpleToggle = false;
        YellowToggle = false;
        CyanToggle = false;
        LaserToggle = false;
        BlueToggle = false;
}

    //Checks what happens when the controller collides with something (triggers color changes on buttons & sounds)
    private void OnTriggerEnter(Collider collider)
    {
        audioPlayer.volume = 0.4f;
        audioPlayer.PlayOneShot(menuSounds[5]); //Play hover sound
        Controller.TriggerHapticPulse(500);
        if (!collider.CompareTag("Untagged")) //Don't change color on border
        {
            collider.GetComponent<Renderer>().material.color = new Color(0.16f, 0.23f, 0.28f, 1); //Change color when hovering a button
            if (collider.CompareTag("StartButton"))
            {
                startButtonTriggered = true;
            }
            else if (collider.CompareTag("ExitButton"))
            {
                exitButtonTriggered = true;
            }
            else if (collider.CompareTag("HighScoreButton"))
            {
                highScoreButtonTriggered = true;
            }
            else if (collider.CompareTag("OptionsButton"))
            {
                optionsButtonTriggered = true;
            }
            else if (collider.CompareTag("InstructionsButton"))
            {
                instructionsButtonTriggered = true;
            }
            else if (collider.CompareTag("TutorialButton"))
            {
                tutorialStartTriggered = true;
            }
            else if (collider.CompareTag("QuickStart"))
            {
                normalTriggered = true;
            }
            else if (collider.CompareTag("BackButton"))
            {
                backButtonTriggered = true;
            }

            else if (collider.CompareTag("EasyButton"))
            {
                easyTriggered = true;
            }
            else if (collider.CompareTag("HardButton"))
            {
                hardTriggered = true;

            }
            else if (collider.CompareTag("InsaneButton"))
            {
                insaneTriggered = true;
            }
            else if (collider.CompareTag("IncreaseMasterVolume"))
            {
                MasterVolumeIncreaseTriggered = true;
            }
            else if (collider.CompareTag("DecreaseMasterVolume"))
            {
                MasterVolumeDecreaseTriggered = true;
            }
            else if (collider.CompareTag("IncreaseEffectVolume"))
                   {
                       EffectsVolumeIncreaseTriggered = true;
                   }
            else if (collider.CompareTag("DecreaseEffectVolume"))
                   {
                       EffectsVolumeDecreaseTriggered = true;
            }

            else if (collider.CompareTag("IncreaseVoiceVolume")){
                       VoiceVolumeIncreaseTriggered = true;
            }
            else if (collider.CompareTag("DecreaseVoiceVolume")){
                       VoiceVolumeDecreaseTriggered = true;
            }
            else if (collider.CompareTag("HealthBarToggle")){
                HealthBarToggle = true; 
            }
            else if (collider.CompareTag("HealthToggle"))
            {
                HealthToggle = true;
            }
            else if (collider.CompareTag("BombToggle"))
            {
                BombToggle = true;
            }
            else if (collider.CompareTag("LaserToggle"))
            {
                LaserToggle = true;
            }
            else if (collider.CompareTag("SwordToggle"))
            {
                SwordToggle = true;
            }
            else if (collider.CompareTag("ShieldToggle"))
            {
                ShieldToggle = true;
            }
            else if (collider.CompareTag("BlueToggle"))
            {
                BlueToggle = true;
            }
            else if (collider.CompareTag("PurpleToggle"))
            {
                PurpleToggle = true;
            }
            else if (collider.CompareTag("CyanToggle"))
            {
                CyanToggle = true;
            }
            else if (collider.CompareTag("YellowToggle"))
            {
                YellowToggle = true;
            }
        }
    }


           //Checks what happens when the controller stops colliding with something (triggers color changes on buttons)
           private void OnTriggerExit(Collider collider)
           {
               if (!collider.CompareTag("Untagged"))	//Don't change color on border
               {
                   collider.GetComponent<Renderer>().material.color = new Color(0.27f, 0.38f, 0.46f, 1); //Change color when stop hovering a button
                   if (collider.CompareTag("StartButton"))
                   {
                       startButtonTriggered = false;
                   }
                   else if (collider.CompareTag("ExitButton"))
                   {
                       exitButtonTriggered = false;
                   }
                   else if (collider.CompareTag("HighScoreButton"))
                   {
                       highScoreButtonTriggered = false;
                   }
                   else if (collider.CompareTag("OptionsButton"))
                   {
                       optionsButtonTriggered = false;
                   }
                   else if (collider.CompareTag("InstructionsButton"))
                   {
                       instructionsButtonTriggered = false;
                   }
                   else if (collider.CompareTag("TutorialButton"))
                   {
                       tutorialStartTriggered = false;
                   }
                   else if (collider.CompareTag("QuickStart"))
                   {
                       normalTriggered = false;
                   }
                   else if (collider.CompareTag("BackButton"))
                   {
                       backButtonTriggered = false;
                   }
                   else if (collider.CompareTag("EasyButton"))
                   {
                       easyTriggered = false;
                   }
                   else if (collider.CompareTag("HardButton"))
                   {
                       hardTriggered = false;
                   }
                   else if (collider.CompareTag("InsaneButton"))
                   {
                       insaneTriggered = false;
                   }
                   if (collider.CompareTag("IncreaseMasterVolume"))
                   {
                       MasterVolumeIncreaseTriggered = false;
                   }
                   else if (collider.CompareTag("DecreaseMasterVolume"))
                   {
                       MasterVolumeDecreaseTriggered = false;
                   }
                 
                      else if (collider.CompareTag("IncreaseEffectVolume"))
                      {
                          EffectsVolumeIncreaseTriggered = false;
                      }
                      else if (collider.CompareTag("DecreaseEffectVolume"))
                      {
                          EffectsVolumeDecreaseTriggered = false;
                      }

            else if (collider.CompareTag("IncreaseVoiceVolume"))
                  {
                      VoiceVolumeIncreaseTriggered = false;
                  }
                  else if (collider.CompareTag("DecreaseVoiceVolume"))
                  {
                      VoiceVolumeDecreaseTriggered = false;
                  }
            else if (collider.CompareTag("HealthBarToggle"))
            {
                HealthBarToggle = false;
            }
            else if (collider.CompareTag("HealthToggle"))
            {
                HealthToggle = false;
            }
            else if (collider.CompareTag("BombToggle"))
            {
                BombToggle = false;
            }
            else if (collider.CompareTag("LaserToggle"))
            {
                LaserToggle = false;
            }
            else if (collider.CompareTag("SwordToggle"))
            {
                SwordToggle = false;
            }
            else if (collider.CompareTag("ShieldToggle"))
            {
                ShieldToggle = false;
            }
            else if (collider.CompareTag("BlueToggle"))
            {
                BlueToggle = false;
            }
            else if (collider.CompareTag("PurpleToggle"))
            {
                PurpleToggle = false;
            }
            else if (collider.CompareTag("CyanToggle"))
            {
                CyanToggle = false;
            }
            else if (collider.CompareTag("YellowToggle"))
            {
                YellowToggle = false;
            }
        }
    }
}
