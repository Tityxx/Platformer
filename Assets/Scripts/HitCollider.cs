using UnityEngine;

public class HitCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Monster" || tag == "DestrObjects")
        {
            collision.gameObject.tag = "Dead";
            Destroy(collision.gameObject);
        }
    }
}
