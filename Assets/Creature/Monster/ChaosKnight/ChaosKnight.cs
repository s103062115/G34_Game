using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosKnight : Monster
{
    // Start is called before the first frame update
    public Skill skill2;
    int turn_n;
    void Start()
    {
        anim = GetComponent<Animator>();
        HP = 40;
        ATK = 15;
        DEF = 15;
        SPD = 12;
        Name = "混沌騎士";
        Drop = 0;
        Coin = 3;
        text = "前王國最強騎士受到多重詛咒後變成的魔物，擁有將自身被施加的詛咒轉嫁給他人的能力。";
        reStatus();
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        MC = GameObject.Find("MessageController").GetComponent<MessageController>();
        skill = gameObject.GetComponent<MeltyCurse>();
        skill2 = gameObject.GetComponent<RustyCurse>();
        UI = GameObject.Find("Canvas").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void turn()
    {
        turn_n++;
        if (turn_n == 4) skill.Effect();
        else if (turn_n == 2) skill2.Effect();
        else base.turn();
    }
}
