using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpking : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 40;
        ATK = 10;
        DEF = 10;
        SPD = 9;
        Name = "貪吃南瓜";
        Drop = 0;
        Coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
