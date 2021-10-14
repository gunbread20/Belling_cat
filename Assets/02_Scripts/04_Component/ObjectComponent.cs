using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

// 플레이어와 상호작용을 할 오브젝트들이 상속 받을 컴포넌트 ex) 방울, 치즈, 장애물 등등
public class ObjectComponent
{
    bool isOver;
    Vector2 endPoint;
    Transform myTr;

    IEnumerator Move()
    {
        while (!isOver || myTr.position.x <= endPoint.x)
        {
            myTr.DOMove(endPoint, GameManager.instans.speed * Time.deltaTime);
            yield return null;
        }   
    }
}
