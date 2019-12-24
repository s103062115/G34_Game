using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarArmor : Equipment
{
    // Start is called before the first frame update
    void Start()
    {
        Type = 2;
        ID = 11;
        Name = "蠻王的戰甲";
        ATK = 5;
        status = "ATK+5\n攻擊就是最大的防禦！只要穿上這件戰甲，就連法師都會化身為狂戰士。";
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}