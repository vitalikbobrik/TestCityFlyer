using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicMenuPlay : MonoBehaviour
{

    private static MusicMenuPlay _instance;

    void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    public void turnMusicOff()
    {
        if (_instance != null)
        {
            this.gameObject.GetComponent<AudioSource>().Stop();
            Destroy(this.gameObject);
            MusicMenuPlay._instance = null;
        }
    }

}
