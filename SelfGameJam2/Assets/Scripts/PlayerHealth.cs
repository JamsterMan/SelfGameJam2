using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Image healthImage;

    public Sprite[] healthImages;

    private void Start()
    {
        healthImage.sprite = healthImages[healthImages.Length - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitPlayer()
    {
        Debug.Log("player Hit");
        health--;
        healthImage.sprite = healthImages[health-1];
    }
}
