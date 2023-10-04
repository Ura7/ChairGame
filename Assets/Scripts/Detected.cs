using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Detected : MonoBehaviour
{
    [SerializeField] private AudioSource deathSFX;
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag.Equals("Chair"))
        {
            KarakterKontrol.isGameOver = true;
            deathSFX.Play();
        }
    }
}
