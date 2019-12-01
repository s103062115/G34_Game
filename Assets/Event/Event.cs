using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public int ID;
    public string Name;
    public string text;
    UI UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Effect(Hero hero)
    {

    }
    public void OnMouseEnter()
    {


        if (UI == null) UI = GameObject.Find("Canvas").GetComponent<UI>();
        UI.showStatusPanel(0);
        UI.setName(Name);
        UI.setStatus(text);

    }
    public void OnMouseExit()
    {
        if (UI == null) UI = GameObject.Find("Canvas").GetComponent<UI>();
        UI.hideStatusPanel();
    }
}
