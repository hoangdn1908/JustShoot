using UnityEngine;

public class GunAim : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private SpriteRenderer sprite;

    void Awake()
    {
        cam = Camera.main;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 dir = mousePos - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (mousePos.x < transform.position.x)
            sprite.flipY = true;
        else
            sprite.flipY = false;
    }
}