using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 20;
        ATK = 10;
        DEF = 10;
        SPD = 9;
        Name = "史萊姆";
        Drop = 1;
        Coin = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
