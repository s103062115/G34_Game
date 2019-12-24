using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject StatusPanel, Moves, HeroStatus;
    public GameObject Weapon, Armor, Accessory, Shoes, StatusContent, GP;
    public GameObject[] ItemSlot;
    SetInfo SP, M;
    public SystemController SC;
    bool show;
    PathManager PM;
    void Start()
    {

        PM = GameObject.Find("PathManager").GetComponent<PathManager>();
        //Transform t = gameObject.GetComponent<Transform>();
        //StatusPanel = GameObject.Find("StatusPanel");
        //SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        ItemSlot = GameObject.FindGameObjectsWithTag("ItemSlot").OrderBy(go => go.name).ToArray();
        for (int i = 0; i < 10; i++)
        {
            ItemSlot[i].SetActive(false);
        }
        /*if (!StatusPanel)
        {
            StatusPanel = Instantiate(Resources.Load("StatusPanel") as GameObject);
            StatusPanel.transform.SetParent(transform, false);
            StatusPanel.transform.localPosition = new Vector2(520, 0);
        }
        //Moves = GameObject.Find("Moves");
        if (!Moves)
        {
            Moves = Instantiate(Resources.Load("Moves") as GameObject);
            Moves.transform.SetParent(transform, false);
            Moves.transform.localPosition = new Vector2(568, 303);

        }*/
        /*HeroStatus = GameObject.Find("HeroStatus");
        Weapon = GameObject.Find("Weapon");
        Armor = GameObject.Find("Armor");
        Accessory = GameObject.Find("Accessory");
        Shoes = GameObject.Find("Shoes");
        StatusContent = GameObject.Find("Stats01_#");*/
        //show = true;
        SP = StatusPanel.GetComponent<SetInfo>();
        M = Moves.GetComponent<SetInfo>();
        M.setMoves(PM.MovesOfStages[0]);
        SetHeroStatus();
        //hideMoves();
        hideStatusPanel();
        hideHeroStatus();

    }
    public void SetHeroStatus()
    {
        if (SC.Weapon.ID != 0)
        {
            Weapon.SetActive(true);
            Weapon.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>(SC.Weapon.Source);
        }
        else Weapon.SetActive(false);
        if (SC.Shoes.ID != 0)
        {
            Shoes.SetActive(true);
            Shoes.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>(SC.Shoes.Source);
        }
        else Shoes.SetActive(false);
        if (SC.Armor.ID != 0)
        {
            Armor.SetActive(true);
            Armor.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>(SC.Armor.Source);
        }
        else Armor.SetActive(false);
        if (SC.Accessory.ID != 0)
        {
            Accessory.SetActive(true);
            Accessory.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>(SC.Accessory.Source);
        }
        else Accessory.SetActive(false);
        StatusContent.GetComponent<Text>().text = SC.hero.HP.ToString()
            + "/" + SC.hero.MAX_HP.ToString() + "\n"
            + SC.hero.ATK.ToString() + "(+" + (SC.hero.ATK - SC.hero.Base_ATK).ToString() + ")\n"
            + SC.hero.DEF.ToString() + "(+" + (SC.hero.DEF - SC.hero.Base_DEF).ToString() + ")\n"
            + SC.hero.SPD.ToString() + "(+" + (SC.hero.SPD - SC.hero.Base_SPD).ToString() + ")";
        GP.GetComponent<Text>().text = SC.Coin.ToString() + " GP";
        for (int i = 0; i < 10; i++)
        {

            ItemSlot[i].SetActive(SC.List[i] != null);
            if (ItemSlot[i].active) ItemSlot[i].GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>(SC.List[i].GetType().ToString());
        }
    }
    public void showHeroStatus()
    {
        if (SC.GetPart() == 0|| SC.GetPart() == -4)
        {
            SC.SetPart(-1);
            HeroStatus.SetActive(true);
            
            SetHeroStatus();
            
        }
        else
        {
            hideHeroStatus();
        }
    }

    public void hideHeroStatus()
    {
        SC.SetPart(0);
        HeroStatus.SetActive(false);
    }
    public void setMoves(int v)
    {
        M.setMoves(v);
    }
    public void showMoves()
    {
        Moves.SetActive(true);
    }
    public void hideMoves()
    {
        Moves.SetActive(false);
    }
    public void setName(string v)
    {
        SP.setName(v);
    }
    public void setStatus(string v)
    {
        SP.setStatus(v);
    }
    public void showStatusPanel(int type)
    {
        if(SC.GetPart() == 0 || type != 0)StatusPanel.SetActive(true);
    }
    public void hideStatusPanel()
    {
        StatusPanel.SetActive(false);
    }
}
