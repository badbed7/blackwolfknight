using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public InteractObject interact;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        interact = other.gameObject.GetComponent<InteractObject>();
    }

    private void OnTriggerExit(Collider other)
    {
        interact = null;
    }

    public void Interact()
    {
        if(interact == null)
        {
            return;
        }

        Debug.Log("¹öÆ°");
        interact.ItemInteract();
    }
}
