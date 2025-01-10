using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health PlayerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = PlayerHealth.currentHealth / 10f;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = PlayerHealth.currentHealth / 10f;
    }
}
