using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    // Start is called before the first frame update
    SystemController SC;
    MessageController MC;
    float[,] roadPos;
    void Start()
    {
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        MC = GameObject.Find("MessageController").GetComponent<MessageController>();
        //roadPos = new float[SC.iniMoves,2];
    }
    /*
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
            for(int i = 0; i < SC.iniMoves - SC.rest; i++)
            {
                if(roadPos[i,0] - posX < 0.5 && roadPos[i,0] - posX > -0.5)
                {
                    if(roadPos[i,1] - posZ < 4 && roadPos[i,1] - posZ > -4){
                        MC.newMessage("與其他道路靠太近！");
                        return;
                    }
                }
            }
            if(SC.makeRoad(posX, posZ))
            {
                roadPos[SC.iniMoves - SC.rest-1,0] = posX;
                roadPos[SC.iniMoves - SC.rest-1,1] = posZ;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
