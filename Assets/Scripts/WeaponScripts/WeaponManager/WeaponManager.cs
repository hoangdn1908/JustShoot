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
        if (index < 0 || index >= weapons.Length) return;
        TurnOffWeapons();
        GunAmmo weaponAmmo = weapons[index].GetComponent<GunAmmo>();
        weaponAmmo.ResetAmmo();
        weapons[index].SetActive(true);
    }
}
