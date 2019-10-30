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
    private void OnTriggerEnter(Collider other)
    {
        if (Vector3.Dot(other.transform.localPosition - transform.localPosition, transform.TransformDirection(0, 0, 1)) > 0)
        {
            dir = -0.1f;
        }
    }

    public override void OnTriggerStay(Collider other)
    {
        if (dir < 0 && other.transform.position.z - transform.position.z > -1.5)
        {
            if (other.gameObject.GetComponent<Hero>())
                other.transform.localPosition += transform.TransformDirection(0, 0, dir);
        }else if (dir > 0 && other.transform.position.z - transform.position.z < 1.5)
        {
            if (other.gameObject.GetComponent<Hero>())
                other.transform.localPosition += transform.TransformDirection(0, 0, dir);
        }
    }
}
