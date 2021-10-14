using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾�� ��ȣ�ۿ��� �� ������Ʈ���� ��� ���� ������Ʈ ex) ���, ġ��, ��ֹ� ���
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
