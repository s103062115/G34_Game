using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Monster : Creature
{

    public int Coin;
    public int Drop;
    public string text;
    public UI UI;
    bool detail;
    public Skill skill;
    public string status;
    public static string clickToShowDetail = "\n點擊獲得更多資訊";
    //public GUI[] UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseUpAsButton()
    {

        

    }
    public void OnMouseEnter()
    {


        if (SC.GetPart() == -3)
        {

            UI.showStatusPanel(1);
            UI.setName(Name);
            UI.setStatus(status);
        }
        else if(SC.GetPart() == 0)
        {
            UI.showStatusPanel(0);
            UI.setName(Name);
            UI.setStatus(status + clickToShowDetail);
        }
            //statusP.active = true;
            //sv.LoadData(this);
           
            
            
        
    }
    public void OnMouseExit()
    {
        //UI UI = GameObject.Find("Canvas").GetComponent<UI>();
        if (SC.GetPart() == 0 || SC.GetPart() == -3)
        {
            UI.hideStatusPanel();
        }
    }
    private void OnMouseDown()
    {
        if(SC.GetPart() != -3)
        {
            if (!detail)
            {
                UI.setStatus(text);
            }
            else UI.setStatus(status + clickToShowDetail);
            detail = !detail;
        }
        else
        {
            SC.List[SC.standbyItem].Effect(this);
        }
        
    }

    public virtual void Die()
    {
        SC.AddItem(Drop);
        SC.Coin += Coin;
        Destroy(gameObject);
    }
    /*public override void FixedUpdate()
    {
        base.FixedUpdate();
    }*/

    public void reStatus()
    {
        status =  "HP: " + HP+ "\n"
            + "ATK: " + ATK + "\n"
            + "DEF: " + DEF + "\n"
            + "SPD: " + SPD;
    }
}
