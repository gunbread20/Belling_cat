using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private MeshRenderer render;
    private float offset;
    private GameState gState;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (GameManager.instans.StateGet() == GameState.Running)
        {
            offset += Time.deltaTime * GameManager.instans.speed;
            render.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
