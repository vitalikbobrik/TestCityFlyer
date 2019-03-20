using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioClip [] m_musicTracks;
    private AudioSource m_currentTrack;

    private void Start()
    {
        m_currentTrack = GetComponent<AudioSource>();
        m_currentTrack.clip = m_musicTracks[0];
        m_currentTrack.Play();
    }

    private void Update()
    {
        if (GameState.IsPaused)
        {
            m_currentTrack.volume = 0.1f;
        }
        else
        {
            m_currentTrack.volume = 0.3f;
        }
    }
}
