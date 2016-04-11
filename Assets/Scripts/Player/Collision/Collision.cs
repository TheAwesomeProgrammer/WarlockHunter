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

            Vector2 movingDirection = (wantedPosition - currentPosition).normalized;
            float rayDistance = Mathf.Abs(wantedPosition.x - currentPosition.x) + extends.x;
            
            if (colliderObject.OverlapPoint(wantedPosition + movingDirection * rayDistance))
            {
                allowedPosition.x = currentPosition.x;
            }

            movingDirection = (wantedPosition - currentPosition).normalized;
            rayDistance = Mathf.Abs(wantedPosition.y - currentPosition.y) + extends.y;

            if (colliderObject.OverlapPoint(wantedPosition + movingDirection * rayDistance))
            {
                allowedPosition.y = currentPosition.y;
            }
        }

        return allowedPosition;
    }

  
}
