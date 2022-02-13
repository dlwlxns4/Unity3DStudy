using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObj : MonoBehaviour
{
    public int id;

    public abstract void Interact();
    public abstract void Interact(Vector3 targetPosition);
}
