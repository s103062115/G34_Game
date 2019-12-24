using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Event
{
    // Start is called before the first frame update
    public GameObject Left, Right;
    bool go;
    int count;
    Hero h;
    public int HpDecrease;
    public int SpdDecrease;

    void Start()
    {
        ID = 1;
        Name = "捕獸夾";
        text = "HP-" + HpDecrease + "\n";
        if (SpdDecrease > 0) text = text + "SPD-" + SpdDecrease + "\n";
        text += "用來捕捉野獸的陷阱。當然，會被捕到的不只有野獸。";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (go && count < 5)
        {
            count++;
            Right.transform.Rotate(-13f, 0, 0, 0);
            Left.transform.Rotate(13f, 0, 0, 0);
        }
        if (count >= 5)
        {
            Destroy(gameObject);
        }
    }

    public override void Effect(Hero hero)
    {
        h = hero;
        go = true;
        hero.message = hero.Name + "受到" + HpDecrease + "點傷害";
        if(SpdDecrease > 0)
            hero.extraMessage = hero.Name + "的SPD下降了" + SpdDecrease;
        hero.HP -= HpDecrease;
        if(SpdDecrease > 0)
            hero.Base_SPD -= SpdDecrease;
        if (hero.Base_SPD < 0) hero.Base_SPD = 0;
        hero.anim.SetBool("damage", true) ;
    }
}
