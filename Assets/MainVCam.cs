using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVCam : MonoBehaviour
{
    public static MainVCam singleton;
    public Cinemachine.CinemachineFreeLook[] cams;

    public Vector3 position { get; internal set; }
    public Quaternion rotation { get; internal set; }

    public Transform LookAt;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
    }

    public void RestoreLookAt()
    {
        foreach (Cinemachine.CinemachineFreeLook c in cams)
        {
            c.LookAt = LookAt;
        }
    }

    public Transform GetTransform()
    {
        return cams[0].transform;
    }

    public void Deactivate()
    {
        foreach (Cinemachine.CinemachineFreeLook c in cams)
        {
            c.enabled = false;


        }
    }

    public void Activate()
    {
        foreach (Cinemachine.CinemachineFreeLook c in cams)
        {
            c.enabled = true;
        }
    }

    public void Invalidate()
    {
        foreach (Cinemachine.CinemachineFreeLook c in cams)
        {
            c.PreviousStateIsValid = false;
        }
        //Debug.Break();
    }

    public void TransformVCams()
    {
        foreach (Cinemachine.CinemachineFreeLook c in cams)
        {
            c.transform.position = this.position;
            c.transform.rotation = this.rotation;
        }
    }

    public Vector2 GetFreelookValues()
    {
        return new Vector2(cams[0].m_XAxis.Value, cams[0].m_YAxis.Value);
    }

    public void SetFreelookValues(Vector2 v)
    {
        foreach (Cinemachine.CinemachineFreeLook c in cams)
        {
            c.m_XAxis.Value = v.x;
            c.m_YAxis.Value = v.y;
        }
    }

    public void OnTargetObjectWarped(Transform t, Vector3 deltaPos)
    {
        foreach (Cinemachine.CinemachineFreeLook c in cams)
        {
            c.OnTargetObjectWarped(t, deltaPos);
        }
    }


    //// Update is called once per frame
    //void Update()
    //{

    //}
}
