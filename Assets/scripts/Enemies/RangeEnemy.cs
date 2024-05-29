using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    public GameObject enemyprojectilePrefab; // The projectile prefab to be shot
    public float fireRate = 1.5f; // The rate of fire in seconds
    public float animTime = 1f;
    private float lastFiredTime = 0f; // The time when the player last fired a projectile
    private float lastAnimedTime = 0f;
    [SerializeField] private Transform Firepoint;
    [SerializeField] private bool right;
    public Animator mushAnimator;

    void Update()
    {
        if(Time.time > lastAnimedTime + fireRate)
        {
            mushAnimator.SetTrigger("Mush_Attack");
            lastAnimedTime = Time.time;
        }
        if (Time.time > lastFiredTime + fireRate + animTime)
        {
            GameObject projectile = Instantiate(enemyprojectilePrefab, new Vector3(Firepoint.transform.position.x, Firepoint.transform.position.y, 0), Quaternion.identity);
            if (!right)
            {
                projectile.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            lastFiredTime = Time.time - animTime;
        }
    }
}
