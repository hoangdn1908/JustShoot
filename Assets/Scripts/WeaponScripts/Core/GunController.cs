using UnityEditor.Rendering;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform firePos;
    public Animator animator;

    private void Update()
    {
        HandleInput();
    }

    public virtual void Fire() { }

    private void HandleInput() 
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlayFireAnimation(false);
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            PlayFireAnimation(true);
            Fire();
        }

    }

    public void PlayFireAnimation(bool value) 
    {
        animator.SetBool("isFired", value);
    }

    public Vector2 GetShootDirection() 
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        return (mouse - firePos.position).normalized;
    }

    public void SetFirePos(GameObject bulletObj) 
    {
        bulletObj.transform.position = firePos.position;
        bulletObj.transform.rotation = firePos.rotation;
    }
}
