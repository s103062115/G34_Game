using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInfo : MonoBehaviour
{
    public GameObject nameObj, statusObj, countObj;
    private void Start()
    {
        
    }
    public void setName(string name)
    {
        nameObj.GetComponent<Text>().text = name;
    }
    public void setStatus(string status)
    {
        statusObj.GetComponent<Text>().text = status;
    }
    public void setMoves(int moves)
    {
        countObj.GetComponent<Text>().text = moves.ToString();
    }
}