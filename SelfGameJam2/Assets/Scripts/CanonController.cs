using UnityEngine;

public class CanonController : MonoBehaviour
{
    private CanonFire[] canons;
    // Start is called before the first frame update
    void Start()
    {
        canons = GetComponentsInChildren<CanonFire>();
    }

    public void FireFirstHalfCanons()
    {
        for (int i = 0; i < Mathf.FloorToInt(canons.Length / 2f); i++)
        {
            canons[i].FireProjectile();
        }
    }
    public void FireSecondHalfCanons() 
    { 
        for (int i = Mathf.FloorToInt(canons.Length / 2f); i < canons.Length; i++)
        {
            canons[i].FireProjectile();
        }
    }

    public void FireEvenCanons()
    {
        for (int i = 0; i < canons.Length; i += 2)
        {
            canons[i].FireProjectile();
        }
    }

    public void FireOddCanons()
    {
        for (int i = 1; i < canons.Length; i += 2)
        {
            canons[i].FireProjectile();
        }
    }

    public void FireEverNthCanons(int start, int count)
    {
        for (int i = start; i < canons.Length; i += count)
        {
            canons[i].FireProjectile();
        }
    }
    public void ReverseFireEverNthCanons(int start, int count)
    {
        for (int i = canons.Length-1-start; i >= 0; i -= count)
        {
            canons[i].FireProjectile();
        }
    }
}
