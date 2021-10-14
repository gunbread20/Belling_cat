using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject CharacterPanel;
    [SerializeField]
    GameObject OptionPannel;


    public void BtnAction(GameObject b)
    {
        switch (b.name)
        {
            case "Start":
                SceneManager.LoadScene("Game");
                GameManager.instans.StateUpdate(GameState.Start);
                break;

            case "Character":
                CharacterPanel.SetActive(true);
                break;

            case "Character_close":
                CharacterPanel.SetActive(false);
                break;

            case "Option":
                OptionPannel.SetActive(true);
                break;

            case "Option_close":
                OptionPannel.SetActive(false);
                break;

            case "Exit":
                Debug.Log("게임 종료");
                Application.Quit();
                break;

            default:
                break;
        }
    }
}
