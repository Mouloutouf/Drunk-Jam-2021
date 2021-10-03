using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;


    [Header("FX")]
    public GameObject death_FX;
    public GameObject collision_FX;
    public GameObject damage_FX;
    public GameObject spawn_FX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        SpawnFX();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        DamageFX();

        if (health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        DeathFX();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    ///// FX
    ///

    public void SpawnFX()
    {
        if (spawn_FX != null)
        {
            Instantiate(spawn_FX, transform.position, Quaternion.identity);
        }
    }
    public void CollisionFX()
    {
        if (collision_FX != null)
        {
            Instantiate(collision_FX, transform.position, Quaternion.identity);
        }
    }
    public void DamageFX()
    {
        if (damage_FX != null)
        {
            Instantiate(damage_FX, transform.position, Quaternion.identity);
        }
    }
    public void DeathFX()
    {
        if (death_FX != null)
        {
            Instantiate(death_FX, transform.position, Quaternion.identity);
        }
    }
}
