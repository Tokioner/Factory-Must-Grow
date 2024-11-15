using UnityEngine;

[CreateAssetMenu(fileName = "ManualClickUpgrade", menuName = "Upgrades/ManualClickUpgrade")]
public class ManualClickUpgrade : BaseUpgrade
{
    [SerializeField] private int additionalClickPower;

    public override void ApplyUpgrade(GameObject target)
    {
        var manualClicker = target.GetComponent<ManualClicker>();
        if (manualClicker != null)
        {
            manualClicker.ClickPower += additionalClickPower; // Увеличиваем мощность клика
        }
    }
}
