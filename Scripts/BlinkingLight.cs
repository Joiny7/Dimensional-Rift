using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour {

    private new Light light;
    public float minWaitTime;
    public float maxWaitTime;

    // Use this for initialization
    void Start () {
        light = GetComponent<Light>()   ;
        StartCoroutine(flashLamp());
	}

    IEnumerator flashLamp() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            light.enabled = !light.enabled;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
