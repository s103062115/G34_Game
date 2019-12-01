using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Equipment
{
    // Start is called before the first frame update
    
    void Start()
    {
        Type = 1;
        ID = 1;
        Name = "普通的劍";
        ATK = 5;
        status = "ATK+5";
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
