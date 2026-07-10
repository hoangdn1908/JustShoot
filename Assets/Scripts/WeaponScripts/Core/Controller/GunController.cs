using UnityEditor.Rendering;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GunInput gunInput { get; private set; }
    public GunAnimation gunAnimation { get; private set; }
    public GunShoot gunShoot { get; private set; }

    private void Awake()
    {
        InitializeComponent();
    }

    private void Update()
    {
        gunInput.ReadInput();
        HandleInput();
    }

    public virtual void Fire() { }

    private void HandleInput() 
    {
        if (gunInput.FireReleased)
        {
            gunAnimation.SetGunAnimation(false);
            return;
        }
        if (gunInput.FirePressed)
        {
            gunAnimation.SetGunAnimation(true);
            Fire();
        }

    }

    private void InitializeComponent() 
    {
        gunShoot = GetComponent<GunShoot>();
        gunInput = GetComponent<GunInput>();
        gunAnimation = GetComponent<GunAnimation>();
    }

    protected Vector2 GetShootDirection()
    {
        return gunShoot.GetShootDirection();
    }

    protected void ShootBullet(Vector2 direction)
    {
        gunShoot.ShootBullet(direction);
    }
}
