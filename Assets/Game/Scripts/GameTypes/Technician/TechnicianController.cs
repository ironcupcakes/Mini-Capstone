﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnicianController : Singleton<TechnicianController>
{
    public GameObject ImageMatchControllerObject, LockRotationControllerObject, FrontPageObject, TimingButtonControllerObject;
    private ImageMatchGameController imageGameController;
    private LockRotationGameController lockGameController;
    private TimingButtonController timingGameController;


    private bool Setup = false;

    private void Start()
    {
        imageGameController = ImageMatchControllerObject.GetComponent<ImageMatchGameController>();
        lockGameController = LockRotationControllerObject.GetComponent<LockRotationGameController>();
        timingGameController = TimingButtonControllerObject.GetComponent<TimingButtonController>();
    }

    private void Update()
    {
        if (!Setup)
        {
            ImageMatchControllerObject.SetActive(false);
            LockRotationControllerObject.SetActive(false);
            Setup = true;
        }
    }

    public void FrontPage_ImageMatchPress()
    {
        FrontPageObject.SetActive(false);
        ImageMatchControllerObject.SetActive(true);
        imageGameController.resetGame();
    }

    public void FrontPage_LockRotatePress()
    {
        FrontPageObject.SetActive(false);
        LockRotationControllerObject.SetActive(true);
        lockGameController.resetGame();

    }

    public void FrontPage_TimingButtonPress()
    {
        FrontPageObject.SetActive(false);
        TimingButtonControllerObject.SetActive(true);
        timingGameController.ResetGame();
    }

    public void ImageMatch_BackPress()
    {
        FrontPageObject.SetActive(true);
        ImageMatchControllerObject.SetActive(false);
        GameNetwork.Instance.BroadcastMessage("TechnicianMessengerReset");
        
    }

    public void LockRotate_BackPress()
    {
        FrontPageObject.SetActive(true);
        LockRotationControllerObject.SetActive(false);
        GameNetwork.Instance.BroadcastMessage("TechnicianMessengerReset");
    }

    public void TimingButton_BackPress()
    {
        FrontPageObject.SetActive(true);
        TimingButtonControllerObject.SetActive(false);
        GameNetwork.Instance.BroadcastMessage("TechnicianMessengerReset");
    }
}
