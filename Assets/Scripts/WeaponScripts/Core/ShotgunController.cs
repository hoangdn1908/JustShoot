using UnityEngine;

public class ShotgunController : GunController
{
    [SerializeField] private float spreadAngle = 10f;

    public override void Fire()
    {
        Vector2 dir = GetShootDirection();

        ShootBullet(Rotate(dir, -spreadAngle));
        ShootBullet(Rotate(dir, spreadAngle));

        PlayFireAnimation(true);
    }

    private void ShootBullet(Vector2 direction)
    {
        BulletController bullet =
            bulletPool.GetFromPool().GetComponent<BulletController>();

        bullet.transform.position = firePos.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetPool(bulletPool);
        bullet.Fire(direction);
    }

    private Vector2 Rotate(Vector2 direction, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;

        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);

        return new Vector2(
            direction.x * cos - direction.y * sin,
            direction.x * sin + direction.y * cos
        );
    }
}