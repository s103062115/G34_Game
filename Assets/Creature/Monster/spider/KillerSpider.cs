using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerSpider : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if(HP==0)HP = 1;
        if (ATK == 0) ATK = 1;
        if (DEF == 0) DEF = 1;
        if (SPD == 0) SPD = 11;
        if (Name =="") Name = "劇毒蜘蛛";
        //Drop = 0;
        //Coin = 3;
        if (text == "") text = "看似弱小，卻蘊含著致命的猛毒，面對任何敵人都是一擊必殺！" ;
        reStatus();
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        MC = GameObject.Find("MessageController").GetComponent<MessageController>();
        skill = gameObject.GetComponent<DeathPoison>();
        UI = GameObject.Find("Canvas").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void turn()
    {
        skill.Effect();
    }
}
