using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMachine
{
    public BossIdle bossIdle;
    public BossRamming bossRamming;
    public State current;

    public BossMachine(BossController bossController) {
        bossIdle = new BossIdle(bossController);
        bossRamming = new BossRamming(bossController);
    }
    public void Init(State state)
    {
        current = state;
        state.Enter();
    }
    public void Update()
    {
        if (current != null) current.Update();
    }
    public void Transition(State next)
    {
        current.Exit();
        current = next;
        next.Enter();
    }
}
