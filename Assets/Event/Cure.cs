using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : Event
{
    // Start is called before the first frame update
    void Start()
    {
        ID = 4;
        Name = "神聖氣息";
        text = "HP回復10\n邪惡力量的膨脹使得本來分散在大氣中的神聖靈氣被排擠到一處所形成。";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Effect(Hero hero)
    {
        base.Effect(hero);
        hero.HP += 10;
        hero.MC.newMessage(hero.Name+"的HP回復了10");
        hero.Resume();
        Destroy(gameObject);
    }
}
