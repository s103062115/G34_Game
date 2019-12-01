using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustyCurse : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        Name = "鏽蝕的詛咒";
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
        if (!((h = User.enemy.gameObject.GetComponent<Hero>())&& User.SC.Armor.ID == 10))
        {
            User.enemy.damage = 1;
            if (h != null)
            {
                if (h.Base_SPD < 3) h.Base_SPD = 0;
                else h.Base_SPD -= 3;
                if (h.Base_ATK < 3) h.Base_ATK = 0;
                else h.Base_ATK -= 3;
            }
            else
            {
                if (User.enemy.SPD < 3) User.enemy.SPD = 0;
                else User.enemy.SPD -= 3;
                if (User.enemy.ATK < 3) User.enemy.ATK = 0;
                else User.enemy.ATK -= 3;
            }
            User.enemy.message = User.enemy.Name+"的ATK‧SPD下降了3";

        }
        else User.enemy.damage = 0;

    }
}
