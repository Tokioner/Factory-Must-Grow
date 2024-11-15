using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int Currency { get; private set; }

    private void OnEnable()
    {
        ActionBus.Subscribe("AddMoney", AddCurrency);
        ActionBus.Subscribe("RemoveMoney", RemoveCurrency);
    }

    private void OnDisable()
    {
        ActionBus.Unsubscribe("AddMoney", AddCurrency);
        ActionBus.Unsubscribe("RemoveMoney", RemoveCurrency);
    }

    private void AddCurrency(object amount)
    {
        Currency += (int)amount;
        ActionBus.TriggerEvent("OnCurrencyChange", Currency); // Уведомление о изменении валюты
    }

    private void RemoveCurrency(object amount)
    {
        Currency -= (int)amount;
        ActionBus.TriggerEvent("OnCurrencyChange", Currency); // Уведомление о изменении валюты
    }

    public bool TrySpendCurrency(int amount)
    {
        if (Currency >= amount)
        {
            ActionBus.TriggerEvent("RemoveMoney", amount);
            return true;
        }
        return false;
    }
}
