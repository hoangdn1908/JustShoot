using UnityEngine;

public class BasicGunController : GunController
{
    public override void Fire()
    {
        GameObject bulletObj = bulletPool.GetFromPool();
        SetFirePos(bulletObj);
        BulletController bullet = bulletObj.GetComponent<BulletController>();
        bullet.SetPool(bulletPool);
        bullet.Fire(GetShootDirection());
    }
}
