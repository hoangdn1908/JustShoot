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
        Vector3 mouse = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        return (mouse - firePos.position).normalized;
    }

    public void SetFireTransform(BulletController bulletObj)
    {
        bulletObj.transform.position = firePos.position;
        bulletObj.transform.rotation = firePos.rotation;
    }

    public void ShootBullet(Vector2 direction)
    {
        BulletController bullet = bulletPool.GetFromPool().GetComponent<BulletController>();
        SetFireTransform(bullet);
        bullet.SetPool(bulletPool);
        bullet.Fire(direction);
    }
}
