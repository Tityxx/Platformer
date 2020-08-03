using UnityEngine;

public class HitCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.tag = "DeadEnemy";
            Destroy(collision.gameObject);
        }
    }
}
