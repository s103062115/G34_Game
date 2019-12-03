using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mucus : Item

{
    // Start is called before the first frame update
    void Start()
    {
        Name = "史萊姆的黏液";
        ID = 1;
        Type = 1;
        status = "使場上一隻怪物的SPD下降2。";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Effect(Monster creature)
    {
        //base.Effect(creature);
        creature.MC.newMessage("使用了史萊姆的黏液");
        creature.MC.newMessage(creature.Name+"的SPD下降了2");
        creature.SPD -= 2;
        creature.reStatus();
        creature.SC.SetPart(-4);
    }

}
