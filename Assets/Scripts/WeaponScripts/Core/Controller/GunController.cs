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

    #region Handle fire input
    private void HandleInput()
    {
        if (gunInput.FireReleased)
        {
            HandleFireReleased();
            return;
        }

        if (gunInput.FirePressed)
        {
            HandleFirePressed();
        }
    }

    private void HandleFirePressed()
    {
        if (!gunAmmo.TryConsumeShot())
            return;
        SetFireAnimation(true);
        Fire();
        if (gunAmmo.IsEmpty())
        {
            DeactivateWeapon();
        }
    }

    private void HandleFireReleased()
    {
        SetFireAnimation(false);
    }

    private void DeactivateWeapon()
    {
        SetFireAnimation(false);
        gameObject.SetActive(false);
    }

    private void SetFireAnimation(bool isFiring)
    {
        if (gunAnimation != null)
        {
            gunAnimation.SetGunAnimation(isFiring);
        }
    }
    #endregion

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
