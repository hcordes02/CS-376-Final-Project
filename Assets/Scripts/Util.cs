using UnityEngine;

/// <summary>
/// Untility
/// </summary>
public class Util : MonoBehaviour
{
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
}
