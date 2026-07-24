using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private int weaponId;

    private void Start()
    {
        HandleSetActiveWeapon(weaponId);    
    }

    private void OnEnable()
    {
        WeaponIconCollision.OnWeaponIconHit += HandleSetActiveWeapon;
    }

    private void OnDisable()
    {
        WeaponIconCollision.OnWeaponIconHit -= HandleSetActiveWeapon;
    }

    private void TurnOffWeapons() 
    {
        for (int i = 0; i < weapons.Length; i++) 
        {
            weapons[i].SetActive(false);
        }
    }

    private void HandleSetActiveWeapon(int index) 
    {
        TurnOffWeapons();
        weapons[index].SetActive(true);
    }
}
