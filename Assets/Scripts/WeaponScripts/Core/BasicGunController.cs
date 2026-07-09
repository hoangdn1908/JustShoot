using UnityEngine;

public class BasicGunController : GunController
{
    public override void Fire()
    {
        GameObject bulletObj = bulletPool.GetFromPool();
        bulletObj.transform.position = firePos.position;
        bulletObj.transform.rotation = firePos.rotation;
        BulletController bullet = bulletObj.GetComponent<BulletController>();
        bullet.SetPool(bulletPool);
        bullet.Fire(GetShootDirection());
    }
}
