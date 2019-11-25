using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject StatusPanel, Moves;
    SetInfo SP, M;
    void Start()
    {
        Transform t = gameObject.GetComponent<Transform>();
        StatusPanel = GameObject.Find("StatusPanel");
        if (!StatusPanel)
        {
            StatusPanel = Instantiate(Resources.Load("StatusPanel") as GameObject);
            StatusPanel.transform.SetParent(t, false);
            StatusPanel.transform.localPosition = new Vector2(520, 0);
        }
        Moves = GameObject.Find("Moves");
        if (!Moves)
        {
            Moves = Instantiate(Resources.Load("Moves") as GameObject);
            Moves.transform.SetParent(t, false);
            Moves.transform.localPosition = new Vector2(568, 303);

        }
        SP = StatusPanel.GetComponent<SetInfo>();
        M = Moves.GetComponent<SetInfo>();
        hideMoves();
        hideStatusPanel();
    }

    public void setMoves(int v)
    {
        M.setMoves(v);
    }
    public void showMoves()
    {
        Moves.SetActive(true);
    }
    public void hideMoves()
    {
        Moves.SetActive(false);
    }
    public void setName(string v)
    {
        SP.setName(v);
    }
    public void setStatus(string v)
    {
        SP.setStatus(v);
    }
    public void showStatusPanel()
    {
        StatusPanel.SetActive(true);
    }
    public void hideStatusPanel()
    {
        StatusPanel.SetActive(false);
    }
}
