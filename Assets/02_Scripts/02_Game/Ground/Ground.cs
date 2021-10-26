using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ground : MonoBehaviour
{
    private float speed;
    Vector2 newPos;
    float newX;
    GroundPool Gp;
    GameState state;

    private void Start()
    {
        Gp = GetComponentInParent<GroundPool>();
        speed = GameManager.instans.speed;
        newX = transform.position.x;
    }

    // 화면 나가면 반환
    // 반환 함수

    void Update()
    {
        state = GameManager.instans.StateGet();

        if (transform.position.x > -31 && state == GameState.Running)
        {
            newX -= speed * Time.deltaTime * 15;
            newPos = new Vector2(newX, transform.position.y);
            transform.position = newPos;
        }
        else if(transform.position.x <= -31)
        {
            Gp.ReturnGround();
        }
    }
}
