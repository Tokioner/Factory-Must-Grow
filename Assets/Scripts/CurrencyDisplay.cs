using TMPro;
using UnityEngine;

public class CurrencyDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText; // TextMeshPro для отображения
    [SerializeField] private string postfix = "";           // Постфикс для текста, например " коинов"

    private void OnEnable()
    {
        ActionBus.Subscribe("OnCurrencyChange", UpdateCurrencyDisplay);
    }

    private void OnDisable()
    {
        ActionBus.Unsubscribe("OnCurrencyChange", UpdateCurrencyDisplay);
    }

    private void UpdateCurrencyDisplay(object currentCurrency)
    {
        currencyText.text = $"{currentCurrency}{postfix}";
    }
}
