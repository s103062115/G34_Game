using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text[] messages;
    Color alpha = new Color(0, 0, 0, 0.005f);
    
    void Start()
    {
        messages = new Text[3];
        messages[0] = transform.FindChild("Message1").gameObject.GetComponent<Text>();
        messages[1] = transform.FindChild("Message2").gameObject.GetComponent<Text>();
        messages[2] = transform.FindChild("Message3").gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        messages[0].color -= alpha;
        messages[1].color -= alpha;
        messages[2].color -= alpha;
    }
    public void newMessage(string m)
    {
        messages[2].text = messages[1].text;
        messages[2].color = messages[1].color;
        messages[1].text = messages[0].text;
        messages[1].color = messages[0].color;
        messages[0].text = m;
        messages[0].color = Color.white;
    }
}
