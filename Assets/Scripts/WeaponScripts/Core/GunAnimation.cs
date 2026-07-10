using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetGunAnimation(bool value) 
    {
        if (animator == null) return;
        animator.SetBool("isFired", value);
    }
}
