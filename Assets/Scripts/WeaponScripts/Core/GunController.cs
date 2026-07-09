using UnityEditor.Rendering;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        Fire();
    }

    public virtual void Fire() 
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            PlayFireAnimation(false);
            return;
        }
    }

    public void PlayFireAnimation(bool value) 
    {
        animator.SetBool("isFiring", value);
    }
}
