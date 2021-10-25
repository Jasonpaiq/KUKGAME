using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WarpController : MonoBehaviour
{
    public string sceneName;
    public AudioSource warpSound;
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            Invoke("LoadNextScene",1);
            PlayerPrefs.SetString("PrevScene", sceneName);
            warpSound?.Play();
           
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName); 
    }
}
