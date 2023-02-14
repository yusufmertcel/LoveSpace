using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sound[] sounds;
    void Start()
    {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
        PlaySound("mainmusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame(){
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void PlaySound(string name){
        foreach(Sound s in sounds){
            if(s.name == name){
                s.source.Play();
            }
        }
    }

    public void StopSound(string name){
        foreach(Sound s in sounds){
            if(s.name == name){
                s.source.Stop();
            }
        }
    }

    public static void GameOver(){
        Debug.Log("Basaramadin");
    }
}
