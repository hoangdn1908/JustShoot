using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform firePos;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public Vector2 GetShootDirection()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        if (mainCamera == null || firePos == null)
            return Vector2.right;
        Vector3 mouse = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        return (mouse - firePos.position).normalized;
    }

    public void SetFireTransform(BulletController bulletObj)
    {
        if (bulletObj == null || firePos == null) return;
        bulletObj.transform.position = firePos.position;
        bulletObj.transform.rotation = firePos.rotation;
    }

    public void ShootBullet(Vector2 direction)
    {
        if (bulletPool == null || firePos == null) return;
        BulletController bullet = bulletPool.GetFromPool().GetComponent<BulletController>();
        if (bullet == null) return;
        SetFireTransform(bullet);
        bullet.SetPool(bulletPool);
        bullet.Fire(direction);
    }
}
