
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
{
    Health health = collision.GetComponent<Health>();
    if (health != null)
    {
        health.TakeDamage(damage);
    }
    else
    {
        Debug.LogWarning("Collider tidak memiliki komponen Health.");
    }
}

}
