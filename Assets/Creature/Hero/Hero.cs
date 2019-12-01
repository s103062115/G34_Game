using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Creature
{
    //public bool horizon;
    //private Equipment Nothing;
    public int dir;
    //public Equipment Weapon, Armour, Shoes, Accessory;
    public Skill Skill;
    public int MAX_HP,MAX_MP;
    public int Base_HP, Base_ATK, Base_DEF, Base_SPD, Base_MAT, Base_MDF, Base_MP;
    
    //public object System;
    static int walkState = Animator.StringToHash("Base Layer.Walk");
    static int buffState = Animator.StringToHash("Base Layer.PowerUP");
    static int pickSState = Animator.StringToHash("Base Layer.PickSword");
    static int walkLState = Animator.StringToHash("Base Layer.WalkL");
    static int walkRState = Animator.StringToHash("Base Layer.WalkR");

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        HP = MAX_HP = Base_HP = 11;
        ATK = Base_ATK = 10;
        DEF = Base_DEF = 10;
        SPD = Base_SPD = 10;
        MP = MAX_MP = Base_MP = 10;
        dir = 0;
        Name = "玩家";
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {
        //ReStatus();
    }
    public override void FixedUpdate()
    {
        //newState = anim.GetCurrentAnimatorStateInfo(0).nameHash;
        base.FixedUpdate();
        /*if (newState == walkState)
        {
            
            if (dir == 0)
            {
                
                
            }
        }else if(newState == walkLState)
        {
            //anim.SetBool("walkL", false);
            //anim.SetBool("walk", true);
        }
        else if (newState == walkRState)
        {
            //anim.SetBool("walkR", false);
            //anim.SetBool("walk", true);
        }
        else if(newState == turnRState)
        {
            anim.SetBool("turn_right", false);
            anim.SetBool("walk", true);
            //gameObject.transform.Rotate(new Vector3(0, 2f, 0));
        }else if (newState == turnLState)
        {
            anim.SetBool("turn_left", false);
            anim.SetBool("walk", true);
            //gameObject.transform.Rotate(new Vector3(0, -2f, 0));
        }
        else*/
        if (newState == buffState)
        {
            anim.SetBool("buff", false);
            //anim.SetBool("walk", true);
        }
        else if (newState == pickSState)
        {
            anim.SetBool("picksword", false);
            anim.SetBool("walk", true);
        }
        if (HP <= 0) anim.SetBool("dead", true);


        
    }

    /*public void Equip(Equipment Equipment)
    {
        
        if (Equipment.Type != 0)Unequip(Equipment.Type);
        if (Equipment.Type == 1)
        {
            Weapon = Equipment;
        }
        else if (Equipment.Type == 2)
        {
            Armour = Equipment;
        }
        else if (Equipment.Type == 3)
        {
            Shoes = Equipment;
        }
        else if (Equipment.Type == 4)
        {
            Accessory = Equipment;
        }
        ReStatus();
    }

    public void Unequip(int Type)
    {
        
        if (Type == 1)
        {
            if(Weapon != Nothing) Destroy(Weapon);
            Weapon = Nothing;
        }
        else if (Type == 2)
        {
            if (Armour != Nothing) Destroy(Armour);
            Armour = Nothing;
        }
        else if (Type == 3)
        {
            if (Shoes != Nothing) Destroy(Shoes);
            Shoes = Nothing;
        }
        else if (Type == 4)
        {
            if (Accessory != Nothing) Destroy(Accessory);
            Accessory = Nothing;
        }
        
        //ReStatus();
    }*/
    /*public void ReStatus()
    {
        MAX_HP = Base_HP + Weapon.HP + Armour.HP + Shoes.HP + Accessory.HP;
        ATK = Base_ATK + Weapon.ATK + Armour.ATK + Shoes.ATK + Accessory.ATK;
        DEF = Base_DEF + Weapon.DEF + Armour.DEF + Shoes.DEF + Accessory.DEF;
        SPD = Base_SPD + Weapon.SPD + Armour.SPD + Shoes.SPD + Accessory.SPD;
        MAT = Base_MAT + Weapon.MAT + Armour.MAT + Shoes.MAT + Accessory.MAT;
        MDF = Base_MDF + Weapon.MDF + Armour.MDF + Shoes.MDF + Accessory.MDF;
        MAX_MP = Base_MP + Weapon.MP + Armour.MP + Shoes.MP + Accessory.MP;
        if (HP > MAX_HP) HP = MAX_HP;
        if (MP > MAX_MP) MP = MAX_MP;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Monster>())
        {
            Pause();
            SC.Versus(collision.gameObject.GetComponent<Monster>()) ;
        }else if (collision.gameObject.GetComponent<Equipment>())
        {
            SC.PickEquipment(collision.gameObject.GetComponent<Equipment>());
        }
        else if (collision.gameObject.GetComponent<Event>())
        {
            Pause();
            collision.gameObject.GetComponent<Event>().Effect(this);
        }
    }
    public void Pause()
    {
        if (dir == 0) anim.SetBool("walk", false);
        else if (dir == 1) anim.SetBool("walkR", false);
        else if (dir == 3) anim.SetBool("walkL", false);
    }
    public void Resume()
    {
        if (dir == 0) anim.SetBool("walk", true);
        else if (dir == 1) anim.SetBool("walkR", true);
        else if (dir == 3) anim.SetBool("walkL", true);
    }
    public bool dontwalk()
    {
        if (currentState != walkState && dir == 0) return true;
        if (anim.GetBool("walk") == false && dir == 0) return true;
        if (currentState != walkLState && dir == 3) return true;
        if (anim.GetBool("walkL") == false && dir == 3) return true;
        if (currentState != walkRState && dir == 1) return true;
        if (anim.GetBool("walkR") == false && dir == 1) return true;
        return false;
    }

    public override void end()
    {
        SC.battleend(false);
    }
    public void gotoNext()
    {
        dir = 0;
        //anim.SetBool("walk", false);
    }
}