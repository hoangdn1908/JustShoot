using UnityEngine;

public class GunAim : MonoBehaviour
{
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        RotateWeapon();  
    }

    private void RotateWeapon() 
    {
        if (cam == null)
            cam = Camera.main;
        if (cam == null) return;
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector2 dir = mousePos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        FlipWeapon(dir);
    }

    private void FlipWeapon(Vector2 aimDirection)
    {
        float y = aimDirection.x < 0f ? -1f : 1f;
        transform.localScale = new Vector3(1f, y, 1f);
    }
}