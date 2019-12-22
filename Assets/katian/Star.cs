using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Event
{
    public SystemController SC;
    // Start is called before the first frame update
    private int status = 0; //0 for lie 1 for stand
    void Start()
    {
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        ID = 5;
        Name = "星星";
        text = "很漂亮的星星，如果能收集到很多的話心情會很好。";
    }

    void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0); 
    }
    public void stand()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, -90);
        status = 1;
    }
    public void lie()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        status = 0;
    }
    public override void Effect(Hero hero)
    {
        SC.gainStar();
        hero.MC.newMessage(hero.Name + "獲得了星星");
        //hero.MC.newMessage("星星化為十枚金幣");
        hero.Resume();
        Destroy(gameObject);
    }
}
