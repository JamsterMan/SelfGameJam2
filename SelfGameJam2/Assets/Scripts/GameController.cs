using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int WaveChangeTime;
    public CanonFire[] canons;
    private int waveFire = 1;

    public void FireCanons(int time)
    {
        if(time%WaveChangeTime == 0)
        {
            waveFire = Random.Range(1, 3);//upper bound is exclusive, lower bound is inclusive
            Debug.Log(waveFire);
        }

        switch (waveFire)
        {
            case 1:
                FireWave(time);
                break;
            case 2:
                FireWave2(time);
                break;
            default:
                FireWave(time);
                break;
        }
    }

    public void FireWave(int time)
    {
        if (time % 2 == 0)
        {
            for (int i = 0; i < canons.Length; i += 2)
            {
                canons[i].FireProjectile();
            }
        }
        else
        {
            for (int i = 1; i < canons.Length; i += 2)
            {
                canons[i].FireProjectile();
            }
        }
    }

    public void FireWave2(int time)
    {
        if (time % 2 == 0)
        {
            for (int i = 0; i < Mathf.FloorToInt(canons.Length / 2f); i++)
            {
                canons[i].FireProjectile();
            }
        }
        else
        {
            for (int i = Mathf.FloorToInt(canons.Length/2f); i < canons.Length; i++)
            {
                canons[i].FireProjectile();
            }
        }
    }
}
