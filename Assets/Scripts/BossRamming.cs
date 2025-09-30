using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossRamming : State
{
    public int velocity;
    BossController bossController;
    int countdown;
    public BossRamming(BossController lBossController)
    {
        bossController = lBossController;
        velocity = 10;
    }
    public void Enter()
    {
        bossController.updateVel(velocity);
        countdown = 250;
    }
    public void Update()
    {
        countdown--;
        if (countdown <= 0)
        {
            bossController.machine.Transition(bossController.machine.bossIdle);
        }
    }
    public void Exit()
    {

    }
}
