using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelResult : MonoBehaviour
{
    string[] colors = {"Pink2", "Green1", "DarkBlue", "Yellow", "Green2", "Pink1", "LightBlue", "Red"};
    string[] expressions = new string[]
    {
        
        // Problem 1
        "7\n------\n3n+11",
        
        
        // Problem 2
        "5<sup>n</sup>\n----\n9<sup>n</sup>",
        
        // Problem 3
        "    1\n-----------\nn(ln(n))<sup>3</sup>",
        
        // Problem 4
        "(-1)<sup>n</sup>\n-------\n³√n",
        
        // Problem 5
        "n!\n----\n4<sup>n</sup>",
        
        // Problem 6
        "8n<sup>2</sup>+1\n-----------\n2n<sup>5</sup>+7",
        
        // Problem 7
        "sin(1/n)",
        
        // Problem 8
        "(-3)<sup>n</sup>\n----------\n10<sup>n</sup>",
        
        // Problem 9
        "√n\n-------\nn<sup>2</sup>+4",

        //Problem 10
        "1\n-----------\nn(ln(n))",
    
        // Problem 11
        "(2n)!\n-------------\n5<sup>n</sup>(n!)<sup>2</sup>",
        
        // Problem 12
        "cos<sup>2</sup>n\n------\nn",
        
        // Problem 13
        "7<sup>n</sup>\n----\nn!",
        
        // Problem 14
        "(-1)<sup>n</sup>\n--------\nn<sup>2</sup>+5",
        
        // Problem 15
        "1\n------------\n√(n<sup>2</sup>+8)",
        
        // Problem 16
        "(n!)<sup>2</sup>\n--------\n(2n)!",
        
        // Problem 17
        "ln(n)\n------\nn<sup>3/2</sup>",

        // Problem 18
        "(2n+1)<sup>n</sup>\n-----------\n(5n+7)<sup>n</sup>",
        
        // Problem 19
        "(-1)<sup>n</sup>\n-----------\nln(n+1)",
        
        // Problem 20
        "n<sup>4</sup>+8n\n-----------\n3n<sup>4</sup>+1"
    };
    public TextMeshProUGUI[] questions;
    public WheelController wheelController;

    public GameObject stone;

    public TextMeshProUGUI fraction;
    // Start is called before the first frame update
    void Start()
    {
        foreach (TextMeshProUGUI ques in questions)
        {
            ques.gameObject.SetActive(true);
        }
        stone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void EndResult()
    {
       float finalAngle = wheelController.transform.eulerAngles.z % 360f;
        if (finalAngle < 0) 
        {
            finalAngle += 360f;
        }

        // 2. Invert the angle so it moves clockwise (matching your visual array layout)
        float clockwiseAngle = (360f - finalAngle) % 360f;

        // 3. Apply the 22.5-degree offset so that the pointer cleanly splits 
        // the middle of the slice instead of getting stuck on the edge lines.
        float offsetAngle = (clockwiseAngle + 22.5f) % 360f;

        // 4. Divide by 45 degrees to get the array index (360 degrees / 8 slices)
        int targetIndex = Mathf.FloorToInt(offsetAngle / 45f);

        // 5. Wrap the index safely within bounds
        targetIndex = targetIndex % colors.Length;
        Debug.Log(colors[targetIndex]);
        UIPopup();
    }

    public void UIPopup()
    {
        foreach (TextMeshProUGUI ques in questions)
        {
            ques.gameObject.SetActive(false);
        }
        stone.SetActive(true);
        stone.transform.eulerAngles = new Vector3(0,0,0);
        int randIndex = UnityEngine.Random.Range(0, expressions.Length);
        fraction.text = expressions[randIndex];
    }
}
