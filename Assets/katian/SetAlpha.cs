using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlpha : MonoBehaviour
{
    SystemController SC;
    PathManager PM;
    private bool valid = false;
    private float x;
    private float y;
    private float z;
    public bool originStateIsOn; // 0 for nothing 1 for exist
    public bool currentStateIsOn; // 0 for nothing 1 for exist
    Vector3Int ID;
    // Start is called before the first frame update
    void Start()
    {
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        PM = GameObject.Find("PathManager").GetComponent<PathManager>();
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
        currentStateIsOn = originStateIsOn;
        setRedTransparent(false, currentStateIsOn ? 0 : 2);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setID(Vector3Int v)
    {
        ID = v;
    }
    public void OnMouseUpAsButton()
    {
        if (currentStateIsOn)
        {
            deletePath(!originStateIsOn);
        }
        else
        {
            buildPath(originStateIsOn);
        }
        /*
        if(!valid)
            valid = SC.makeRoad(x, z);
        if (valid) Destroy(gameObject);
        */
    }

    private void buildPath(bool undo) // op to do is bulid
    {
        bool success = PM.buildPath(ID, undo);
        if (success)
        {
            setRedTransparent(!undo, 0);
            currentStateIsOn = true;
        }
    }

    private void deletePath(bool undo)
    {
        bool success = PM.deletePath(ID, undo);
        if (success)
        {
            setRedTransparent(!undo, 2);
            currentStateIsOn = false;
        }
    }

    public void OnMouseEnter()
    {
        bool white = originStateIsOn ^ currentStateIsOn;
        setRedTransparent(!white, 1);
        //gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }
    public void OnMouseExit()
    {
        bool red = originStateIsOn ^ currentStateIsOn;
        setRedTransparent(red, currentStateIsOn? 0: 2);
        //gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }
    public void appear()
    {
        gameObject.transform.position = new Vector3(x, y, z);
    }
    public void disappear()
    {
        gameObject.transform.position = new Vector3(x, -100.0f, z);
    }
    public void setRedTransparent(bool red, int transparent)
    {
        float a = 1.0f;
        if (transparent == 1) a = 0.6f;
        else if (transparent == 2) a = 0.15f;
        if(!red)
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, a);
        else
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.0f, 0.0f, a);
    }
}

/*

            一般    滑鼠     
    00      白透    紅半
    01      紅      白半
    10      紅透    白半
    11      白      紅半


 */