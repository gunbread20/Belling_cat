using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPannel;
    PlayerMove player;

    private void Start()
    {
        player = GameManager.instans.GetPlayerMove();
    }

    public void BtnAction(GameObject b)
    {
        switch (b.name)
        {
            case "Menu":
                Debug.Log(b.name);
                menuPannel.SetActive(true);

                return;
            case "Menu_Close":
                menuPannel.SetActive(false);

                return;
            case "Jump":
                Debug.Log(b.name);
                player.JumpBtn();

                return;
            case "Slide":
                Debug.Log(b.name);


                return;
            default:
                return;
        }
    }
}
