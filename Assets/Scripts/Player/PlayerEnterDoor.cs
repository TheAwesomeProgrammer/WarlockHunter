using UnityEngine;

public class PlayerEnterDoor : ActivateObject
{
    private PlayerMoveCamera _playerMoveCamera;
    private Player _player;
    private Movement _movement;

    protected override void Start()
    {
        base.Start();
        ActivateTags.Add("Door");
        _playerMoveCamera = GetComponentInParent<PlayerMoveCamera>();
        _player = GetComponentInParent<Player>();
        _movement = GetComponentInParent<Movement>();
    }

    public override void Activate(GameObject otherObject)
    {
        base.Activate(otherObject);
        Door door = otherObject.GetComponent<Door>();
        CollisionProperties collisionProperties = door.GetComponent<CollisionProperties>();

        Room otherRoom = _player.CurrentRoom.GetOtherRoom(DirectionToTransform(door.transform, door.DoorDirection));
        if (_player.CurrentRoom.Captured && !otherRoom.Captured)
        {
            collisionProperties.BlockedObjects.Add(_movement.gameObject);
        }
        else
        {
            collisionProperties.BlockedObjects.Remove(_movement.gameObject);
            _playerMoveCamera.Move(otherRoom.Center);
        }
    }

    private Direction DirectionToTransform(Transform doorTranform, DoorDirection doorDirection)
    {
        Vector2 velocityToTransform = (doorTranform.position - transform.position);

        Direction currentDirection = Direction.Right;
        if (velocityToTransform.x > 0 && Mathf.Abs(velocityToTransform.x) > Mathf.Abs(velocityToTransform.y) &&
            doorDirection == DoorDirection.LeftRight)
        {
            return currentDirection;
        }
        currentDirection = Direction.Left;
        if (velocityToTransform.x < 0 && Mathf.Abs(velocityToTransform.x) > Mathf.Abs(velocityToTransform.y) &&
             doorDirection == DoorDirection.LeftRight)
        {
            return currentDirection;
        }
        currentDirection = Direction.Up;
        if (velocityToTransform.y < 0 && Mathf.Abs(velocityToTransform.x) < Mathf.Abs(velocityToTransform.y) &&
             doorDirection == DoorDirection.UpDown)
        {
            return currentDirection;
        }
        currentDirection = Direction.Down;
        if (velocityToTransform.y > 0 && Mathf.Abs(velocityToTransform.x) < Mathf.Abs(velocityToTransform.y) &&
             doorDirection == DoorDirection.UpDown)
        {
            return currentDirection;
        }

        return Direction.None;
    }
}
