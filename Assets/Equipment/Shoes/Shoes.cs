using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : Equipment
{
    // Start is called before the first frame update
    void Start()
    {
        Type = 3;
        ID = 20;
        Name = "普通的鞋子";
        SPD = 3;
        status = "SPD+3\n";
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
