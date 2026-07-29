using UnityEngine;

public class ShortGunController : GunController
{
    public override void Fire()
    {
        AudioManager.Instance.PlayShortGunSound();
        ShootBullet(GetShootDirection());
    }
}
