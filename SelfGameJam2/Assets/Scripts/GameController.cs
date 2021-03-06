using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int WaveChangeTime;
    public CanonFire[] canons;
    public CanonController canonControl;
    private int waveFire = 1;
    private readonly int maxFireWaves = 5;

    public void FireCanons(int time)
    {
        if(time%WaveChangeTime == 0)
        {
            waveFire = Random.Range(1, maxFireWaves);//upper bound is exclusive, lower bound is inclusive
        }

        switch (waveFire)
        {
            case 1:
                FireWave(time);
                break;
            case 2:
                FireWave2(time);
                break;
            case 3:
                FireWave3(time);
                break;
            case 4:
                FireWave4(time);
                break;
            default:
                FireWave(time);
                break;
        }
    }

    private void FireWave(int time)
    {
        if (time % 2 == 0)
        {
            canonControl.FireEvenCanons();
        }
        else
        {
            canonControl.FireOddCanons();
        }
    }
    private void FireWave2(int time)
    {
        if (time % 2 == 0)
        {
            canonControl.FireFirstHalfCanons();
        }
        else
        {
            canonControl.FireSecondHalfCanons();
        }
    }

    private void FireWave3(int time)
    {
        canonControl.FireEverNthCanons(time % 3, 3);//time is always increasing so time%4 fixes it to be only 0,1,2,or 3
    }

    private void FireWave4(int time)
    {
        canonControl.ReverseFireEverNthCanons(time%20,5);
        canonControl.FireEverNthCanons(time%20,5);
    }

    private void FireWave5(int time)
    {
        canonControl.FireEverNthCanons(time % 3, 6);
        //then fire cannon from sides
    }

}
