using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.LogError("게임메니저가 왜 2개냐");
            Destroy(this.gameObject);
        }
    }

    public float speed;
    public int playerNum;
    private PlayerMove player;

    [SerializeField]
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(players[playerNum]).GetComponent<PlayerMove>();
    }

    public PlayerMove GetPlayerMove()
    {
        return player;
    }

}
