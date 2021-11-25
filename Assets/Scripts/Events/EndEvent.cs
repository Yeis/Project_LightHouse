using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DreamTeam.Lighthouse.Core.Events;

public class EndEvent : GameEvent
{
    private UIController uIController;
    private bool hasEnded;

    public EndEvent(int delayInMiliSeconds = 0) : base(delayInMiliSeconds)
    {
        uIController = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        this.hasEnded = false;
    }
    protected internal override bool HasEnded()
    {
        return this.hasEnded;
    }

    protected internal override bool IsReady()
    {
       return uIController != null && !hasEnded;
    }

    protected internal override void Run()
    {
        uIController.FadeIn();
        SceneManager.LoadScene("Main_Menu");
        
    }
}