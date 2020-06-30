using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Camera cam;
    public int renderInterval = 4;
    private int lastFrame;

    Vector3 destinationForward;


    void Start()
    {
        cam = GetComponent<Camera>();
        // Set the current camera's settings from the main Scene camera
        int cmask = cam.cullingMask;
        RenderTexture tmp = cam.targetTexture;
        Vector3 pos = transform.position;
        cam.CopyFrom(Camera.main);
        transform.position = pos;
        cam.targetTexture = tmp;
        cam.clearFlags = CameraClearFlags.Skybox;
        cam.depth--;
        cam.cullingMask = cmask;

        //cam.targetTexture.width = Screen.width;
        //cam.targetTexture.height = Screen.height;
        lastFrame = -renderInterval - 1;
        destinationForward = transform.forward;
    }

    private void OnPreRender()
    {
        this.transform.rotation.SetFromToRotation(destinationForward, Camera.main.transform.forward);
        if (Time.frameCount - lastFrame > renderInterval)
        {
            //cam.Render();
            lastFrame = Time.frameCount;
        }
    }

}
