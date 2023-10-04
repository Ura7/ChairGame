using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
 [SerializeField] private AudioSource menusound;   
 private float delay = 1f;
 private float timeElapsed;
    public void Start()
    {
        menusound.Play();

    }       
    public void playGame()
    {
        
        
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
            menusound.Stop();   
        
        
        
    }
    public void quitGame()
    {
        Application.Quit();
        menusound.Stop();
    }
    IEnumerator LoadLevel(int levelİndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("ChairGame");
    }

   
}
