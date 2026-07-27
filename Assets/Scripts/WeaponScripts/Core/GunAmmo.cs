using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    [SerializeField] private int maxShots;
    public int RemainShots {  get; private set; }

    public bool IsEmpty() 
    {
        return RemainShots <= 0;
    }

    public void ResetAmmo() 
    {
        RemainShots = maxShots;
    }

    public bool TryConsumeShot() 
    {
        if (IsEmpty()) return false;
        RemainShots--;
        return true;
    }
}
