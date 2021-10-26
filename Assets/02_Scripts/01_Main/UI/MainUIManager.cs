using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    [Header("Pannels")]
    [SerializeField]
    GameObject      OptionPannel;
    [SerializeField]
    GameObject      DayMissionPannel;

    [Header("Units")]
    [SerializeField]
    GameObject[]    playerIcons;
    [SerializeField]
    GameObject      Next;
    [SerializeField]
    GameObject      Before;
    [SerializeField]
    GameObject      heartGroup;

    [Header("Prefabs")]
    [SerializeField]
    GameObject      heart;

    [Header("Value")]
    [SerializeField]
    private int     playerNum;
    [SerializeField]
    private int     heartCount;

    private void Start()
    {
        playerNum = GameManager.instans.playerNum;
        heartCount = GameManager.instans.heartCount;

        for (int i = 0; i < heartCount; i++)
        {
            Instantiate(heart, heartGroup.transform);
        }

        if (playerNum > 0) Before.SetActive(true);
        else Before.SetActive(false);

        if (playerNum >= playerIcons.Length) Next.SetActive(false);
        else Next.SetActive(true);

        UpdateIcon();
    }

    public void BtnAction(GameObject b)
    {
        switch (b.name)
        {
                // ���� ��ư
            case "Start":
                SceneManager.LoadScene("Game");
                GameManager.instans.StateUpdate(GameState.Start);
                break;

                // ĳ���� ���� ���� ��ư
            case "Next":
                playerNum++;
                UpdateIcon();
                if (playerNum > 0) Before.SetActive(true);
                if (playerNum >= (int)playerIcons.Length - 1) Next.SetActive(false);
                break;

            case "Before":
                playerNum--;
                UpdateIcon();
                if (playerNum <= 0) Before.SetActive(false);
                if (playerNum < (int)playerIcons.Length - 1) Next.SetActive(true);
                break;

            case "Character":
                GameManager.instans.playerNum = playerNum;
                break;

                // �ɼ� ���� ��ư
            case "Option":
                OptionPannel.SetActive(true);
                break;

            case "Option_close":
                OptionPannel.SetActive(false);
                break;

                // ���Ϲ̼� ���� ��ư
            case "DayMissionBtn":
                DayMissionPannel.SetActive(true);
                break;

            case "Day_close":
                DayMissionPannel.SetActive(false);
                break;

                // �����ڽ� ���� ��ư
            case "RandomBox":
                break;

            case "":
                break;

                // ������
            case "Exit":
                Debug.Log("���� ����");
                GameManager.instans.GameSave();
                Application.Quit();
                break;

            default:
                break;
        }
    }

    void UpdateIcon()
    {
        foreach  (GameObject icon in playerIcons)
        {
            icon.SetActive(false);
        }

        playerIcons[playerNum].SetActive(true);
    }
}
