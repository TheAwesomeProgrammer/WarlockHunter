using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ActivateObject : MonoBehaviour, Activateable
{
    public List<string> ActivateTags { get; set; }
    public List<string> DeactivateTags { get; set; }

    protected virtual void Start()
    {
        ActivateTags = new List<string>();
        DeactivateTags = new List<string>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (ActivateTags.Contains(collider2D.tag))
        {
            Activate(collider2D.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (ActivateTags.Contains(collider2D.tag))
        {
            ContinousActivation(collider2D.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (DeactivateTags.Contains(collider2D.tag))
        {
            Deactivate(collider2D.gameObject);
        }
    }

    public virtual void Activate(GameObject otherObject)
    {
            
    }

    public virtual void ContinousActivation(GameObject otherObject)
    {
        
    }

    public virtual void Deactivate(GameObject otherObject)
    {
           
    }
}
