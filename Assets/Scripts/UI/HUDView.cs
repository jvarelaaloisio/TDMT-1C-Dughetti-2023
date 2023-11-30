using UnityEngine;
using UnityEngine.UI;

public class HUDView : MonoBehaviour
{
    [SerializeField] private CharacterHealth health;
    [SerializeField] private Image healthBar;
    [SerializeField] private bool isBoss;

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health.GetHealth() / health.GetMaxHealth();
    }
}
