using UnityEngine;

public class CanonFire : MonoBehaviour
{

    public Rigidbody2D projectile;
    public float projectileSpeed;

    public AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void FireProjectile()
    {
        Rigidbody2D projectileRB = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody2D;
        projectileRB.velocity = transform.right * projectileSpeed;

        if(audioManager)
            audioManager.PlaySound("CanonFire");
    }
}
