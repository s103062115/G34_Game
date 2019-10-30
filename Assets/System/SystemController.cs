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
    public int rest;
    public GameObject mainc;
    public GameObject gamec;
    void Start()
    {
        List = new Item[11];
        rest = 3;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void Versus(Monster monster)
    {
        for (int i = 0; hero.HP > 0 && monster.HP > 0; i++)
        {
            if (hero.SPD > monster.SPD)
            {
                monster.GetDamage(hero.Attack());
                if (monster.HP <= 0) break;
                hero.GetDamage(monster.Attack());
            }
            else
            {
                hero.GetDamage(monster.Attack());
                if (hero.HP <= 0) break;
                monster.GetDamage(hero.Attack());
            }

        }
        if (monster.HP <= 0)
        {
            //hero.GetItem(monster.Drop);
            AddItem(monster.Drop);
            Coin += monster.Coin;
            monster.Die();
        }
        else hero.Die();
    }

    public void UseItem(int Num)
    {
        if (Num < ItemNumber)
        {
            List[Num].Use(hero);
            Destroy(List[Num]);
            ItemNumber--;
            
            for (int i = Num; i < 10; i++)
            {
                List[i] = List[i + 1];
            }
        }
    }

    public void AddItem(int ID)
    {
        if (ItemNumber == 10) ;//滿
        else if (ID == 1)
        {
            List[ItemNumber] = this.gameObject.AddComponent<Mucus>();
        }
        if (ItemNumber < 10) ItemNumber++;
    }
    
    public void PickEquipment(Equipment equipment)
    {
        hero.Unequip(equipment.Type);
        if (equipment.ID == 1) hero.Weapon = hero.gameObject.AddComponent<Sword>();
        else if (equipment.ID == 2) hero.Weapon = hero.gameObject.AddComponent<IronSword>();

        //hero.ReStatus();
        Destroy(equipment.gameObject);
    }
    private void OnMouseUpAsButton()
    {
        
        Ray mouseRay1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        float posX = 0.0f;
        float posZ = 0.0f;
        RaycastHit rayHit;
        bool good = true;
        if (Physics.Raycast(mouseRay1, out rayHit, 1000f))

        {

            //儲存滑鼠所點擊的座標

            posX = rayHit.point.x;
            if (posX > 6 || posX < -9) good = false;
            if (rayHit.point.z > 0 && rayHit.point.z < 3) posZ = 1.5f;
            else if (rayHit.point.z < 0 && rayHit.point.z > -3) posZ = -1.5f;
            else if (rayHit.point.z < -3 && rayHit.point.z > -6) posZ = -4.5f;
            else good = false;
            
        }
        // Cubeプレハブを元に、インスタンスを生成、
        if (good && rest > 0)
        {
            Instantiate(obj, new Vector3(posX, 1.1f, posZ), Quaternion.identity);
            rest--;
        }
    }
    private void OnGUI()
    {
        /*GUI.Box(new Rect(Screen.width - 260, 10, 250, 150), "Interaction");
        GUI.Label(new Rect(Screen.width - 245, 30, 250, 30), "Up/Down Arrow : Go Forwald/Go Back");
        GUI.Label(new Rect(Screen.width - 245, 50, 250, 30), "Left/Right Arrow : Turn Left/Turn Right");
        GUI.Label(new Rect(Screen.width - 245, 70, 250, 30), "Hit Space key while Running : Jump");
        GUI.Label(new Rect(Screen.width - 245, 90, 250, 30), "Hit Spase key while Stopping : Rest");
        GUI.Label(new Rect(Screen.width - 245, 110, 250, 30), "Left Control : Front Camera");
        GUI.Label(new Rect(Screen.width - 245, 130, 250, 30), "Alt : LookAt Camera");*/

        //GUI.Box(new Rect(Screen.width - 110, 10, 100, 90), "Change Motion");
        



        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 40, 80, 20), "Start"))
        {
            //hero.gameObject.GetComponent<Collider>().enabled = true;
            hero.transform.position = hero.transform.position - new Vector3(0.5f, 0, 0);
            mainc.SetActive(false);
            gamec.SetActive(true);
        }
        GUI.skin.box.fontSize = 72;
        GUI.Box(new Rect(Screen.width - 110, 10, 100, 90), rest.ToString());
    }
}
