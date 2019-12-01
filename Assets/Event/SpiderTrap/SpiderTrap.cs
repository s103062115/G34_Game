using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrap : Event
{
    // Start is called before the first frame update
    public GameObject spider;
    void Start()
    {
        ID = 2;
        Name = "蜘蛛網";
        text = "SPD-5\n劇毒蜘蛛的巢，不仔細看就難以發現，巢的主人不見蹤影，但……";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Effect(Hero hero)
    {
       
        hero.MC.newMessage(hero.Name + "的SPD下降了５");
        if (hero.Base_SPD < 5) hero.Base_SPD = 0;
        else hero.Base_SPD -= 5;
        Instantiate(spider, new Vector3(transform.position.x, 1 , transform.position.z), Quaternion.Euler(0,-90,0));
        Destroy(gameObject);
    }
}
