using System;
using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    [SerializeField] private int maxShots;
    public static Action<int, int> OnAmmoChanged;
    public int RemainShots {  get; private set; }

    public bool IsEmpty() 
    {
        return RemainShots <= 0;
    }

    public void ResetAmmo() 
    {
        RemainShots = maxShots;
        OnAmmoChanged?.Invoke(RemainShots, maxShots);
    }

    public bool TryConsumeShot() 
    {
        if (IsEmpty()) return false;
        RemainShots--;
        OnAmmoChanged?.Invoke(RemainShots, maxShots);
        return true;
    }
}
