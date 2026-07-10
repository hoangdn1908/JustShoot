using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetGunAnimation(bool value) 
    {
        animator.SetBool("isFired", value);
    }
}
