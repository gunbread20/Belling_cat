using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int      MouseNum;   // 쥐의 고유 번호
    public int      jumpCount;  // 총 점프가능 횟수 
    public float    jumpHeight; // 점프 높이

    Transform originTr, nowTr;
    Vector3 targetPos;

    [SerializeField]
    int nowCount;

    // Start is called before the first frame update
    void Start()
    {
        originTr = transform;
        transform.position = new Vector2(0, -4);
        nowCount    = 0;
        nowTr = originTr;
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

    public void SlideBtn()
    {
        if (nowTr == originTr)
        {

        }
    }
    
}
