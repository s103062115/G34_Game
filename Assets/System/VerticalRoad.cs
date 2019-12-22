using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRoad : Road
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ready) count++;
        if (count == 6)
        {
            ready = false;
            count = 0;
            h.Pause();
            if (Vector3.Dot(h.gameObject.transform.localPosition - transform.localPosition, transform.TransformDirection(0, 0, 1)) > 0)
            {
                h.dir = 3;
            }
            else
            {
                h.dir = 1;
            }
            h.Resume();
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            h = other.gameObject.GetComponent<Hero>();
            if (h.dir == 0)
            {
                ready = true;
                if (Vector3.Dot(other.transform.localPosition - transform.localPosition, transform.TransformDirection(0, 0, 1)) > 0)
                {
                    dir = -0.03f;
                }
                else dir = 0.03f;
            }
        }
    }

    public override void OnTriggerStay(Collider other)
    {
        if (!ready && other.tag == "Player")
        {
            if (dir < 0 && other.transform.position.z - transform.position.z > -1.5)
            {
                if (h = other.gameObject.GetComponent<Hero>())
                {
                    if (!h.dontwalk()) other.transform.localPosition += transform.TransformDirection(0, 0, dir);
                }
            }
            else if (dir > 0 && other.transform.position.z - transform.position.z < 1.5)
            {
                if (h = other.gameObject.GetComponent<Hero>())
                {
                    if (!h.dontwalk()) other.transform.localPosition += transform.TransformDirection(0, 0, dir);
                }
            }
        }
    }
}
