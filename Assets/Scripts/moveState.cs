using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveState : State
{
    PlayerController player;
    public moveState(PlayerController lPlayer)
    {
        player = lPlayer;

    }

    public void Enter()
    {
        player.move(Input.GetAxisRaw("Horizontal"));


    }
    public void Update()
    {
        int i = (int)Input.GetAxisRaw("Horizontal");
        player.move(i);
        if (Input.GetAxisRaw("Horizontal") == 0) {
            player.machine.Transition(player.machine.idle);
        }

    }
    public void Exit()
    {
       
    }
}
