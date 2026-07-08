using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveInput {  get; private set; }

    public void ReadInput() 
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    public bool HasMoveInput() 
    {
       return MoveInput != Vector2.zero;
    }
}
