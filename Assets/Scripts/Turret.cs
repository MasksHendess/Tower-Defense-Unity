using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    #region props
    private Transform target;

    [Header("Attributes")]
    public float range = 15f; 
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public int cost;
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turretTurnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        // run function, begin at 0f, every 5f
    }

    void UpdateTarget()
    {
        // Find a target to shoot at
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }
    // Update is called once per frame
    void Update()
    {
        //no target
        if (target == null)
            return;

        // Lock On to Target
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        // Transition from current position to new rotation over time equal to turretTurnSpeed
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turretTurnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // Turret Attack
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime; // tick down each Update()
    }

    void Shoot()
    {
        // Debug.Log("ÄNFELLÄÄN");
      GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();

        if(bullet != null)
        {
            bullet.setTarget(target);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Show Turret Range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
