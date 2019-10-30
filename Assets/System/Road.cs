using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Hero>())
            other.transform.localPosition += transform.TransformDirection(0, 0, dir);
    }
    
}
