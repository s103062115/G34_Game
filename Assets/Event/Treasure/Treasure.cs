using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Event
{
    // Start is called before the first frame update
    public Item item;
    public SystemController SC;
    public Animator anim;

    static int closeState = Animator.StringToHash("Base Layer.box_close");

    Hero h;
    void Start()
    {
        item = gameObject.GetComponent<Item>();
        anim = GetComponent<Animator>();
        Name = "寶箱";
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        reText();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).nameHash == closeState)
        {
            h.Resume();
            Destroy(gameObject);
        }
    }
    public override void Effect(Hero hero)
    {
        h = hero;
        //base.Effect(hero);
        anim.SetBool("open", true);
        if(item!=null)SC.AddItem(item.ID);
    }
    public override void reText()
    {
        if (item != null) text = item.Name + "1個";
    }
}
