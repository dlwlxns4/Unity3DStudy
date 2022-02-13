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
    PlayerInput playerInput;
    void Start()
    {
        playerInput =GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        DetectNPC();
    }

    void Update()
    {
        InteractNPC();
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

    void InteractNPC()
    {
        if(interactState != InteractState.DETECTNPC)
        {
            return ;
        }

        if(playerInput.attackInput==true)
        {
            Debug.Log("Conservation!!");
            npcCollider[0].gameObject.GetComponent<InteractableObj>()?.Interact(transform.position);
            transform.LookAt(npcCollider[0].transform.position);
        }
    }
}
