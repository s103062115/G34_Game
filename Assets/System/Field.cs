using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    // Start is called before the first frame update
    SystemController SC;
    void Start()
    {
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
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
            //if (posX > 6 || posX < -9) good = false;
            if (rayHit.point.z > 0 && rayHit.point.z < 3) posZ = 1.5f;
            else if (rayHit.point.z < 0 && rayHit.point.z > -3) posZ = -1.5f;
            else if (rayHit.point.z < -3 && rayHit.point.z > -6) posZ = -4.5f;
            else good = false;

        }
        // Cubeプレハブを元に、インスタンスを生成、
        if (good)
        {
            SC.makeRoad(posX, posZ);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
