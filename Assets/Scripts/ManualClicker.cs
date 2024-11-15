using UnityEngine;

public class ManualClicker : MonoBehaviour
{
    [SerializeField] private int clickPower = 1;

    public int ClickPower
    {
        get => clickPower;
        set => clickPower = Mathf.Max(0, value); // Не допускаем отрицательное значение
    }

    public void ManualClick()
    {
        ActionBus.TriggerEvent("AddMoney", clickPower);
    }
}
