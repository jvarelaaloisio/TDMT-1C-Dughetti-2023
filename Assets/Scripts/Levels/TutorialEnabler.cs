using UnityEngine;

public class TutorialEnabler : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;
    [SerializeField] private GameObject currentMessage;
    [SerializeField] private GameObject nextMessage;

    private void OnEnable()
    {
        if(currentMessage != null)
            currentMessage.SetActive(true);
    }

    [ContextMenu("Enable")]
    private void EnableObject()
    {
        objectToEnable.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentMessage != null)
            currentMessage.SetActive(false);

        if (nextMessage != null)
            nextMessage.SetActive(true);

        EnableObject();
        gameObject.SetActive(false);
    }
}