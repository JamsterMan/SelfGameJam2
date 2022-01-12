using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public CanonFire[] canons;
    private float timer;
    private int lastSec;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        lastSec = -1;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(Mathf.FloorToInt( timer) > lastSec)
        {
            lastSec++;
            FireWave(lastSec);
        }
    }

    public void FireWave(int time)
    {
        if (time % 2 == 0)
        {
            for (int i = 0; i < canons.Length; i = i + 2)
            {
                canons[i].FireProjectile();
            }
        }
        else
        {
            for (int i = 1; i < canons.Length; i = i + 2)
            {
                canons[i].FireProjectile();
            }
        }
    }
}
