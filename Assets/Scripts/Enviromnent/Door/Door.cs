using System.Collections.Generic;
using UnityEngine;

public class Door : ActivateObject
{
    public DoorDirection DoorDirection;
    public const float MaxDistanceToOtherRoom = 5;
    public Dictionary<Direction, Room> NeightborRooms = new Dictionary<Direction, Room>();

    private Dictionary<Direction, Vector2> DirectionsSet = new Dictionary<Direction, Vector2>()
    {
        {Direction.Left, Vector2.left},
        {Direction.Right, Vector2.right},
        {Direction.Down, Vector2.down},
        {Direction.Up, Vector2.up}
    };

    protected override void Start()
    {
        base.Start();
        SetNeightborRooms();
    }

    public Room GetOtherRoom(Direction direction)
    {
        if (NeightborRooms.ContainsKey(direction))
        {
            return NeightborRooms[direction];
        }
        return null;
    }

    void SetNeightborRooms()
    {
        foreach (var directionSet in DirectionsSet)
        {
            RaycastHit2D ray = new RaycastHit2D();
      
            ray = Physics2D.Raycast(transform.position, directionSet.Value*(MaxDistanceToOtherRoom),
                 LayerMask.GetMask("Room"));

            Collider2D collider2D = ray.collider;
            if (collider2D != null)
            {
                SetNeightborRoom(directionSet.Value, collider2D.GetComponent<Room>());
            }
        }
    }

    void SetNeightborRoom(Vector2 direction, Room neightborRoom)
    {
        if (neightborRoom != null && !NeightborRooms.ContainsKey(ToDirectionEnum(direction)))
        {
            NeightborRooms.Add(ToDirectionEnum(direction), neightborRoom);
        }
    }

    private Direction ToDirectionEnum(Vector2 direction)
    {
        if (direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return Direction.Right;
        }
        if (direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return Direction.Left;
        }
        if (direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            return Direction.Down;
        }
        if (direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            return Direction.Up;
        }

        return Direction.None;
    }

}
