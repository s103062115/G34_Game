using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hcamera : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(2, 1, 0);
    }
}
