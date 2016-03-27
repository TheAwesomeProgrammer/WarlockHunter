using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public List<string> CollisionTags; 

    private List<Collider2D> ColliderObjects = new List<Collider2D>();



    void OnTriggerStay2D(Collider2D otherCollider)
    {
        CollisionProperties collisionProperties = otherCollider.GetComponent<CollisionProperties>();

        if (CollisionTags.Contains(otherCollider.tag))
        {
            AddCollider(otherCollider);
        }
        else if (collisionProperties != null)
        {
            AddCollider(otherCollider);
        }
    }

    private void AddCollider(Collider2D otherCollider)
    {
        if(!ColliderObjects.Exists(colliderInList => colliderInList.GetInstanceID() == otherCollider.GetInstanceID()) ||
            ColliderObjects.Count <= 0)
        {
            ColliderObjects.Add(otherCollider);
        }
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (ColliderObjects.Contains(otherCollider))
        {
            ColliderObjects.Remove(otherCollider);
        }

        CollisionProperties collisionProperties = otherCollider.GetComponent<CollisionProperties>();
        if (collisionProperties != null)
        {
            foreach (var blockedObjects in collisionProperties.BlockedObjects)
            {
                ColliderObjects.Remove(blockedObjects.GetComponent<Collider2D>());
            }
        }
    }

    public Vector2 GetAllowedPosition(Vector2 currentPosition, Vector2 wantedPosition, Vector2 extends, GameObject sender)
    {
        Vector2 allowedPosition = wantedPosition;

        if (ColliderObjects.Count <= 0)
        {
            return wantedPosition;
        }

        foreach (var colliderObject in ColliderObjects)
        {
            CollisionProperties collisionProperties = colliderObject.GetComponent<CollisionProperties>();
            if (collisionProperties != null && !collisionProperties.BlockedObjects.Contains(sender))
            {
                continue;
            }

            Ray horizontalRay = new Ray(currentPosition, new Vector2(wantedPosition.x - currentPosition.x, 0));
            float rayDistance = Mathf.Abs(wantedPosition.x - currentPosition.x) + extends.x;
            float distance;
            Bounds colliderBounds = colliderObject.bounds;
            if (colliderBounds.IntersectRay(horizontalRay, out distance) && distance <= rayDistance)
            {
                allowedPosition.x = colliderBounds.center.x + (colliderBounds.extents.x * -horizontalRay.direction).x +
                    (extends.x * -horizontalRay.direction).x;
            }

            Ray verticalRay = new Ray(currentPosition, new Vector2(0, wantedPosition.y - currentPosition.y));
            rayDistance = Mathf.Abs(wantedPosition.y - currentPosition.y) + extends.y;
            if (colliderBounds.IntersectRay(verticalRay, out distance) && distance <= rayDistance)
            {
                allowedPosition.y = colliderBounds.center.y + (colliderBounds.extents.y * -verticalRay.direction).y +
                    (extends.x * -verticalRay.direction).y;
            }
        }

        return allowedPosition;
    }

  
}
