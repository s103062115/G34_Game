using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureViewer : MonoBehaviour
{
    // Start is called before the first frame update
    int[] detail;
    string[] s;
    string[] type;
    int t;
    int[] display_list;
    int j;
    void Start()
    {
        display_list = new int[7];
        detail = new int[7];
        s = new string[8];
        type = new string[5];
        type[1] = " (武器)";
        type[2] = " (防具)";
        type[3] = " (鞋子)";
        type[4] = " (飾品)";
        s[0] = "HP  : +";
        s[1] = "MP  : +";
        s[2] = "ATK : +";
        s[3] = "DEF : +";
        s[4] = "MAT : +";
        s[5] = "MDF : +";
        s[6] = "SPD : +";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        int offset = Screen.height / 2 - 50;
        GUI.Box(new Rect(Screen.width - 260, 20 + offset, 210, 170), "");
        GUI.Label(new Rect(Screen.width - 245, 30 + offset, 210, 30), s[7]+type[t]);
        for(int i = 0; i < j; i++)
        {
            GUI.Label(new Rect(Screen.width - 245, 50 + offset + i*20,210, 30), s[display_list[i]] + detail[display_list[i]].ToString());
        }

    }

    public void LoadData(Equipment e)
    {
        s[7] = e.Name;
        t = e.Type;
        detail[0] = e.HP;
        detail[1] = e.MP;
        detail[2] = e.ATK;
        detail[3] = e.DEF;
        detail[4] = e.MAT;
        detail[5] = e.MDF;
        detail[6] = e.SPD;
        j = 0;
        for(int i = 0;i < 7; i++)
        {
            
            if(detail[i] > 0)
            {
                display_list[j] = i;
                j++;
            }
        }
    }
    
}
