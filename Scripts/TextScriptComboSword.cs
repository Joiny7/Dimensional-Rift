using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScriptComboSword : MonoBehaviour
{

    private Text text;
    private string textForCombo = "x1 Combo";
    public SwordScript sword;

   public void setText()
    {
        textForCombo = sword.getComboMultiplier().ToString();
        text.text = "x" + textForCombo + " Combo";
    }
    
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = textForCombo;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
