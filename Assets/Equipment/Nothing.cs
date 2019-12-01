using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing : Equipment
{
    // Start is called before the first frame update
    void Start()
    {
        Type = 0;
        ID = 0;
        Name = "未裝備";
        HP = ATK = DEF = SPD = MAT = MDF = MP = 0;
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
