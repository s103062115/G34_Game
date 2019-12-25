using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWithBuff : Monster
{
    // Start is called before the first frame update
    public byte colorR;
    public byte colorG;
    public byte colorB;
    Hero hero;
    public int buffAtk;
    public int buffDef;
    void Start()
    {
        hero = GameObject.Find("knight").GetComponent<Hero>();
        anim = GetComponent<Animator>();
        if (Name == "") Name = "史萊姆";
        //if (Coin == 0) Coin = 3;
        if (text == "") text = "被打倒後凝縮的黏液具有使其他生物行動遲緩的能力，常被作為道具使用。";
        reStatus();
        MC = GameObject.Find("MessageController").GetComponent<MessageController>();
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        UI = GameObject.Find("Canvas").GetComponent<UI>();
        if (colorB > 0 || colorG > 0 || colorR > 0)
            gameObject.transform.Find("ModelSlime").GetComponent<SkinnedMeshRenderer>().material.color = new Color32(colorR, colorG, colorB, 255);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Die()
    {
        base.Die();

        string text;

        /*if (HpIncrease > 0)
        {
            text = hero.Name + "獲得了" + "HP+" + HpIncrease + "的BUFF";
            hero.MC.newMessage(text);
            hero.HP += HpIncrease;
            if (hero.HP > hero.MAX_HP) hero.HP = hero.MAX_HP;
        }*/
        if (buffAtk > 0)
        {
            text = hero.Name + "獲得了" + "ATK+" + buffAtk + "的BUFF";
            hero.MC.newMessage(text);
            hero.Base_ATK += buffAtk;
        }
        if (buffDef > 0)
        {
            text = hero.Name + "獲得了" + "DEF+" + buffDef + "的BUFF";
            hero.MC.newMessage(text);
            hero.Base_DEF += buffDef;
        }/*
        if (SpdIncrease > 0)
        {
            text = hero.Name + "獲得了" + "SPD+" + SpdIncrease + "的BUFF";
            hero.MC.newMessage(text);
            hero.Base_SPD += SpdIncrease;
        }
        if (MaxHpIncrease > 0)
        {
            text = hero.Name + "獲得了" + "HP上限+" + MaxHpIncrease + "的BUFF";
            hero.MC.newMessage(text);
            hero.MAX_HP += MaxHpIncrease;
        }*/
        hero.Resume();
    }
}
