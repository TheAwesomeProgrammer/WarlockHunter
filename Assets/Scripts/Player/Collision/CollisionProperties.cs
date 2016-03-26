
using System.Collections.Generic;
using UnityEngine;

public class CollisionProperties : MonoBehaviour
{
    public List<GameObject> BlockedObjects = new List<GameObject>();

    void Start()
    {
        BlockedObjects = new List<GameObject>();
    }
}
