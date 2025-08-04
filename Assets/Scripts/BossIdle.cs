using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : State
{
    public int velocity;
    BossController bossController;
    public BossIdle(BossController lBossController) { 
        bossController = lBossController;
    }
    public void Enter()
    {
        // switch (bossController.phase)
        // {
        //     case 3:
        //         velocity = 10;
        //         break;
        //     default:
        //         velocity = 5;
        //         break;
        // }
        //
        //
        
    }
    public void Update() 
    {
        bossController.updateVel(velocity);
        // if (phase != 1)
        // {

        // }
    }
    public void Exit() 
    {
        
    }
}
