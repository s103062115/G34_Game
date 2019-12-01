using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDetail : MonoBehaviour
{
    // Start is called before the first frame update
    public UI UI;
    public SystemController SC;
    public int Type;
    public int Slot;
    public bool myturn;
    void Start()
    {
        /*UI = GameObject.Find("Canvas").GetComponent<UI>();
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();*/
        myturn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //print(Input.mousePosition);
        //print(transform.position);

        if (Type != 0 
            && Input.mousePosition.x - transform.position.x < 25 
            && Input.mousePosition.x - transform.position.x > -25
            && Input.mousePosition.y - transform.position.y > -25
            && Input.mousePosition.y - transform.position.y < 25)
        {
            myturn = true;
            UI.showStatusPanel(1);
            if (Type == 1)
            {
                UI.setName(SC.Weapon.Name);
                UI.setStatus(SC.Weapon.status);
            }
            else if (Type == 2)
            {
                UI.setName(SC.Armor.Name);
                UI.setStatus(SC.Armor.status);
            }
            else if (Type == 3)
            {
                UI.setName(SC.Shoes.Name);
                UI.setStatus(SC.Shoes.status);
            }else if (Type == 4)
            {
                UI.setName(SC.Accessory.Name);
                UI.setStatus(SC.Accessory.status);
            }
            else
            {
                myturn = false;
                UI.hideStatusPanel();
            }
        }
        else if (Type == 0
            && SC.List[Slot] != null
            && Input.mousePosition.x - transform.position.x < 20f
            && Input.mousePosition.x - transform.position.x > -20f
            && Input.mousePosition.y - transform.position.y > -20f
            && Input.mousePosition.y - transform.position.y < 20f)
        {
            myturn = true;
            UI.showStatusPanel(1);
            UI.setName(SC.List[Slot].Name);
            UI.setStatus(SC.List[Slot].status);
        }
        else if(myturn)
        {
            myturn = false;
            UI.hideStatusPanel();
        }
    }
}
