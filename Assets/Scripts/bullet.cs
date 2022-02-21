using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    #region props
    private Transform target;
    public float attackSpeed = 70f;
    public float explosionRadius = 0f;
    public float slow = 0f;
    public int damage;
    public GameObject impactEffect;
    #endregion
    public void setTarget(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // target is dead || null 
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Bullet Hit Target
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = attackSpeed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // Bullet move towards target ( Target is alive )
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        // Hit Effect
     GameObject effectInstance = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);


        //Damage
        if (explosionRadius > 0f)
        {
            damageAoe();
        }
        else 
        {
            damageSingleTarget(target);
       
        }
        Destroy(gameObject); // delete bullet
    }

    void damageSingleTarget(Transform enemy)
    {
        Debug.Log(explosionRadius);
        if (slow > 0)
        {
            var slowme = enemy.GetComponent<EnemyMovement>();
            slowme.Slow(slow);
        }

        var dam = enemy.GetComponent<enemy>();
        dam.TakeDamage(damage);
      // Destroy(enemy.gameObject); // Instakill
    }

    void damageAoe()
    {
       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var collider in colliders)
        {
            if(collider.tag =="Enemy")
            {
                damageSingleTarget(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
