using UnityEngine;
using UnityEngine.UI;

public class PlayerFlip : MonoBehaviour
{
    public void ShouldFlip(Transform transformToChange, Vector2 direction, FlippedStart flippedStart)
    {
        if (direction.x > 0)
        {
            if (flippedStart == FlippedStart.Left && transformToChange.lossyScale.x > 0 ||
                    flippedStart == FlippedStart.Right && transformToChange.lossyScale.x < 0)
            {
                Flip(transformToChange);
            }
        }
        else if (direction.x < 0)
        {
            if (flippedStart == FlippedStart.Left && transformToChange.lossyScale.x < 0 ||
                flippedStart == FlippedStart.Right && transformToChange.lossyScale.x > 0)
            {
                Flip(transformToChange);
            }
        }
    }

    void Flip(Transform transformToChange)
    {
        transformToChange.localScale = new Vector3(transformToChange.lossyScale.x * -1, transformToChange.lossyScale.y,
               transformToChange.lossyScale.z);
    }
}
