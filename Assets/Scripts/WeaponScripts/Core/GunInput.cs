using UnityEngine;

public class GunInput : MonoBehaviour
{
    public bool FirePressed {  get; private set; }
    public bool FireReleased { get; private set; }

    public void ReadInput() 
    {
        FirePressed = Input.GetMouseButtonDown(0);
        FireReleased = Input.GetMouseButtonUp(0);
    }
}
