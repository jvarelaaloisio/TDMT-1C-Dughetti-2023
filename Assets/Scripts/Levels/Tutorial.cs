using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private CheatsHandler cheatsHandler;
    [SerializeField] private GameObject tutorialMoveMessage;
    [SerializeField] private GameObject tutorialJumpMessage;
    [SerializeField] private GameObject tutorialAttackMessage;

    private void Start()
    {
        if(cheatsHandler != null)
            cheatsHandler.ToggleInvulnerabilityCheat();
    }
}