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

            sv.gameObject.active = true;
            sv.LoadData(this);
            setInfo SP = GameObject.Find("StatusPanel").GetComponent<setInfo>();
            SP.setName(Name);
            string status = "HP: " + HP.ToString() + "\n"
                          + "ATK: " + ATK.ToString() + "\n"
                          + "DEF: " + DEF.ToString() + "\n"
                          + "SPD: " + SPD.ToString();
            SP.setStatus(status);
        }
    }
    public void OnMouseExit()
    {
        sv.gameObject.active = false;
    }

}
