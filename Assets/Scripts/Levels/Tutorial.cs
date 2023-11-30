using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private CheatsHandler cheatsHandler;

    private void Start()
    {
        if(cheatsHandler != null)
        {
            Debug.Log("Activate invulnerability");
            cheatsHandler.ToggleInvulnerabilityCheat();
        }
    }
}