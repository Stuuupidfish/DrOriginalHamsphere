using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance
{
    private int x1,x2;
    private int y1,y2;
    private int dir;
    private int room1;
    private int room2;
    private bool room;

    public Entrance(int lX1, int lY1,int lX2, int lY2, int lDir, int lRoom1, int lRoom2, bool lRoom) {
        x1 = lX1;
        y1 = lY1;
        x2 = lX2;
        y2 = lY2;
        dir = lDir;
        room1 = lRoom1;
        room2 = lRoom2;
        room = lRoom;
    }
}
