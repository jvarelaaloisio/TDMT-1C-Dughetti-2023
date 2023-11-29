using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    // Movement
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private LevelHandler levelHandler;
    [SerializeField] private CheatsHandler cheatsHandler;

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

    public void Pause(InputAction.CallbackContext context)
    {
        levelHandler.TogglePause();
    }

    public void ToggleControls(InputAction.CallbackContext context)
    {
        levelHandler.ToggleShowControls();
    }

    public void ToggleCheats(InputAction.CallbackContext context)
    {
        levelHandler.ToggleShowCheats();
    }

    public void ToggleInvulnerabilityCheat(InputAction.CallbackContext context)
    {
        cheatsHandler.ToggleInvulnerabilityCheat();
    }

    public void ToggleSuperSpeedCheat(InputAction.CallbackContext context)
    {
        cheatsHandler.ToggleSuperSpeedCheat();
    }

    public void ToggleDamageAllCheat(InputAction.CallbackContext context)
    {
        cheatsHandler.ToggleDamageAllCheat();
    }

    public void StartButton()
    {
        Debug.Log("Start button pressed");
    }

    public void SelectButton()
    {
        Debug.Log("Select button pressed");
    }
}
