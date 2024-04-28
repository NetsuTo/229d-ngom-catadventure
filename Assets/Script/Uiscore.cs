using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Uiscore : MonoBehaviour
{
    public TextMeshProUGUI Kill;
    public static int Killc = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Kill.text = "Kill : " + Killc;
    }

}
