using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instans;

    private void Awake()
    {
        if (instans == null)
        {
            instans = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Debug.LogError("���Ӹ޴����� �� 2����");
            Destroy(this.gameObject);
        }

        LoadData();
    }

    [Header("Values")]
    public float    speed;
    public int      playerNum; // �� ����
    public int      bells;
    public int      score;
    public int[]    highScores; // �������� �� �ְ� ����
    public Vector3  startPos;
    public int      heartCount; // �÷��� ���� Ƚ��
    public bool     isRight; // ���������� �ΰ�?

    [Header("Check")]
    [SerializeField]
    private PlayerMove player;
    [SerializeField]
    private GameState state;

    [Header("Prefabs")]
    public GameObject[] players;
    public GameObject   bell_UI;
    public GameObject   bell;


    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Main":
                StateUpdate(GameState.Main);
                break;

            case "Game":
                StateUpdate(GameState.Start);
                break;

            default:
                Debug.Log("�˼����� ���� ����");
                StateUpdate(GameState.Error);
                break;
        }
    }

    private void Update()
    {
        switch (state)
        {
            case GameState.Main:
                player = null;
                return;

            case GameState.Start: // ObjectPool ���鶧 �ʿ�
                GameStart();
                return;

            case GameState.Standby:
                return;

            case GameState.Shop:
                return;

            case GameState.Running:
                return;

            case GameState.Over:
                GameOver();
                return;

            default:
                return;
        }
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("PlayerNum")) playerNum = PlayerPrefs.GetInt("PlayerNum");
        else playerNum = 0;

        if (PlayerPrefs.HasKey("HeartCount")) heartCount = PlayerPrefs.GetInt("HeartCount");
        else heartCount = 5;

        // ���̽��ھ� �������� ���� �޾ƿ�

        if (PlayerPrefs.HasKey("IsRight"))
        {
            switch (PlayerPrefs.GetInt("IsRight"))
            {
                case 0: isRight = false; break;
                case 1: isRight = true; break;
                default: isRight = true; break;
            }
        }
        else isRight = true;


    }

    public void GameSave()
    {
        PlayerPrefs.SetInt("PlayerNum", playerNum);

        PlayerPrefs.SetInt("HeartCount", heartCount);

        // ���̽��ھ� �������� ���� ������

        if (isRight) PlayerPrefs.SetInt("IsRight", 1);
        else PlayerPrefs.SetInt("IsRight", 0);

    }

    private void GameStart()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            bell_UI = GameObject.Find("Bells");
            player = Instantiate(players[playerNum], startPos, Quaternion.identity).GetComponent<PlayerMove>();
            GameManager.instans.StateUpdate(GameState.Running);
        }

        else
        {
            return;
        }
    }

    private void GameOver()
    {
        player = null;
    }

    public void StateUpdate(GameState _state)
    {
        state = _state;
    }

    public GameState StateGet()
    {
        return state;
    }

    public PlayerMove GetPlayerMove()
    {
        return player;
    }

}
