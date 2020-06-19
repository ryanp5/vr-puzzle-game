using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LockHandOnInteract : XRSimpleInteractable
{
    //position to lock hand at
    public Transform lockPosition;
    //position of hand model
    public Transform handPosition;
    //position of controller
    public Transform controllerPos;
    private bool selected = false;
    //distance hand can be away from locked position  before spans back.
    public float maxDistance = 0.5f;
    XRDirectInteractor initalInteractor;
    //left and right hand models
    public Transform rightHand;
    public Transform leftHand;
    private void Update()
    {
        if (selected)
        {
            //distance of controller from hand model
            float dist = Vector3.Distance(controllerPos.position, lockPosition.position);
           
            if (dist > maxDistance)
            {
                handPosition.position = initalInteractor.transform.position;
                handPosition.SetParent(initalInteractor.transform);
                selected = false;
            }
        }
    }
    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        { 
            controllerPos = interactor.gameObject.transform;
            initalInteractor = (XRDirectInteractor)interactor;
            if (interactor.GetComponent<XRController>().controllerNode == XRNode.LeftHand)
            {
                handPosition = leftHand;
            }
            else
            {
                handPosition = rightHand;
            }
            handPosition.parent = null;
            handPosition.position = lockPosition.transform.position;
            selected = true;
        }
        base.OnSelectEnter(interactor);
    }
    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            handPosition.position = interactor.transform.position;
            handPosition.SetParent(interactor.transform);
            selected = false;
        }
        base.OnSelectExit(interactor);
    }
}
