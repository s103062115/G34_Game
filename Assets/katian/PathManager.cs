using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    UI myUI;
    SystemController SC;
    Vector3[,,] pathXYZ = new Vector3[4, 4, 15];
    bool[,,] on = new bool[4, 4, 15];
    [Tooltip("input the amout of moves that each stage can use. (blank = 0)")]
    public int[] MovesOfStages;
    int operations;
    int[] UsedOfStages;
    int used;
    // Start is called before the first frame update
    void Start()
    {
        myUI = GameObject.Find("Canvas").GetComponent<UI>();
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        UsedOfStages = new int[MovesOfStages.Length];
    }
    public void setStage(int s)
    {
        operations = MovesOfStages[s - 1];
        used = UsedOfStages[s - 1] = 0;
        myUI.setMoves(operations);
    }
    public void insertButton(int stage, int row, int col, bool ison, Vector3 xyz)
    {
        pathXYZ[stage, row, col] = xyz;
        if (ison) on[stage, row, col] = true;
    }

    internal bool buildPath(Vector3Int ID, bool undo) // op is build
    {
        //if (undo && used == 0) Debug.LogError("Can't undo this.");
        if (!undo && used == operations) return false; // no moves available
        if (ID.y > 0)
            if (on[ID.x, ID.y - 1, ID.z]) return false;
        if (on[ID.x, ID.y + 1, ID.z]) return false;
        //if (on[ID.x, ID.y, ID.z]) Debug.LogError("Wrong move!");
        on[ID.x, ID.y, ID.z] = true;
        if (undo) used--;
        else used++;
        myUI.setMoves(operations - used);
        return true;
    }

    internal bool deletePath(Vector3Int ID, bool undo)
    {
        //if (undo && used == 0) Debug.LogError("Can't undo this.");
        if (!undo && used == operations) return false; // no moves available
        //if (!on[ID.x, ID.y, ID.z]) Debug.LogError("Wrong move!");
        on[ID.x, ID.y, ID.z] = false;
        if (undo) used--;
        else used++;
        myUI.setMoves(operations - used);
        return true;
    }
    public void buildAllPath()
    {
        for(int i=0; i<4; i++)
        {
            for(int j=0; j<4; j++)
            {
                for(int k=0; k<15; k++)
                {
                    if (on[i, j, k])
                        SC.makeRoad(pathXYZ[i, j, k].x, pathXYZ[i, j, k].z);
                }
            }
        }
    }
}
