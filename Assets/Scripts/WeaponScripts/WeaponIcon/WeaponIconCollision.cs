using System;
using UnityEngine;

public class WeaponIconCollision : MonoBehaviour
{
    [SerializeField] private int weaponId;
    private WeaponIconController weaponIconController;
    public static Action<int> OnWeaponIconHit;

    private void Awake()
    {
        weaponIconController = GetComponent<WeaponIconController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            weaponIconController.ReturnToPool();
            OnWeaponIconHit?.Invoke(weaponId);
        }
    }
}
