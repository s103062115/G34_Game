using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public int ID;
    public string Name;
    public int HP, ATK, DEF, SPD, MAT, MDF, MP;
    public int Type; // 武器 = 1, 盔甲 = 2, 鞋 = 3, 裝飾 = 4
    public Skill Skill;
    public string status;
    public SystemController SC;
    public string Source;
    UI UI;
    Hero h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseEnter()
    {


        if(UI == null)UI = GameObject.Find("Canvas").GetComponent<UI>();
        UI.showStatusPanel(0);
        UI.setName(Name);
        UI.setStatus(status);

    }
    public void OnMouseExit()
    {
        if (UI == null) UI = GameObject.Find("Canvas").GetComponent<UI>();
        UI.hideStatusPanel();
    }
    public void ALLzero()
    {
        ID = 0;
        Source = "";
        HP = 0;
        ATK = 0;
        DEF = 0;
        MAT = 0;
        MDF = 0;
        SPD = 0;
        MP = 0;
        Name = "未裝備";
        status = "";
    }
    public void Copy(Equipment equipment)
    {
        ID = equipment.ID;
        Source = equipment.GetType().ToString();
        HP = equipment.HP;
        ATK = equipment.ATK;
        DEF = equipment.DEF;
        MAT = equipment.MAT;
        MDF = equipment.MDF;
        SPD = equipment.SPD;
        MP = equipment.MP;
        Name = equipment.Name;
        status = equipment.status;
    }
    
}
