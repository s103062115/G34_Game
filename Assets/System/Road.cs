using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float dir;
    public bool ready;
    public int count;
    public Hero h;
    // Start is called before the first frame update
    void Start()
    {
        dir = 0.05f;
        ready = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ready) count++;
        if(count == 15)
        {
            ready = false;
            count = 0;
            h.anim.SetBool("walk", true);
            h.anim.SetBool("walkL", false);
            h.anim.SetBool("walkR", false);
            h.dir = 0;
            
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        
        if ((h = other.gameObject.GetComponent<Hero>()) && !ready)
        {
            if(!h.dontwalk() && h.dir == 0)other.transform.localPosition += transform.TransformDirection(0, 0, dir);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (h = other.gameObject.GetComponent<Hero>())
        {
            if(h.dir != 0) ready = true;
            
        }
    }

}
