using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public GameObject enemyprojectilePrefab; // The projectile prefab to be shot
    public float fireRate = 1.5f; // The rate of fire in seconds
    private float lastFiredTime = 0f; // The time when the player last fired a projectile
    [SerializeField] private Transform Firepoint;
    [SerializeField] private bool right;
    [SerializeField] private bool up;
    [SerializeField] private bool left;
    [SerializeField] private bool down;
    //public Animator animator;

    void Update()
    {
        if (Time.time > lastFiredTime + fireRate)
        {
            lastFiredTime = Time.time;
            GameObject projectile = Instantiate(enemyprojectilePrefab, new Vector3(Firepoint.transform.position.x, Firepoint.transform.position.y, 0), Quaternion.identity);
            if (right)
            {
                projectile.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (up)
            {
                projectile.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (down)
            {
                projectile.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (left)
            {
                projectile.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }
}
