using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    SystemController SC;
    // Start is called before the first frame update
    void Start()
    {
        SC = GameObject.Find("SystemController").GetComponent<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Hero>())
        {
            SC.gotoNext();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Hero>())
        {

            other.gameObject.GetComponent<Hero>().Pause();
            SC.UI.gameObject.SetActive(true);
            //SC.rest = SC.iniMoves;
            //SC.UI.setMoves(SC.iniMoves);
            SC.SetPart(0);
            SC.nextStageReady();
            GameObject[] stars = GameObject.FindGameObjectsWithTag("star");
            foreach (GameObject star in stars)
            {
                Star s = star.GetComponent<Star>();
                s.lie();
            }
            GameObject[] objs = GameObject.FindGameObjectsWithTag("disappearOnMove");
            foreach (GameObject obj in objs)
            {
                SetAlpha s = obj.GetComponent<SetAlpha>();
                s.appear();
            }
        }
    }
}
