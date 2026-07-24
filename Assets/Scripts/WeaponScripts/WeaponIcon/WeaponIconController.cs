using UnityEngine;

[RequireComponent(typeof(WeaponIconCollision), typeof(FloatingWeapon))]
public class WeaponIconController : MonoBehaviour
{
    [SerializeField] private float timeInterval;
    private ObjectPool weaponIconPool;
    private float timer;

    private void Update()
    {
        CheckTimeLive();
    }

    public void SetPool(ObjectPool objectPool) 
    {
        weaponIconPool = objectPool;
    }

    private void CheckTimeLive() 
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval) 
        {
            timer = 0;
            ReturnToPool();
        }
    }

    public void ReturnToPool() 
    {
        weaponIconPool.ReturnToPool(gameObject);
    }
}
