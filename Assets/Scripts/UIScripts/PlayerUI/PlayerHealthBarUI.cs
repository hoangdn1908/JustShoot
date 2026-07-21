using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private Image playerIcon;
    [SerializeField] private Image playerHealthAmount;

    private void Start()
    {
        SetPlayerIcon();
    }

    private void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHealthBarUI;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealthBarUI;
    }

    private void UpdateHealthBarUI(float currentHealth, float maxHealth)
    {
        playerHealthAmount.fillAmount = currentHealth / maxHealth;
    }

    private void SetPlayerIcon() 
    {
        playerIcon.sprite = SelectedCharacterSpawner.Instance.SelectedCharacter.characterIconInGame;
    }
}
