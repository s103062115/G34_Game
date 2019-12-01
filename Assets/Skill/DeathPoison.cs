using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPoison : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        Name = "致命劇毒";
        User = gameObject.GetComponent<Creature>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Effect()
    {
        base.Effect();
        if (!(User.enemy.GetType().ToString() == "Hero" && User.SC.Armor.ID == 10))
        {

            User.enemy.damage = User.enemy.HP * User.enemy.DEF;

        }
        else User.enemy.damage = 0;

    }
}
