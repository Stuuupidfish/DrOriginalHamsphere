using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airState : State
{
    private PlayerController player;
    bool jumping;
    int jumps;
    int oJumps;
    public airState(PlayerController lPlayer, int lJumps) {
        player = lPlayer;
        oJumps = lJumps;
        //player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 10);
    }
    // Start is called before the first frame update
    public void Enter() {
        jumping = Input.GetKey(KeyCode.Z);
        jumps = oJumps;
    }

    // Update is called once per frame
    public void Update()
    {
        player.move(Input.GetAxisRaw("Horizontal"));
        if (jumping && jumps > 0)
        {
            jumping = Input.GetKey(KeyCode.Z);
            player.GetComponent<Rigidbody2D>().velocity =  new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 10);
            jumps--;
        }
        else {
            jumping = false;
            if (Input.GetKeyDown(KeyCode.Z)) {
                player.jumpFrame = 90;
            }
        }
        if (player.ground) {
            player.machine.Transition(player.machine.idle);
        }
    }

    public void Exit() {
        Debug.Log("Exit air");
    }
}
