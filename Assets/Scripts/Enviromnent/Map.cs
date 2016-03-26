
using System.Collections.Generic;
using UnityEngine;
public class Map : MonoBehaviour
{
    private List<Room> Rooms = new List<Room>();

    void Start()
    {
        AddRooms();
    }

    void AddRooms()
    {
        foreach (var room in GetComponentsInChildren<Room>())
        {
            Rooms.Add(room);
        }
    }
}

