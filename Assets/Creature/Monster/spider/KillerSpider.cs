using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerSpider : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        /*HP = 1;
        ATK = 1;
        DEF = 1;
        SPD = 11;
        Name = "劇毒蜘蛛";
        Drop = 0;
        Coin = 3;
        text = "看似弱小，卻蘊含著致命的猛毒，面對任何敵人都是一擊必殺！" ;*/
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
