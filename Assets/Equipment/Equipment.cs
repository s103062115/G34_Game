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
    public TreasureViewer tv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseOver()
    {


        Ray mouseRay1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;

        if (Physics.Raycast(mouseRay1, out rayHit, 1000f) && !gameObject.GetComponent<Hero>())

        {

            tv.gameObject.active = true;
            tv.LoadData(this);
        }
    }
    public void OnMouseExit()
    {
        tv.gameObject.active = false;
    }
}
