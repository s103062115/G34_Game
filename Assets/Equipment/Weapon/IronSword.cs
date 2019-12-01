using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSword : Equipment
{
    // Start is called before the first frame update
    void Start()
    {
        Type = 1;
        ID = 2;
        Name = "鋼鐵劍";
        ATK = 10;
        status = "ATK+10";
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
