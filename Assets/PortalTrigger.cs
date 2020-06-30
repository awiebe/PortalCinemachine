using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class PortalTrigger : MonoBehaviour
{
    [FormerlySerializedAs("camera")]
    public Camera destinationCamera;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //Vector2 orientation = MainVCam.singleton.GetFreelookValues();
            ////MainVCam.singleton.gameObject.SetActive(false); //doesn't seem to work
            Transform playert = other.transform;
            Transform mainCam = Camera.main.transform;
            Transform oldParent = playert.parent;

            //Move the player in relation to the camera rendering the portal so the transition is seemless

            Vector3 relpos = mainCam.InverseTransformPoint(playert.position);
            Vector3 oldpos = playert.position;

            //Warp the player so they are at the same position at the camera which rendered the portal
            playert.position = destinationCamera.transform.TransformPoint(relpos);

            //Orient the player to face the same way entering and exiting the portal
            playert.rotation = Quaternion.LookRotation(destinationCamera.transform.forward, Vector3.up);

            //Update vcams

            MainVCam.singleton.Deactivate();
            MainVCam.singleton.OnTargetObjectWarped(playert, playert.position - oldpos);
            //The cinemachine camera has now teleported relative to the player but isn't in the same
            //relative orientation to the player who has also changed directions

            //This is the part that doesn't work
            Debug.Log("Main cam deactivate");
            //Me trying various modifications in various orders.
            //MainVCam.singleton.SetFreelookValues(orientation);
            //MainVCam.singleton.Invalidate();
            //MainVCam.singleton.SetFreelookValues(orientation);
            //MainVCam.singleton.position = camera.transform.position;
            //MainVCam.singleton.rotation = camera.transform.rotation;
            //MainVCam.singleton.TransformVCams();
            //MainVCam.singleton.FreelookRelocated();
            //MainVCam.singleton.Invalidate();

            Debug.Break();


            MainVCam.singleton.Activate();
            //MainVCam.singleton.SetFreelookValues(orientation);

            Debug.Break();


            //Invoke("ReenableMainVCam", 0.3f);

            //MainVCam.singleton.gameObject.SetActive(true);
        }
    }

}
