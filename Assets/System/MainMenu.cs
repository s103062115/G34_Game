using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    MessageController MC;
    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("Canvas").GetComponent<MessageController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectStage(int s)
    {
        if (s == 1) UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        else MC.newMessage("尚未開放!");
    }
}
