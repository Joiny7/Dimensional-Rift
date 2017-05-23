using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ShieldScript : MonoBehaviour
{

    public Left_WandController LW;
    private AudioClip[] list; //change to public if sounds fk up
    public SwordScript sword;
    public Animation shieldHitAnimation;

    AudioSource shieldImpactSound;
    Color myColor = new Color();

    void Start()
    {
        shieldHitAnimation = GetComponent<Animation>();
        shieldImpactSound = GetComponent<AudioSource>();
        list = new AudioClip[]
        {
            (AudioClip)Resources.Load("ShieldImpact/Shield1"),
            (AudioClip)Resources.Load("ShieldImpact/Shield2"),
            (AudioClip)Resources.Load("ShieldImpact/Shield3"),
            (AudioClip)Resources.Load("ShieldImpact/Shield4"),
            (AudioClip)Resources.Load("ShieldImpact/Shield5"),
            (AudioClip)Resources.Load("ShieldImpact/Shield6"),
            (AudioClip)Resources.Load("ShieldImpact/Shield7"),
            (AudioClip)Resources.Load("ShieldImpact/Shield8"),
            (AudioClip)Resources.Load("ShieldImpact/Shield9"),
            (AudioClip)Resources.Load("ShieldImpact/Shield10"),
        };

        ColorUtility.TryParseHtmlString("F7F7F7", out myColor); //Color of emissive glow
    }

    void Update()
    { //Makes the shield glow !!!NOT WORKING!!!
 //       Renderer renderer = GetComponent<Renderer>();
 //       Material mat = renderer.material;

 //       float floor = 0.2f;
 //       float ceiling = 1f;
//        float emission = floor + Mathf.PingPong(Time.time * 0.8f, ceiling - floor); //Multiply time with constant for speed of glow
//        Color finalColor = myColor * Mathf.LinearToGammaSpace(emission);
//        mat.SetColor("_EmissionColor", finalColor);
    }

    void OnTriggerEnter(Collider Shield)
    {
        int x;
        x = Random.Range(0, list.Length);
        shieldImpactSound.PlayOneShot(list[x], 1f);
        LW.TriggerHapticPulse();
        shieldHitAnimation.Play(); //Play emission animation on collision
    }
}