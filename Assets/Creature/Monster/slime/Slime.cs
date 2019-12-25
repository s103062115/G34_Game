using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    // Start is called before the first frame update
    public byte colorR;
    public byte colorG;
    public byte colorB;
    public bool CustomizedStatus;
    void Start()
    {
        anim = GetComponent<Animator>();
        if (!CustomizedStatus)
        {
            HP = 20;
            ATK = 10;
            DEF = 10;
            SPD = 9;
            Name = "史萊姆";
            Drop = 1;
            //if (Coin == 0) Coin = 3;
            text = "被打倒後凝縮的黏液具有使其他生物行動遲緩的能力，常被作為道具使用。";
        }
        reStatus();
        MC = GameObject.Find("MessageController").GetComponent<MessageController>();
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        UI = GameObject.Find("Canvas").GetComponent<UI>();
        if(colorB>0 || colorG>0 || colorR>0)
            gameObject.transform.Find("ModelSlime").GetComponent<SkinnedMeshRenderer>().material.color = new Color32(colorR, colorG, colorB, 255);
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
