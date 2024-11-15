using UnityEngine;

[CreateAssetMenu(fileName = "AutoClickerUpgrade", menuName = "Upgrades/AutoClickerUpgrade")]
public class AutoClickerUpgrade : BaseUpgrade
{
    [SerializeField] private float additionalClickRate;
    [SerializeField] private int additionalClickPower;

    public override void ApplyUpgrade(GameObject target)
    {
        var autoClicker = target.GetComponent<AutoClicker>();
        if (autoClicker != null)
        {
            autoClicker.AutoClickRate -= additionalClickRate; // Уменьшаем время между автокликами
            autoClicker.AutoClickPower += additionalClickPower; // Увеличиваем мощность автоклика
        }
    }
}
