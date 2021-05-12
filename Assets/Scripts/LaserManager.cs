﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserManager : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.01f;
    public OVRInput.Controller controllerType;
    public float dist;
    private Vector3 startPoint;
    public GameObject centerEye;
    public GameObject textFridge1;
    public GameObject textFridge2;
    public GameObject textFridge3;
    public GameObject textClock1;
    public GameObject textClock2;
    public GameObject textClock3;
    public GameObject clock;
    public GameObject tvImage;

    // Start is called before the first frame update
    void Start()
    {
        laserLineRenderer.positionCount = 2;
        laserLineRenderer.SetPosition(0, Vector3.zero);
        laserLineRenderer.SetPosition(1, Vector3.zero);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
        dist = 10.0f;
        startPoint = new Vector3(0, 1.5f, 0);
        textFridge1.SetActive(false);
        textFridge2.SetActive(false);
        textFridge3.SetActive(false);
        textClock1.SetActive(false);
        textClock2.SetActive(false);
        textClock3.SetActive(false);
        tvImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetActiveController() == controllerType)
        {
            startPoint = centerEye.transform.position;
            laserLineRenderer.SetPosition(0, startPoint + OVRInput.GetLocalControllerPosition(controllerType));
            laserLineRenderer.SetPosition(1, startPoint + OVRInput.GetLocalControllerPosition(controllerType) + dist * (OVRInput.GetLocalControllerRotation(controllerType) * Vector3.forward));

            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                RaycastHit hit;
                if (Physics.Raycast(startPoint + OVRInput.GetLocalControllerPosition(controllerType), startPoint + OVRInput.GetLocalControllerPosition(controllerType) + dist * (OVRInput.GetLocalControllerRotation(controllerType) * Vector3.forward), out hit, 15f))
                {
                    if (hit.collider != null)
                    {
                        switch (hit.transform.gameObject.name)
                        {
                            case "PFB_Fridge":
                                textFridge1.SetActive(!textFridge1.activeSelf);
                                textFridge2.SetActive(!textFridge2.activeSelf);
                                textFridge3.SetActive(!textFridge3.activeSelf);
                                break;
                            case "Clock":
                                textClock1.SetActive(!textClock1.activeSelf);
                                textClock2.SetActive(!textClock2.activeSelf);
                                textClock3.SetActive(!textClock3.activeSelf);
                                break;
                            case "Text_Clock3":
                                tvImage.SetActive(!tvImage.activeSelf);
                                break;
                        }
                    }
                }
            }

            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
            {
                
            }
        }
    }
}
