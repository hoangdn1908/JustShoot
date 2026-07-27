using TMPro;
using UnityEngine;

public class GunUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;

    private void OnEnable()
    {
        GunAmmo.OnAmmoChanged += UpdateAmmoTextUI;
    }

    private void OnDisable()
    {
        GunAmmo.OnAmmoChanged -= UpdateAmmoTextUI;
    }

    private void UpdateAmmoTextUI(int currentAmmo, int maxAmmo) 
    {
        ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }
}
