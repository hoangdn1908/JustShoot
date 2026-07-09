using UnityEngine;

public class BasicGunController : GunController
{
    public override void Fire()
    {
        BulletController bullet = bulletPool.GetFromPool().GetComponent<BulletController>();
        bullet.Fire(GetShootDirection());
    }
}
