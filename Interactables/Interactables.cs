using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public float radius = 2f;
 
    bool isBeingFocused = false;
    bool hasInteracted = false;

    public Transform interactionTransform;
    Transform player;

    private void Update()
    {
        if (isBeingFocused && !hasInteracted)
        {
            float distanceToPlayer = Vector3.Distance(interactionTransform.position, player.position);
            if (distanceToPlayer <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        
    }

    public void OnFocused (Transform playerTransform)
    {
        isBeingFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isBeingFocused = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}