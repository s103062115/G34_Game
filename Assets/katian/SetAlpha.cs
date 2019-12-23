using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlpha : MonoBehaviour
{
    SystemController SC;
    private bool valid = false;
    private float x;
    private float y;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseUpAsButton()
    {
        if(!valid)
            valid = SC.makeRoad(x, z);
        if (valid) Destroy(gameObject);
    }
    public void OnMouseEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }
    public void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }
    public void appear()
    {
        gameObject.transform.position = new Vector3(x, y, z);
    }
    public void disappear()
    {
        gameObject.transform.position = new Vector3(x, -100.0f, z);
    }
}
