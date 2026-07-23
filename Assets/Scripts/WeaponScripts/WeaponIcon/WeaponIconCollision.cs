using UnityEngine;

public class WeaponIconCollision : MonoBehaviour
{
    private WeaponIconController weaponIconController;

    private void Awake()
    {
        weaponIconController = GetComponent<WeaponIconController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            weaponIconController.ReturnToPool();
        }
    }
}
