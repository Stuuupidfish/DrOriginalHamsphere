using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : State
{
    public int velocity;
    BossController bossController;
    int timeForRam;
    public BossIdle(BossController lBossController) { 
        bossController = lBossController;
    }
    public void Enter()
    {
        timeForRam = 500;
        switch (bossController.phase)
        {
            case 3:
                velocity = 7;
                break;
            default:
                velocity = 4;
                break;
        }

    }
    public void Update() 
    {
        bossController.updateVel(velocity);
        timeForRam--;
        if (bossController.phase != 1)
        {
            if (UnityEngine.Random.Range(0, 600) == 349)
            {
                bossController.machine.Transition(bossController.machine.bossRamming);
            }
        }
    }
    public void Exit() 
    {
        
    }
}
