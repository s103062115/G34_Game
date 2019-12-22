using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SystemController : MonoBehaviour
{
    // Start is called before the first frame update
    public Item[] List;
    int ItemNumber;
    public Hero hero;
    public int Coin;
    public Object obj;
    public int iniMoves;
    public int rest;
    public GameObject mainc;
    public GameObject gamec;
    public GameObject battlec;
    public GameObject BattlePositionP;
    public GameObject BattlePositionM;
    public Equipment Weapon, Armor, Shoes, Accessory;
    public GameObject stage;
    public GameObject nextStage;
    public bool heroTurnBegin, heroTurnEnd;
    public bool monsTurnBegin, monsTurnEnd;
    public MessageController MC;
    public int standbyItem;
    int stageN;
    Vector3 pp;
    Quaternion pr;
    Monster mons;
    public UI UI;
    bool done;
    public int part;
    void Start()
    {

        List = new Item[11];
        rest = iniMoves = 3;
        part = 0;
        //UI = GameObject.Find("Canvas").GetComponent<UI>();
        //UI.setMoves(iniMoves);
        stageN = 1;
        nextStage = GameObject.Find("Stage" + (stageN+1));

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        ReStatus();
        if(part == 2)
        {
            if (heroTurnEnd)
            {
                if (!monsTurnBegin)
                {
                    monsTurnBegin = true;
                    mons.turn();
                }
                else if (monsTurnEnd) oneTurn();

            }else if (monsTurnEnd)
            {
                if (!heroTurnBegin)
                {
                    heroTurnBegin = true;
                    hero.turn();
                }
            }
        }else if(part == -2)
        {
            MC.newMessage("請選擇對象");
            UI.hideHeroStatus();
            part = -3;
        }else if(part == -4)
        {
            //part = 0;
            List[standbyItem] = null;
            part = 0;
            UI.hideStatusPanel();
            //UI.showHeroStatus();
            //part = -3;
        }
    }
    public void Versus(Monster monster)
    {
        mons = monster;
        Invoke("startbattle", 0.5f);

    }
    void startbattle()
    {
        MC.newMessage(mons.Name+"出現了");
        part = 2;
        done = false;
        gamec.SetActive(false);
        battlec.SetActive(true);
        pp = hero.gameObject.transform.position;
        pr = hero.gameObject.transform.rotation;
        hero.gameObject.transform.position = BattlePositionP.transform.position;
        //mons.gameObject.transform.rotation = BattlePositionM.transform.rotation;
        mons.gameObject.transform.position = BattlePositionM.transform.position;
        hero.enemy = mons;
        mons.enemy = hero;
        oneTurn();
    }

    void oneTurn()
    {
        monsTurnBegin = false;
        monsTurnEnd = false;
        heroTurnBegin = false;
        heroTurnEnd = false;
        if (hero.SPD >= mons.SPD)
        {
            heroTurnBegin = true;
            hero.turn();
        }
        else
        {
            monsTurnBegin = true;
            mons.turn();
        }
    }


    public void battleend(bool playerwin)
    {
        part = 3;
        heroTurnEnd = false;
        monsTurnEnd = false;
        heroTurnBegin = false;
        monsTurnBegin = false;
        if (playerwin)
        {
            if (mons.Coin > 0) MC.newMessage("獲得了" + mons.Coin + "GP");
            //if (mons.Drop != null) MC.newMessage(hero.Name + "獲得" + mons);
            part = 1;
            battlec.SetActive(false);
            hero.gameObject.transform.position = pp;
            hero.gameObject.transform.rotation = pr;
            gamec.SetActive(true);
            hero.Resume();
            mons.Die();
        }
        else
        {

        }
    }
    public void UseItem(int Num)
    {
        if (List[Num] != null)
        {

            ItemNumber--;
            UI.hideStatusPanel();
            UI.SetHeroStatus();
            standbyItem = Num;
            List[Num].Use(hero);
            //Destroy(List[Num]);
            //List[Num] = null;
            /*for (int i = Num; i < 10; i++)
            {
                List[i] = List[i + 1];
            }*/
        }
    }

    public void AddItem(int ID)
    {
        Item newItem;
        if (ItemNumber == 10) MC.newMessage("道具已滿");//滿
        else if (ItemNumber < 10)
        {
            if (ID == 1)
            {
                MC.newMessage("獲得道具：史萊姆的黏液");
                if (!gameObject.GetComponent<Mucus>()) newItem = gameObject.AddComponent<Mucus>();
                else newItem = gameObject.GetComponent<Mucus>();
            }
            else newItem = null;
            if (newItem != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (List[i] == null)
                    {
                        List[i] = newItem;
                        break;
                    }
                    ItemNumber++;
                }
            }
        }
    }
    
    public void PickEquipment(Equipment equipment)
    {
        Unequip(equipment.Type);
        /*if (equipment.ID == 1) Weapon = gameObject.AddComponent<Sword>();
        else if (equipment.ID == 2) Weapon = gameObject.AddComponent<IronSword>();*/
        //gameObject.AddComponent(equipment.GetType());
        if(equipment.Type == 1)
        {
            MC.newMessage("獲得武器："+equipment.Name);
            Weapon.Copy(equipment);
        }else if (equipment.Type == 2)
        {
            MC.newMessage("獲得防具：" + equipment.Name);
            Armor.Copy(equipment);
        }else if (equipment.Type == 3)
        {
            MC.newMessage("獲得鞋子：" + equipment.Name);
            Shoes.Copy(equipment);
        }else if (equipment.Type == 4)
        {
            MC.newMessage("獲得飾品：" + equipment.Name);
            Accessory.Copy(equipment);
        }
        if (equipment.HP > 0) hero.HP += equipment.HP;
        /*if (equipment.Type == 1)
        {
            hero.anim.SetBool("walk", false);
            hero.anim.SetBool("picksword", true);
        }*/

        //ReStatus();
        Destroy(equipment.gameObject);
    }
    public bool makeRoad(float posX, float posZ)
    {
        
        
        // Cubeプレハブを元に、インスタンスを生成、
        if (rest > 0 && part == 0)
        {
            Instantiate(obj, new Vector3(posX, 1.1f, posZ), Quaternion.identity);
            rest--;
            UI.setMoves(rest);
            return true;
        }
        return false;
    }
    
    public void gameStart()
    {
        part = 1;
        UI.gameObject.SetActive(false);
        hero.transform.position = hero.transform.position - new Vector3(0.5f, 0, 0);
        hero.anim.SetBool("walk", true);
        mainc.SetActive(false);
        gamec.SetActive(true);
    }
    public void SetPart(int a)
    {
        part = a;
    }
    public int GetPart()
    {
        return part;
    }
    public void ReStatus()
    {
        
        hero.MAX_HP = hero.Base_HP + Weapon.HP + Armor.HP + Shoes.HP + Accessory.HP;
        hero.ATK = hero.Base_ATK + Weapon.ATK + Armor.ATK + Shoes.ATK + Accessory.ATK;
        hero.DEF = hero.Base_DEF + Weapon.DEF + Armor.DEF + Shoes.DEF + Accessory.DEF;
        hero.SPD = hero.Base_SPD + Weapon.SPD + Armor.SPD + Shoes.SPD + Accessory.SPD;
        hero.MAT = hero.Base_MAT + Weapon.MAT + Armor.MAT + Shoes.MAT + Accessory.MAT;
        hero.MDF = hero.Base_MDF + Weapon.MDF + Armor.MDF + Shoes.MDF + Accessory.MDF;
        hero.MAX_MP = hero.Base_MP + Weapon.MP + Armor.MP + Shoes.MP + Accessory.MP;
        if (hero.HP > hero.MAX_HP) hero.HP = hero.MAX_HP;
        if (hero.MP > hero.MAX_MP) hero.MP = hero.MAX_MP;
    }
    public void Unequip(int Type)
    {

        if (Type == 1)
        {
            if (Weapon.ID != 0)
            {
                Weapon.ALLzero();
            }
        }
        else if (Type == 2)
        {
            if (Armor.ID != 0)
            {
                Armor.ALLzero();
            }
        }
        else if (Type == 3)
        {
            if (Shoes.ID != 0)
            {
                Shoes.ALLzero();
            }
        }
        else if (Type == 4)
        {
            if (Accessory.ID != 0)
            {
                Accessory.ALLzero();
            }
        }

        //ReStatus();
    }
    public void gotoNext()
    {
        stageN++;


        hero.gotoNext();
        Vector3 offset = (nextStage.transform.position - stage.transform.position);

        //hero.transform.position = new Vector3 (nextStage.transform.FindChild("StartLine").position.x,hero.transform.position.y,hero.transform.position.z);
        mainc.transform.position += offset;
        stage = nextStage;
        gamec.SetActive(false);
        mainc.SetActive(true);
        
        nextStage = nextStage = GameObject.Find("Stage" + (stageN + 1));
    }
    public void gameover()
    {
        MC.transform.Find("Retry").gameObject.SetActive(true);
        MC.transform.Find("BackToMenu").gameObject.SetActive(true);

    }
    public void retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void backToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void gameclear()
    {
        MC.clearM.SetActive(true);
        MC.transform.Find("BackToMenu").gameObject.SetActive(true);
    }
}
