using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderKing : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        HP = 40;
        ATK = 15;
        DEF = 15;
        SPD = 15;
        Name = "巨大蜘蛛";
        Drop = 1;
        Coin = 3;
        reStatus();
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        UI = GameObject.Find("Canvas").GetComponent<UI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
