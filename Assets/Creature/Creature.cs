using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public string Name;
    public int State;// idle = 0, attack = 1, die = 2
    public int HP, ATK, DEF, SPD, MAT, MDF, MP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die()
    {
        State = 2;
        Destroy(this.gameObject);
    }
    public int Attack()
    {
        State = 1;
        return ATK * 10;
    }
    public void GetDamage(int Damage)
    {
        HP -= Damage / DEF;
        //print(Damage);
    }
    public void GetMagicDamage(int Damage)
    {
        HP -= Damage / MDF;
        
    }
}
