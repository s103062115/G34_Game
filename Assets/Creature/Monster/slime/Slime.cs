using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        HP = 20;
        ATK = 10;
        DEF = 10;
        SPD = 9;
        Name = "史萊姆";
        Drop = 1;
        Coin = 3;
        text = "被打倒後凝縮的黏液具有使其他生物行動遲緩的能力，常被作為道具使用。";
        reStatus();
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        UI = GameObject.Find("Canvas").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Die()
    {
        base.Die();

    }
}
