using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private BulletController bulletController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            bulletController.ReturnToPool();
        }
    }
}
