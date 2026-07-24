using UnityEngine;

[RequireComponent(typeof(WeaponIconCollision), typeof(FloatingWeapon))]
public class WeaponIconController : MonoBehaviour
{
    [SerializeField] private float timeInterval;
    private FloatingWeapon floatingWeapon;
    private ObjectPool weaponIconPool;
    private float timer;

    private void Awake()
    {
        floatingWeapon = GetComponent<FloatingWeapon>();
    }

    private void Update()
    {
        CheckTimeLive();
    }

    public void PrepareForSpawn(ObjectPool objectPool, Vector3 spawnPos) 
    {
        weaponIconPool = objectPool;
        floatingWeapon.SetSpawnPosition(spawnPos);
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
