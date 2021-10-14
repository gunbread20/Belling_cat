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
            //Debug.LogError("게임메니저가 왜 2개냐");
            Destroy(this.gameObject);
        }
    }

    [Header("Values")]
    public float    speed;
    public int      playerNum;
    public int      bells;
    public int      score;

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
                Debug.Log("알수없는 씬에 진입");
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

            case GameState.Init: // ObjectPool 만들때 필요
                return;

            case GameState.Start:
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

    private void GameStart()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            player = Instantiate(players[playerNum]).GetComponent<PlayerMove>();
            StateUpdate(GameState.Running);
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
