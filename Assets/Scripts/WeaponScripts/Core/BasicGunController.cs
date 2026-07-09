using UnityEngine;

public class BasicGunController : GunController
{
    public override void Fire()
    {
        BulletController bullet = Instantiate(bulletPrefabs, firePos.position, Quaternion.identity);
        bullet.Fire(GetShootDirection());
    }
}
