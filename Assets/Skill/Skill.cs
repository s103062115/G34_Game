using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public int Power;
    public string Name;
    public Creature User;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Effect()
    {
        User.message = (User.Name + "使出" + Name);
        User.anim.SetBool("skill", true);
    }

}
