using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room : ActivateObject
{
    public Dictionary<Direction, Room> NeightborRooms = new Dictionary<Direction, Room>();
    public float MaxDistanceToOtherRoom;
    public bool Captured;

    public Vector2 Center
    {
        get { return _collider2D.bounds.center; }
    }

    private Map _map;
    private Collider2D _collider2D;

    private List<GameObject> PlayersInRoom = new List<GameObject>();

    private Dictionary<Direction, Vector2> DirectionsSet = new Dictionary<Direction, Vector2>()
    {
        {Direction.Left, Vector2.left},
        {Direction.Right, Vector2.right},
        {Direction.Down, Vector2.down},
        {Direction.Up, Vector2.up}
    };

    void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    protected override void Start()
    {
        base.Start();
        ActivateTags.Add("Player");
        ActivateTags.Add("Warlock");
        _map = transform.parent.GetComponent<Map>();
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

    public override void Activate(GameObject otherObject)
    {
        base.Activate(otherObject);
        PlayersInRoom.Add(otherObject);
        Player player = otherObject.GetComponent<Player>();
        player.CurrentRoom = this;
    }

    public override void Deactivate(GameObject otherObject)
    {
        base.Deactivate(otherObject);
        PlayersInRoom.Remove(otherObject);
        Player player = otherObject.GetComponent<Player>();
        player.CurrentRoom = null;
    }

    void SetNeightborRooms()
    {
        foreach (Room child in _map.GetComponentsInChildren<Room>())
        {
            foreach (var directionSet in DirectionsSet)
            {
                Ray ray = new Ray(child.Center, directionSet.Value * (MaxDistanceToOtherRoom + _collider2D.bounds.extents.x));
                Collider2D collider2D = child.GetComponent<Collider2D>();
                if (collider2D.bounds.IntersectRay(ray) && child != this)
                {
                    SetNeightborRoom(child);
                }
            }
        }
    }

    void SetNeightborRoom(Room neightborRoom)
    {
        Vector2 directionToNeightBorRoom = (neightborRoom.transform.position - transform.position).normalized;

        if (!NeightborRooms.ContainsKey(ToDirectionEnum(directionToNeightBorRoom)))
        {
            NeightborRooms.Add(ToDirectionEnum(directionToNeightBorRoom), neightborRoom);
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
        if (direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            return Direction.Down;
        }
        if (direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            return Direction.Up;
        }

        return Direction.None;
    }

    void Update()
    {
        SetFog();
    }

    void SetFog()
    {
        if (PlayersInRoom.Count <= 0)
        {
            transform.FindChildByTag("Fog").GetComponent<SpriteRenderer>().enabled = true;
        }
        if (PlayersInRoom.Count > 0)
        {
            transform.FindChildByTag("Fog").GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
