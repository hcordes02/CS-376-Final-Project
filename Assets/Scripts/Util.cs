using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{

    // Start is called before the first frame update
    public static float Approach(float start, float end, float change)
    {
        if (start == end)
        {
            return end;
        }
        bool larger = (start > end);

        if (larger)
        {
            start -= change;
            if (start < end)
            {
                start = end;
            }
        }
        else
        {
            start += change;
            if (start > end)
            {
                start = end;
            }
        }
        return start;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
