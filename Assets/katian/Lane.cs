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
    private float[] z = new float[4] { 6.85557f, 3.85557f, 0.8555696f, -2.144431f };
    void Start()
    {
        // position of the lane
        gameObject.transform.localPosition = new Vector3(0, 0, z[laneID]);
        // items on the lane
        for(int x = 0; x < objs.Length; x++)
        {
            if (!objs[x]) continue;
            GameObject obj = Instantiate(objs[x]);
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition = new Vector3(startPos + (x * distance), obj.transform.position.y, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
