using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float currentMoveSpeed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            OnHit(collision.gameObject.GetComponent<Enemy>());
        }
    }

    private void Update()
    {
        transform.Translate((Vector3)Vector2.right * currentMoveSpeed * Time.deltaTime);
    }

    protected virtual void OnHit(Enemy e)
    {
        e.TakeDamage(damage);
        Destroy(gameObject);
    }
}
