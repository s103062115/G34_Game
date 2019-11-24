using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusViewer : MonoBehaviour
{
    int[] detail;
    int woffset, hoffset;
    string mname;
    // Start is called before the first frame update
    void Start()
    {
        detail = new int[6];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnGUI()
    {
        int offset = Screen.height / 2 - 50;
        GUI.Box(new Rect(Screen.width - 260, 20 + offset, 250, 170), "");
        GUI.Label(new Rect(Screen.width - 245, 30 + offset, 250, 30),   mname);
        GUI.Label(new Rect(Screen.width - 245, 50 + offset, 250, 30), "HP  : " + detail[0].ToString());
        GUI.Label(new Rect(Screen.width - 245, 70 + offset, 250, 30), "ATK : " + detail[1].ToString());
        GUI.Label(new Rect(Screen.width - 245, 90 + offset, 250, 30), "DEF : " + detail[2].ToString());
        GUI.Label(new Rect(Screen.width - 245, 110 + offset, 250, 30), "MAT : " + detail[3].ToString());
        GUI.Label(new Rect(Screen.width - 245, 130 + offset, 250, 30), "MDF : " + detail[4].ToString());
        GUI.Label(new Rect(Screen.width - 245, 150 + offset, 250, 30), "SPD : " + detail[5].ToString());

    }
    public void LoadData(Monster m)
    {
        detail[0] = m.HP;
        detail[1] = m.ATK;
        detail[2] = m.DEF;
        detail[3] = m.MAT;
        detail[4] = m.MDF;
        detail[5] = m.SPD;
        mname = m.Name;
    }
}
