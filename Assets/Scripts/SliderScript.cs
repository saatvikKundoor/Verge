using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider red;
    [SerializeField] private TextMeshProUGUI betText;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        red.onValueChanged.AddListener((v)=>
        {
            float percent = v*100;
            betText.text = percent.ToString("0") + "%";
            value = v;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
