using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BreakGrabOnCollision : MonoBehaviour
{
    private bool interacting = false;
    private XRGrabInteractable grab;
    private void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        
        if (interacting)
        {
            if (collision.collider.attachedRigidbody == null)
            {
              //  print("static body");
            }
            else
            {
              //  print("rigidbody");
            }
        }
    }

    
    public void OnActivate()
    {
        interacting = true;

    }
    public void OnDeactivate()
    {
        interacting = false;
    }
}
