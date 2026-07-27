using UnityEngine;

public class GunController : MonoBehaviour
{
    public GunInput gunInput { get; private set; }
    public GunAnimation gunAnimation { get; private set; }
    public GunShoot gunShoot { get; private set; }
    public GunAmmo gunAmmo { get; private set; }

    private void Awake()
    {
        InitializeComponent();
    }

    private void Update()
    {
        if (gunInput == null) return;
        gunInput.ReadInput();
        HandleInput();
    }

    public virtual void Fire() { }

    private void HandleInput() 
    {
        if (gunInput.FireReleased)
        {
            if (gunAnimation != null)
                gunAnimation.SetGunAnimation(false);
            return;
        }
        if (gunInput.FirePressed)
        {
            if (gunAnimation != null)
                gunAnimation.SetGunAnimation(true);
            if (!gunAmmo.TryConsumeShot()) return;
            Fire();
            if (gunAmmo.IsEmpty()) 
            {
                if (gunAnimation != null)
                    gunAnimation.SetGunAnimation(false);
                gameObject.SetActive(false);
            }
        }
    }

    private void InitializeComponent() 
    {
        gunShoot = GetComponent<GunShoot>();
        gunInput = GetComponent<GunInput>();
        gunAnimation = GetComponent<GunAnimation>();
        gunAmmo = GetComponent<GunAmmo>();
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
