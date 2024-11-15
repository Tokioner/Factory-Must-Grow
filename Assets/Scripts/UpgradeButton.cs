using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private BaseUpgrade upgrade; // Ссылка на улучшение
    [SerializeField] private GameObject target;    // Объект, к которому будет применено улучшение
    [SerializeField] private UpgradeManager upgradeManager; // Ссылка на UpgradeManager
    [SerializeField] private Button button; // Кнопка для покупки
    [SerializeField] private TextMeshProUGUI buttonText; // Ссылка на TextMeshProUGUI для отображения текста кнопки

    private void Start()
    {
        button.onClick.AddListener(OnUpgradeButtonClicked);
        UpdateButtonText();
        UpdateButtonInteractable(); // Устанавливаем доступность кнопки

        // Подписка на событие изменения валюты
        ActionBus.Subscribe("OnCurrencyChange", OnCurrencyChanged);
    }

    private void OnDestroy()
    {
        // Отписка от события при уничтожении объекта
        ActionBus.Unsubscribe("OnCurrencyChange", OnCurrencyChanged);
    }

    private void OnCurrencyChanged(object currency)
    {
        UpdateButtonInteractable(); // Обновляем доступность кнопки при изменении валюты
    }

    private void OnUpgradeButtonClicked()
    {
        upgradeManager.BuyUpgrade(upgrade, target); // Просто вызываем метод покупки
        UpdateButtonInteractable(); // Обновляем доступность кнопки после покупки
    }

    private void UpdateButtonText()
    {
        buttonText.text = $"{upgrade.UpgradeName} - {upgrade.Cost}"; // Устанавливаем текст кнопки
    }

    private void UpdateButtonInteractable()
    {
        var currencyManager = FindObjectOfType<CurrencyManager>();
        if (currencyManager != null)
        {
            bool isInteractable = currencyManager.Currency >= upgrade.Cost; // Проверяем, достаточно ли валюты
            button.interactable = isInteractable; // Устанавливаем доступность кнопки
        }
    }
}
