using UnityEngine;
using UnityEngine.UI;

public class HUDView : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    [SerializeField] private Image healthBar;

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health.health / health.maxHealth;
    }
}
