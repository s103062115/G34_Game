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
    void Start()
    {
        ID = 1;
        Name = "捕獸夾";
        text = "HP-5\nSPD-2\n用來捕捉野獸的陷阱。當然，有時候也會捕到人。";
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
        hero.message = hero.Name+"受到5點傷害";
        hero.extraMessage = hero.Name + "的SPD下降了2";
        hero.HP -= 5;
        if (hero.Base_SPD < 2) hero.Base_SPD = 0;
        else hero.Base_SPD -= 2;
        hero.anim.SetBool("damage", true) ;
    }
}
