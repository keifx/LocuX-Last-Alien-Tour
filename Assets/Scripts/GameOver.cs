using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool isGameOver;
    public GameObject gameOverPanel;
    public GameObject player;
    public AudioSource deathSfxSrc;
    public AudioClip deathSoundClip;

    private void Update()
    {
        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
            //Time.timeScale = 0;
            deathSfxSrc.clip = deathSoundClip;
            deathSfxSrc.Play();
        }
        else
        {
            gameOverPanel.SetActive(false);
            Time.timeScale = 1;
        }

        if (player.gameObject.transform.localPosition.y < -3)
        {
            isGameOver = true;
        }
    }
}
