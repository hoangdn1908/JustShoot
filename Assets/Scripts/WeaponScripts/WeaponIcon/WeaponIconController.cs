using UnityEngine;

[RequireComponent(typeof(WeaponIconCollision), typeof(FloatingWeapon))]
public class WeaponIconController : MonoBehaviour
{
    [SerializeField] private float timeInterval;
    private ObjectPool weaponIconPool;
    private float timer;

    private void Update()
    {
        CheckTimeLife();
    }

    private void SetPool(ObjectPool objectPool) 
    {
        weaponIconPool = objectPool;
    }

    private void CheckTimeLife() 
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval) 
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool() 
    {
        //weaponIconPool.ReturnToPool(gameObject);
        gameObject.SetActive(false);
    }
}
