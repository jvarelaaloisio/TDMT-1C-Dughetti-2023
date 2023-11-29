using UnityEngine;

public class CheatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterHealth playerHealth;
    [SerializeField] private CharacterMovement playerMovement;

    public void ToggleInvulnerabilityCheat()
    {
        Debug.Log("Toggle Invulnerability cheat");
        playerHealth.SetIsImmuneToDamage(!playerHealth.GetIsImmuneToDamage());
    }

    public void ToggleSuperSpeedCheat()
    {
        Debug.Log("Toggle Super Speed");
        playerMovement.SetIsSuperSpeedEnabled(!playerMovement.GetIsSuperSpeedEnabled());
    }

    public void ToggleDamageAllCheat()
    {
        Debug.Log("Toggle Damage All");
        playerMovement.SetIsDamageAllEnabled(!playerMovement.GetIsDamageAllEnabled());
    }
}
