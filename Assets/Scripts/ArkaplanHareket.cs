using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InfiniteBackground : MonoBehaviour
{
    private float speed = 0.08f;
    Renderer rend;
    private Vector3 startpos;

    private void Start()
    {

        rend = GetComponent<Renderer>();

    }

    private void Update()
    {
        if(KarakterKontrol.isGameOver==false){
        Vector2 offset = new Vector2(Time.time*speed,0);
        rend.material.mainTextureOffset = offset;
        }
    }
}
