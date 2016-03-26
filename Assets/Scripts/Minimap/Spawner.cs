using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public List<GameObject> Objects;

    protected virtual void Start()
    {
        SpawnObjects();
    }

    protected virtual void SpawnObjects()
    {
        foreach (var anObject in Objects)
        {
            SpawnObject(anObject);
        }
    }

    protected virtual void SpawnObject(GameObject anObject)
    {
        Instantiate(anObject);
    }


}
