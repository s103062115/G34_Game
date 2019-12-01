using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltyCurse : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        Name = "溶甲的詛咒";
        User = gameObject.GetComponent<Creature>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Effect()
    {
        Hero h;
        base.Effect();
        if (!((h = User.enemy.gameObject.GetComponent<Hero>()) && User.SC.Armor.ID == 10))
        {
            User.enemy.damage = 1;
            if (h != null)
            {
                if (h.Base_DEF < 5) h.Base_DEF = 0;
                else h.Base_DEF -= 5;
            }
            else
            {
                if (User.enemy.DEF < 5) User.enemy.DEF = 0;
                else User.enemy.DEF -= 5;
            }
            User.enemy.message = User.enemy.Name + "的DEF下降了5";

        }
        else User.enemy.damage = 0;

    }
}
