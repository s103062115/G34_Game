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
        if(Name == "") Name = "普通的劍";
        if(ATK == 0) ATK = 5;
        if(status == "") status = "ATK+5";
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
