using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject road;
    public int laneID;
    public float startPos;
    public float distance;
    public GameObject[] objs;
    public GameObject[] pathsBelow;
    private float[] z = new float[4] { 6.85557f, 3.85557f, 0.8555696f, -2.144431f };
    void Start()
    {
        // width
        float width = (float)(objs.Length * 4 + 4) / 3;
        float moveright = (20 - width) / 2;
        startPos -= moveright;
        gameObject.transform.Find("Road").transform.localScale = new Vector3(0.1f, 0.1f, width);
        // position of the lane
        gameObject.transform.localPosition = new Vector3(moveright, 0, z[laneID]);
        // items on the lane
        for(int x = 0; x < objs.Length; x++)
        {
            if (!objs[x]) continue;
            GameObject obj = Instantiate(objs[x]);
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition = new Vector3(startPos + (x * distance), obj.transform.position.y, 0);
        }
        // paths below the lane
        for (int x = 0; x < pathsBelow.Length; x++)
        {
            if (x == objs.Length-1) break;
            //if (!objs[x]) Debug.LogError("you have to put in every 'path below' entry.");
            GameObject obj = Instantiate(pathsBelow[x]);
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition = new Vector3(-2.0f/3 + startPos + (x * distance), 0, -1.5f);

            obj.transform.localScale = new Vector3(0.1f/3, 0.1f, 0.2f);
            obj.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
