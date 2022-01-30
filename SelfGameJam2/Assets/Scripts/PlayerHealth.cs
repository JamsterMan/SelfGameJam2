using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Image healthImage;

    public Sprite[] healthImages;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        healthImage.sprite = healthImages[healthImages.Length - 1];
    }

    public void HitPlayer()
    {
        if (health > 0)
        {
            health--;
            healthImage.sprite = healthImages[health];

            audioManager.PlaySound("PlayerDamage");
            Debug.Log("sound play hit");
        }

        if (health <= 0)
        {
            Debug.Log("GameOver");
            audioManager.PlaySound("Defeat");
            Destroy(gameObject);
        }
    }
}
