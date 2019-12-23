using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverArmor : Equipment
{
    // Start is called before the first frame update
    void Start()
    {
        Type = 2;
        ID = 10;
        if(Name == "") Name = "白銀聖甲";
        if(DEF == 0) DEF = 5;
        if(status == "") status = "DEF+5\n受到精靈祝福的鎧甲。能夠抵禦一切猛毒與詛咒。";
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
