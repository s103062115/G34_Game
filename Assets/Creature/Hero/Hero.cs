using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Creature
{
    //public bool horizon;
    private Equipment Nothing;
    public Equipment Weapon, Armour, Shoes, Accessory;
    public Skill Skill;
    public int MAX_HP,MAX_MP;
    private int Base_HP, Base_ATK, Base_DEF, Base_SPD, Base_MAT, Base_MDF, Base_MP;
    public object System;
    public SystemController SystemController;
    // Start is called before the first frame update
    void Start()
    {
        HP = MAX_HP = Base_HP = 11;
        ATK = Base_ATK = 10;
        DEF = Base_DEF = 10;
        SPD = Base_SPD = 10;
        MP = MAX_MP = Base_MP = 10;
        
        Nothing = this.gameObject.AddComponent<Equipment>();
        Nothing.Name = "未裝備";
        Weapon = Nothing;
        Armour = Nothing;
        Shoes = Nothing;
        Accessory = Nothing;
    }

    // Update is called once per frame
    void Update()
    {
        ReStatus();
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
    }*/
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
    }
    public void ReStatus()
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Monster>())
        {
            SystemController.Versus(collision.gameObject.GetComponent<Monster>()) ;
        }else if (collision.gameObject.GetComponent<Equipment>())
        {
            SystemController.PickEquipment(collision.gameObject.GetComponent<Equipment>());
        }
    }
}
