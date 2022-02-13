using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObj
{

    public override void Interact()
    {
    }

    public override void Interact(Vector3 targetPosition)
    {
        LookAtTarget(targetPosition);
    }

    void LookAtTarget(Vector3 targetPosition)
    {
        transform.LookAt(targetPosition);
    }
}
