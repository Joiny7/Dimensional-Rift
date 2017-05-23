using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverController : MonoBehaviour {

    public AudioSource voiceLine;
    public AudioClip[] voiceLineList;
    public AudioClip[] miscLineList;
    public AudioClip[] menuLineList;
    public AudioClip[] instructionMenuList;
    public static bool menu = true;

    void Start () {
        voiceLine = GetComponent<AudioSource>();
        voiceLine.volume = VolumeControllerScript.getVoiceVolume(); //Get volume from controller
        voiceLineList = new AudioClip[]
{                                                                                                                               //Name a million better ways to do this and i believe you.
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Bomb_1a_Bombs_are_dangerous"),                                        //[1]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Bomb_2a_Dont_slash_bomb"),                                            //[2]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Bomb_3a_Bombs_explode_boom"),                                         //[3]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Bomb_4a_To_reiterate_bombs"),                                         //[4]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Combo_1a_For_every_10_spheres"),                                      //[5]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Combo_2a_Increase_your_combo"),                                       //[6]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/HealthBar_1a_Your_remaining_health"),                                 //[7]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Laser_1a_Use_your_shield"),                                           //[8]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Laser_2a_Lasers_incoming"),                                           //[9]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Laser_3a_Keep_your_shield_up"),                                       //[10]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_1b_Blue_spheres_are_easy"),                                   //[11]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_2b_Yellow_spheres_curve"),                                    //[12]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_3b_Purple_spheres_are_tricky"),                               //[13]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_4b_Whoa_cyan_spheres_mess_you_up"),                           //[14]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_5c_Curving_spheres_incoming"),                                //[15]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_6b_Spiraling_spheres_incoming"),                              //[16]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_7a_Thrown_spheres_incoming"),                                 //[17]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_8b_Normal_spheres_incoming"),                                 //[18]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_9b_Blue_ones_dont_move_much"),                                //[19]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_10a_Yellow_spheres_incoming_from_sides"),                     //[20]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_11a_Purple_spheres_are_coming_for_you"),                      //[21]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_12ac_Cyan_spheres_are_out_to_get_you"),                       //[22]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_12ba_Cyan_spheres_are_out_to_get_you"),                       //[23]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Spheres_13c_All_spheres_incoming"),                                   //[24]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Tutorial_1a_Thank_you_for_completing_tutorial_level"),                //[25]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Tutorial_1c_Thank_you_for_completing_tutorial_level"),                //[26]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/Wave_1a_The_next_wave_shortly"),                                      //[27]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/HealthKit_1a_See_that_white_thing"),                                  //[28]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/HealthKit_1b_See_that_white_thing"),                                  //[29]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/HealthKit_4a_HealthKit_availible"),                                   //[30]
            (AudioClip)Resources.Load("VoiceOver/Tutorial/HealthKit_4b_HealthKit_incoming"),                                    //[31]

};
        miscLineList = new AudioClip[]
{
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_16a_Nice_for_a_monkey"),                             //[1]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_16b_Nice_for_a_monkey"),                             //[2]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_33b_You_look_ridiculous"),                           //[3]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_33c_You_look_ridiculous"),                           //[4]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_34a_Please_be_careful_with_equipment"),              //[5]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_34b_Please_be_careful_with_equipment"),              //[6]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_11a_You_are_awe_inspiring_at_killing"),              //[7]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_11b_You_are_awe_inspiring_at_killing"),              //[8]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_13a_Dont_die_too_quickly"),                          //[9]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_13b_Dont_die_too_quickly"),                          //[10]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_13c_Dont_die_too_quickly"),                          //[11]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_15a_Tacos_and_a_chickflick"),                        //[12]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_15b_Tacos_and_a_chickflick"),                        //[13]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_15c_Tacos_and_a_chickflick"),                        //[14]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_17_Start_stabbing_meatbag"),                         //[15]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_20a_That_last_sphere_really_liked_you"),             //[16]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_20b_That_last_sphere_really_liked_you"),             //[17]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_20c_That_last_sphere_really_liked_you"),             //[18]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_22_Last_sphere_pregnant_with_twins"),                //[19]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_26_Opening_loser_designated_airlock"),               //[20]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_1_This_next_wave_doozy"),                            //[21]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_2a_How_did_you_miss"),                               //[22]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_2b_How_did_you_miss"),                               //[23]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_2c_How_did_you_miss"),                               //[24]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_5_Get_good_soldier"),                                //[25]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_3a_Its_like_baseball"),                              //[26]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_3b_Its_like_baseball"),                              //[27]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_6_Robots_are_my_next_of_kin"),                       //[28]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_8a_Please_refrain_from_dying"),                      //[29]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_18a_Stop_missing_i_repaired_that"),                  //[30]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_18b_Stop_missing_i_repaired_that"),                  //[31]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_19_You_will_be_scored_by_murdercount"),              //[32]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_21a_Last_sphere_was_pregnant"),                      //[33]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_21b_Last_sphere_was_pregnant"),                      //[34]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_21c_Last_sphere_was_pregnant"),                      //[35]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_23a_Spheres_are_sentient"),                          //[36]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_23b_Spheres_are_sentient"),                          //[37]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_23c_Spheres_are_sentient"),                          //[38]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_24_Strike_youre_out"),                               //[39]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_10a_Excellent_except_for_everything"),               //[40]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_10b_Excellent_except_for_everything"),               //[41]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_10c_Excellent_except_for_everything"),               //[42]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_12a_Noone_will_blame_you_for_failing"),              //[43]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_12b_Noone_will_blame_you_for_failing"),              //[44]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_12c_Noone_will_blame_you_for_failing"),              //[45]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_14a_Feel_free_to_vomit_on_yourself"),                //[46]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_14b_Feel_free_to_vomit_on_yourself"),                //[47]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_25a_Pregnant_cow"),                                  //[48]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_25b_Pregnant_cow"),                                  //[49]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_25c_Pregnant_cow"),                                  //[50]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_27a_Any_feelings_you_have"),                         //[51]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_27b_Any_feelings_you_have"),                         //[52]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_30a_You_are_the_death_of_spherical_objects"),        //[53]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_30b_You_are_the_death_of_spherical_objects"),        //[54]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_30c_You_are_the_death_of_spherical_objects"),        //[55]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_29a_First_contact_with_alien_species"),              //[56]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_29b_First_contact_with_alien_species"),              //[57]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_31a_No_wonder_your_parents_dont_like_you"),          //[58]
            (AudioClip)Resources.Load("VoiceOver/Misc/Misc_31b_No_wonder_your_parents_dont_like_you"),          //[59]
            (AudioClip)Resources.Load("VoiceOver/Misc/"),                                //[60]
            (AudioClip)Resources.Load("VoiceOver/Misc/"),                                //[61]
};
        instructionMenuList = new AudioClip[]
        {
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_1_BlueSphere"),  // [0]
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_2_YellowSphere"), // [1]
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_3_PurpleSphere"), // [2]
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_4_CyanSphere"), // [3]
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_5_Sword"), // [4]
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_6_Shield"), // [5]
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_7_HealthKit"), // [6]
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_8_Bomb"), // [7]
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_9_Laser"), // [8]
            (AudioClip)Resources.Load("VoiceOver/Menu/Instructions_10c_HealthBar"), // [9]
        };
   
        // InvokeRepeating("playRandomMiscVoiceLine",15f, 30f); //Play a random Misc sound after 10 seconds, and a new one every 30 seconds

    }

    //IEnumerator MenuSounds() //Play all sounds in a list, one after another
    //{
    //        foreach (AudioClip sound in menuLineList){
    //        voiceLine.PlayOneShot(sound); //StartGameSound
    //        yield return new WaitForSeconds(voiceLine.clip.length);
    //    
    //    }
    //}

    

    void playRandomMiscVoiceLine()    //Function for picking out a random misc sound
    {
        int x;
        x = Random.Range(0, miscLineList.Length);
        voiceLine.PlayOneShot(miscLineList[x], 1f);
    }

    void playRandomVoiceLine() //But why? But for fun my dear Watson.
    {
        int x;
        x = Random.Range(0, voiceLineList.Length);
        voiceLine.PlayOneShot(voiceLineList[x], 1f);
    }

    public static void setMenuFalse()
    {
        menu = false;
    }

}



