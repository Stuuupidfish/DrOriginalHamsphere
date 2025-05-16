using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : State
{
    
    PlayerController player;
    public idleState(PlayerController lPlayer) {
        player = lPlayer;
    }

    public void Enter() {
        //Debug.Log("Enter idle state");

    }
    public void Update() {
        if (Input.GetAxisRaw("Horizontal") != 0) {
            player.machine.Transition(player.machine.move);
        }
    }
    public void Exit() {
        //Debug.Log("Bye");
    }
}
