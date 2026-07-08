using UnityEditor.Rendering;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Update()
    {
        Fire();
    }

    private void Fire() 
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            animator.SetBool("isFiring", false);
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isFiring", true);
        }
    }
}
