using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
    public GameOver gameOver;

	public HealthBar healthBar;

    public AudioSource damageSoundSrc;
    public AudioClip damageSfx;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if(currentHealth <= 0)
        {
            gameOver.isGameOver = true;
        }
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bottomCube")
        {
            TakeDamage(34);
            damageSoundSrc.clip = damageSfx;
            damageSoundSrc.Play();
        }
    }
}
