using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInteract : MonoBehaviour
{
    public enum InteractState {NONE, DETECTNPC, TALKING};

    private Collider[] npcCollider = new Collider[1];
    [SerializeField]
    GameObject interactInfoPanel;
    public InteractState interactState{get; set;}

    void Start()
    {

    }

    void FixedUpdate()
    {
        DetectNPC();
    }

    void DetectNPC()
    {
        int npcCount = Physics.OverlapSphereNonAlloc(transform.position, 1f, npcCollider, 1 << 6);
        if (npcCount != 0)
        {
            interactInfoPanel.SetActive(true);
            interactState = InteractState.DETECTNPC;
        }
        else
        {
            interactInfoPanel.SetActive(false);
            interactState = InteractState.NONE;
        }
    }
}
