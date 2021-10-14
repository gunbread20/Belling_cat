using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Pannels")]
    [SerializeField]
    GameObject menuPannel;

    [Header("ETC")]
    [SerializeField]
    GameObject menuCount;

    private PlayerMove player;

    public void BtnAction(GameObject b)
    {
        if (player == null) player = GameManager.instans.GetPlayerMove();

        // 게임상태가 Running 일때만 점프랑 슬라이드 해야함
        switch (b.name)
        {

            case "Menu":
                Debug.Log(b.name);
                GameManager.instans.StateUpdate(GameState.Standby);
                menuPannel.SetActive(true);
                return;

            case "Menu_Close":
                menuPannel.SetActive(false);
                StartCoroutine(Count());
                return;

            case "To_Menu":
                GameManager.instans.StateUpdate(GameState.Main);
                SceneManager.LoadScene("Main");
                return;

            case "Jump":
                if (GameManager.instans.StateGet() != GameState.Running) return;
                Debug.Log(b.name);
                player.JumpBtn();
                return;

            case "Slide":
                if (GameManager.instans.StateGet() != GameState.Running) return;
                Debug.Log(b.name);
                return;

            default:
                Debug.LogError("지정되지 않은 버튼: " + b.name);
                return;
        }
    }

    IEnumerator Count()
    {
        menuCount.SetActive(true);
        Text countText = menuCount.GetComponent<Text>();
        float time = 3;

        while (time > 0)
        {
            time -= Time.deltaTime;
            countText.text = time.ToString("F0");
            yield return null;
        }

        menuCount.SetActive(false);
        EndMenu();
    }

    private void EndMenu()
    {
        GameManager.instans.StateUpdate(GameState.Running);
        player.EndMenu();
    }
}
