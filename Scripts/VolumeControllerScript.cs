using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControllerScript : MonoBehaviour {

    public static float VoiceVolume = 0.5f;
    public static float EffectsVolume = 1f;
    public static float MasterVolume = 1f;

    GameObject activeSlider;

    public static void increaseMasterVolume()
    {
        
        if(MasterVolume <= 0.91f)
        {
            MasterVolume += 0.1f;
            setMasterVolume(MasterVolume);
            moveSlider(0.72f, "MasterVolumeSlider");
        }else
        {
            setMasterVolume(1f);
        }
    }

    public static void decreaseMasterVolume()
    {
        
        if (MasterVolume >= 0.09f)
        {
            MasterVolume -= 0.1f;
            setMasterVolume(MasterVolume);
            moveSlider(-0.72f, "MasterVolumeSlider");
        }
        else
        {
            setMasterVolume(0.0f);
        }
    }

    public static void increaseVoiceVolume()
    {

        if (VoiceVolume <= 0.91f)
        {
            VoiceVolume += 0.1f;
            setVoiceVolume(VoiceVolume);
            moveSlider(0.72f, "VoiceVolumeSlider");
        }
        else
        {
            setVoiceVolume(1f);
        }
    }

    public static void decreaseVoiceVolume()
    {

        if (VoiceVolume >= 0.09f)
        {
            VoiceVolume -= 0.1f;
            setVoiceVolume(VoiceVolume);
            moveSlider(-0.72f, "VoiceVolumeSlider");
        }
        else
        {
            setVoiceVolume(0.0f);
        }
    }

    public static void increaseEffectsVolume()
    {

        if (EffectsVolume <= 0.91f)
        {
            EffectsVolume += 0.1f;
            setEffectsVolume(EffectsVolume);
            moveSlider(0.72f, "EffectsVolumeSlider");
        }
        else
        {
            setEffectsVolume(1f);
        }
    }

    public static void decreaseEffectsVolume()
    {

        if (EffectsVolume >= 0.09f)
        {
            EffectsVolume -= 0.1f;
            setEffectsVolume(EffectsVolume);
            moveSlider(-0.72f, "EffectsVolumeSlider");
        }
        else
        {
            setEffectsVolume(0.0f);
        }
    }

    public static void moveSlider(float amount, string tag)
    {
        GameObject slider = GameObject.FindGameObjectWithTag(tag);
        Vector3 move = new Vector3(amount, 0, 0);
        slider.transform.localPosition += move;
    }

    public static void setMasterVolume(float f)
    {
        AudioListener.volume = f;
    }

    public static float getMasterVolume()
    {
        return MasterVolume;
    }

    public static void setVoiceVolume(float f){
        VoiceVolume = f;
    }

    public static float getVoiceVolume()
    {
        return VoiceVolume;
    }

    public static void setEffectsVolume(float f){
        EffectsVolume = f;
    }

    public static float getEffectsVolume(){
        return EffectsVolume;
    }
   
}
