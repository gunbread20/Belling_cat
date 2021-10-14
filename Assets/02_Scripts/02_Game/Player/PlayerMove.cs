using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Mouse Info")]
    public int      MouseNum;   // 쥐의 고유 번호
    public int      jumpCount;  // 총 점프가능 횟수 
    public float    jumpHeight; // 점프 높이
    public float    weight;     // Gravity Scale

    Transform originTr, nowTr;
    Vector3 targetPos;
    Rigidbody2D myRg;

    [Header("Check")]
    [SerializeField]
    int nowCount;
    [SerializeField]
    GameState gState;

    void Start()
    {
        originTr = transform;
        transform.position = new Vector2(0, -4);
        nowCount    = 0;
        nowTr = originTr;
        myRg = GetComponent<Rigidbody2D>();
        myRg.gravityScale = weight;
    }

    private void Update()
    {
        gState = GameManager.instans.StateGet();

        switch (gState)
        {
            case GameState.Standby:
                myRg.constraints = RigidbodyConstraints2D.FreezePositionY;
                break;

            case GameState.Running:
                myRg.constraints = 0;
                break;

            case GameState.Over:
                // 임시
                Destroy(this.gameObject);
                break;

            case GameState.Main:
                Destroy(this.gameObject);
                break;

            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.CompareTo("Ground") == 0)
        {
            nowCount = 0;
        }
    }

    public void JumpBtn()
    {
        if (nowCount < jumpCount)
        {
            targetPos = new Vector3(transform.position.x, transform.position.y + jumpHeight, 0);
            nowCount++;
            transform.DOJump(targetPos, .5f, 1, .1f);
        }
    }

    public void EndMenu()
    {
        Vector2 yakkanUp = new Vector2(transform.position.x, transform.position.y + .001f);
        transform.DOJump(yakkanUp, .5f, 1, .1f);
    }

    public void SlideBtn()
    {
        if (nowTr == originTr)
        {

        }
    }
    
}
