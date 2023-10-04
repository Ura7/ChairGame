using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairOlusturma : MonoBehaviour
{
    public GameObject chair;
    public float chairsure = 2f;
    float maxHiz = 5;
    float maxChairsure = 0.5f;
    float sayac = 0f;
    int i =0;
    
    public float hiz =1;
    OyunKontrl oyunkontrol;
    KarakterKontrol charK;
     
    
    void Start()
    {
        oyunkontrol = this.gameObject.GetComponent<OyunKontrl>();
        charK = this.gameObject.GetComponent<KarakterKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
    
        
    if(KarakterKontrol.isGameOver==false){
    sayac-= Time.deltaTime;
    if(sayac<0){
        GameObject sandalye = Instantiate(chair,new Vector3(11.9f,-3.046f,0),Quaternion.Euler(0,0,0)) as GameObject;
        sandalye.GetComponent<Rigidbody2D>().AddForce(new Vector3(-250*hiz,hiz,0));
        sayac = chairsure;
    }
    
    GameObject[] atikChair = GameObject.FindGameObjectsWithTag("Chair");
    if(atikChair[i].transform.position.x<-12.5)
    {
        
        DestroyImmediate(atikChair[i]);
        
    }
   
   if(hiz<=maxHiz)
   {
    hiz += 0.02f*Time.deltaTime ;
   }
   else if(hiz>maxHiz && (int)oyunkontrol.sayac<=60)
   {
    hiz = maxHiz;
   }
    
   if (chairsure >= maxChairsure)
   {
     chairsure -= 0.02f*Time.deltaTime;
   }
   else if(chairsure<maxChairsure)
   {
    chairsure = maxChairsure;
   }

    if((int)oyunkontrol.sayac>60 && hiz<=5)
   {
    hiz += 0.02f*Time.deltaTime;
    
    
   }
   else if(hiz>5)
   {
    hiz = maxHiz;
   }
    }
   
    else 
    {
       GameObject[] atikChair1 = GameObject.FindGameObjectsWithTag("Chair");
       for(int j =0; j<atikChair1.Length;j++)
       {
        atikChair1[j].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        
        

       }
        
    }


    



}
    
   
        
    

}
