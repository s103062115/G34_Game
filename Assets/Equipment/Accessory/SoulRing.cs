using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulRing : Equipment
{
    // Start is called before the first frame update
    void Start()
    {
        Type = 4;
        ID = 30;
        Name = "靈魂戒指";
        HP = 10;
        status = "HP上限+10\n";
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
