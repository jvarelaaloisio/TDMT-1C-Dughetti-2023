using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    // Movement
    [SerializeField] private CharacterMovement characterMovement;

    //TODO: TP2 - Move all input reads to specific class
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 direction = new Vector2(context.ReadValue<Vector2>().x, characterMovement.GetDirection().y); 
        characterMovement.SetDirection(direction);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        characterMovement.Jump();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        characterMovement.Attack();
    }
}
