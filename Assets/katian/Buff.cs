using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : Event
{
    // Start is called before the first frame update
    public GameObject Left, Right;
    bool go;
    int count;
    Hero h;
    public int MaxHpIncrease;
    public int HpIncrease;
    public int AtkIncrease;
    public int DefIncrease;
    public int SpdIncrease;
    /*
    public byte colorR;
    public byte colorG;
    public byte colorB;
    */
    void Start()
    {
        Debug.Log("Buff 最多1種 不算MAXHP");
        ID = 1;
        //Name = "";
        text = "";
        if (HpIncrease > 0)
            text = text + "HP+" + HpIncrease + "\n";
        if (AtkIncrease > 0)
            text = text + "ATK+" + AtkIncrease + "\n";
        if (DefIncrease > 0)
            text = text + "DEF+" + DefIncrease + "\n";
        if (SpdIncrease > 0)
            text = text + "SPD+" + SpdIncrease + "\n";
        if (MaxHpIncrease > 0)
            text = text + "HP上限+" + MaxHpIncrease + "\n";
        /*if (colorB > 0 || colorG > 0 || colorR > 0)
        {
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_TintColor", new Color32(colorR, colorG, colorB, 128));
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }

    public override void Effect(Hero hero)
    {
        base.Effect(hero);

        string text;
        
        if (HpIncrease > 0)
        {
            text = hero.Name + "獲得了" + "HP+" + HpIncrease + "的BUFF";
            hero.MC.newMessage(text);
            hero.HP += HpIncrease;
            if (hero.HP > hero.MAX_HP) hero.HP = hero.MAX_HP;
        }
        if (AtkIncrease > 0)
        {
            text = hero.Name + "獲得了" + "ATK+" + AtkIncrease + "的BUFF";
            hero.MC.newMessage(text);
            hero.Base_ATK += AtkIncrease;
        }
        if (DefIncrease > 0)
        {
            text = hero.Name + "獲得了" + "DEF+" + DefIncrease + "的BUFF";
            hero.MC.newMessage(text);
            hero.Base_DEF += DefIncrease;
        }
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
        }
        hero.Resume();
        Destroy(gameObject);
    }
}
