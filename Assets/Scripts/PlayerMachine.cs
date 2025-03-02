using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachine
{
    public State current;
    public idleState idle;
    public moveState move;
    public airState air;

    public PlayerMachine(PlayerController player) {
        idle = new idleState(player);
        move = new moveState(player);
        air = new airState(player,50);
    }

    public void Init(State state) {
        current = state;
        state.Enter();
    }
    public void Update() {
        if (current != null) current.Update();    
    }
    public void Transition(State next) {
        current.Exit();
        current = next;
        next.Enter();
    }
    
}
