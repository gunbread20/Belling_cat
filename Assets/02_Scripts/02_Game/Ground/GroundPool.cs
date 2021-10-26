using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPool : MonoBehaviour
{
    // Start상태에 땅 5개 생성 비 활성화 상태
    // 그 중 3개를 게임에 생성
    // 
    [Header("Prefab")]
    [SerializeField]
    GameObject ground;
    [SerializeField]
    GameObject[] obstacles;

    [Header("Values")]
    [SerializeField]
    float speed;
    [SerializeField]
    int obstacleCount;
    [SerializeField]
    int[] obstaclePoolCount;

    List<GameObject> groundPool;
    List<GameObject> groundSpawn;
    List<Obstacle> obstaclePool; // 만들예정

    GameState state;


    private void Start()
    {
        groundPool  = new List<GameObject>();
        groundSpawn = new List<GameObject>();
        obstaclePool = new List<Obstacle>();
    }

    void CreateGround()
    {
        GameObject g = Instantiate(ground, transform);
        g.SetActive(false);
        groundPool.Add(g);
    }

    void CreateObstacle(int num)
    {
        GameObject o = Instantiate(obstacles[num], transform);
        o.SetActive(false);
        obstaclePool.Add(o.GetComponent<Obstacle>());
    }

    void ListUp()
    {
        for (int i = 0; i < obstacles.Length + 1; i++)
        {
            switch (i)
            {
                case 0:
                    for (int a = 0; a < 5; a++) CreateGround();
                    break;
                default:
                    CreateObstacle(i);
                    break;
            }
        }
    }

    void StartSpawnGround()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject g = groundPool[0];
            groundPool.RemoveAt(0);
            groundSpawn.Add(g);
            g.transform.parent = transform;
            if (groundSpawn.Count == 1) g.transform.position = new Vector2(-31, -3);
            else if (groundSpawn.Count == 2) g.transform.position = new Vector2(0, -3);
            else g.transform.position = new Vector2(31, -3);
        }
    }


    public void ReturnGround()
    {
        GameObject g = groundSpawn[0];
        groundSpawn.RemoveAt(0);
        groundPool.Add(g);
        g.transform.parent = null;
        g.SetActive(false);
        SpawnGround();
    }

    void SpawnGround()
    {
        GameObject g = groundPool[0];
        groundPool.RemoveAt(0);
        groundSpawn.Add(g);
        g.transform.parent = transform;
        g.transform.position = new Vector2(31, -3);
    }

    private void Update()
    {
        speed = GameManager.instans.speed;
        state = GameManager.instans.StateGet();

        switch (state)
        {
            case GameState.Main:
                Destroy(this.gameObject);
                break;

            case GameState.Start:
                ListUp();
                StartSpawnGround();
                break;
            case GameState.Standby:
                break;
            case GameState.Running:
                break;
            case GameState.Over:
                break;
            default:
                break;
        }
    }
}
