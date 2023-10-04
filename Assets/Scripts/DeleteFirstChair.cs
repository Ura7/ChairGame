using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFirstChair : MonoBehaviour
{
    public GameObject firstChair;
    OyunKontrl oyunkntrl;
    void Start()
    {
        oyunkntrl = this.gameObject.GetComponent<OyunKontrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(firstChair!=null && (int)oyunkntrl.sayac>0.5)
        {
        //firstChair.GetComponent<Rigidbody2D>().AddForce(new Vector3(-0.30f,0,0));
            if(firstChair.transform.position.x<=-12.00f)
        {
             Destroy(firstChair);
        }

        }
        
    }
}
