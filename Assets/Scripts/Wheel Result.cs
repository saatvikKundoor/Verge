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
        "(2n)!\n-----------\n5<sup>n</sup>(n!)<sup>2</sup>",
        
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
    string[] answers = new string[]
    {
        
        // Problem 1
        "Div. by Limit Comparison Test",
        
        
        // Problem 2
        "Conv. by Geometric Series Test",
        
        // Problem 3
        "Conv. by Integral Test",
        
        // Problem 4
        "Conv. by AST",
        
        // Problem 5
        "Div. by Ratio Test",
        
        // Problem 6
        "Conv. by Limit Comparison Test",
        
        // Problem 7
        "Div. by Limit Comparison Test",
        
        // Problem 8
        "Conv. by Geometric Series Test",
        
        // Problem 9
        "Conv. by Limit Comparison Test",

        //Problem 10
        "Div. by Integral Test",
    
        // Problem 11
        "Conv. by Ratio Test",
        
        // Problem 12
        "Div. by Direct Comparison Test",
        
        // Problem 13
        "Conv. by Ratio Test",
        
        // Problem 14
        "Conv. by AST",
        
        // Problem 15
        "Div. by Limit Comparison Test",
        
        // Problem 16
        "Conv. by Ratio Test",
        
        // Problem 17
        "Conv. by Limit Comparison Test",

        // Problem 18
        "Conv. by Ratio Test",
        
        // Problem 19
        "Conv. by AST",
        
        // Problem 20
        "Div. by Nth Term Test"
    };
    public TextMeshProUGUI[] questions;
    public WheelController wheelController;
    public SliderScript sliderScript;

    public GameObject stone;

    public TextMeshProUGUI fraction;
    public TextMeshProUGUI answer;
    public TextMeshProUGUI coinText;
    public bool verge = false;
    public bool isPopup = false;
    public bool user_verge;
    public bool button_has_pressed = false;

    public int coins = 1000;

    int randIndex;
    // Start is called before the first frame update
    void Start()
    {
        foreach (TextMeshProUGUI ques in questions)
        {
            ques.gameObject.SetActive(true);
        }
        stone.SetActive(false);
        isPopup = false;
        button_has_pressed = false;
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
        button_has_pressed = false;
        isPopup = true;
        answer.gameObject.SetActive(false);
        foreach (TextMeshProUGUI ques in questions)
        {
            ques.gameObject.SetActive(false);
        }
        stone.SetActive(true);
        stone.transform.eulerAngles = new Vector3(0,0,0);
        randIndex = UnityEngine.Random.Range(0, expressions.Length);
        fraction.text = expressions[randIndex];
        string type = answers[randIndex].Substring(0,3);
        if (string.Equals(type, "Con"))
        {
            verge = true;
        }
        else
        {
            verge = false;
        }

    }

    public void Converge()
    {
        if (!button_has_pressed)
        {
            if (isPopup)
            {
                user_verge = true;
            }
            if (verge != user_verge)
            {
                answer.gameObject.SetActive(true);
                answer.text = "Wrong! " + answers[randIndex];
                coins *= Mathf.RoundToInt(1 - sliderScript.value);
                coinText.text = coins.ToString("0");
            }
            else
            {
                answer.gameObject.SetActive(true);
                answer.text = "Correct! " + answers[randIndex];
                coins *= Mathf.RoundToInt(1 + sliderScript.value);
                coinText.text = coins.ToString("0");
            }
            button_has_pressed = true;
        }
        
    }
    public void Diverge()
    {
        if (!button_has_pressed)
        {
            if (isPopup)
            {
                user_verge = false;
            }
            if (verge != user_verge)
            {
                answer.gameObject.SetActive(true);
                answer.text = "Wrong! " + answers[randIndex];
                coins *= Mathf.RoundToInt(1 - sliderScript.value);
                coinText.text = coins.ToString("0");
            }
            else
            {
                answer.gameObject.SetActive(true);
                answer.text = "Correct! " + answers[randIndex];
                coins *= Mathf.RoundToInt(1 + sliderScript.value);
                coinText.text = coins.ToString("0");
            }
            button_has_pressed = true;
        }
    }
    public void resetPopup()
    {
        stone.SetActive(false);
        foreach(TextMeshProUGUI ques in questions)
        {
            ques.gameObject.SetActive(true);
        }
        button_has_pressed = false;
    }
}
