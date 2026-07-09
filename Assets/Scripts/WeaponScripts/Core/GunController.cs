using UnityEditor.Rendering;
using UnityEngine;

public class GunController : MonoBehaviour
{
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
}
