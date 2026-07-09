using UnityEngine;

public class BasicGunController : GunController
{
    public override void Fire()
    {
        base.Fire();
        if (Input.GetMouseButtonDown(0))
        {
            PlayFireAnimation(true);
            Debug.Log("1 bullet");
        }
    }
}
