using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private AudioSource deathSFX2;

    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("Ground"))
        {
        KarakterKontrol.isGameOver = true;
        deathSFX2.Play();
         
        }
    }
}
