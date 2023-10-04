using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrl : MonoBehaviour
{
    public Text time;
    public float sayac =0;
    public float sayac1=0;

    public GameObject gameOverscreen;

    [SerializeField] public AudioSource gamePlaysound;
    void Start()
    {
        gamePlaysound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(KarakterKontrol.isGameOver==false){
        if(sayac<60)
        {
        sayac += Time.deltaTime;
        }
        else 
        {
            sayac1++;
            sayac=0;
        }
        
        time.text = (int)sayac1+":"+(int)sayac;
        }
        else 
        {
            gameOverscreen.SetActive(true);
        }
    }
    public void ReplayGame()
    {
        gamePlaysound.Stop();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  bu kodda levelli oyun yaparken o leveldeki sahneyi yeniden başlatıyor.

    }
    
    public void BackMainMenu()
    {
        StartCoroutine(LoadMenu(SceneManager.GetActiveScene().buildIndex));
        gamePlaysound.Stop();
        

    }

     IEnumerator LoadLevel(int levelİndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("ChairGame");
    }
    IEnumerator LoadMenu(int levelİndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
