using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<BaseUpgrade> availableUpgrades;

    public void BuyUpgrade(BaseUpgrade upgrade, GameObject target)
    {
        var currencyManager = FindObjectOfType<CurrencyManager>();
        if (currencyManager != null && currencyManager.TrySpendCurrency(upgrade.Cost))
        {
            upgrade.ApplyUpgrade(target);
            ActionBus.TriggerEvent("OnUpgradeBought", upgrade.UpgradeName);
        }
    }
}
