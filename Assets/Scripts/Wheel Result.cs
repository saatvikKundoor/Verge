using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelResult : MonoBehaviour
{
    string[] colors = {"Pink2", "Green1", "DarkBlue", "Yellow", "Green2", "Pink1", "LightBlue", "Red"};
    
    public WheelController wheelController;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
