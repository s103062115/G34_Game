using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string Name;
    public int Type;//自己為對象 = 0, 選一怪為對象 = 1
    public string status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(Hero User)
    {
        if (Type == 0) SelfEffect(User);
        else if (Type == 1) User.SC.SetPart(-2);
    }
    public virtual void Effect(Monster creature)
    {

    }
    public virtual void SelfEffect(Hero hero)
    {

    }
}
