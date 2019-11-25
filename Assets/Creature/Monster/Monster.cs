using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Monster : Creature
{

    public int Coin;
    public int Drop;
    public StatusViewer sv;
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
    public void OnMouseOver()
    {
        
    
        Ray mouseRay1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;

        if (Physics.Raycast(mouseRay1, out rayHit, 1000f))

        {
            //sv.gameObject.active = true;
            //sv.LoadData(this);
            string status = "HP: " + HP.ToString() + "\n"
                          + "ATK: " + ATK.ToString() + "\n"
                          + "DEF: " + DEF.ToString() + "\n"
                          + "SPD: " + SPD.ToString();
            UI UI = GameObject.Find("Canvas").GetComponent<UI>();
            UI.setName(Name);
            UI.setStatus(status);
            UI.showStatusPanel();
        }
    }
    public void OnMouseExit()
    {
        //sv.gameObject.active = false;
        UI UI = GameObject.Find("Canvas").GetComponent<UI>();
        UI.hideStatusPanel();
    }

}
