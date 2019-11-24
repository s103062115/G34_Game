using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setInfo : MonoBehaviour
{
    public GameObject nameObj, statusObj;
    // Start is called before the first frame update
    void Start()
    {
        if (!nameObj) Debug.LogError("Please add name object to StatusPanel.");
        if (!statusObj) Debug.LogError("Please add status object to StatusPanel.");
    }

    public void setName(string name)
    {
        nameObj.GetComponent<Text>().text = name;
    }
    public void setStatus(string status)
    {
        statusObj.GetComponent<Text>().text = status;
    }
}
