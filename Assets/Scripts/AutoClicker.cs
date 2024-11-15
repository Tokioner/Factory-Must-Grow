using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    [SerializeField] private int autoClickPower = 1;
    [SerializeField] private float autoClickRate = 1f;
    private float nextAutoClickTime;

    public int AutoClickPower
    {
        get => autoClickPower;
        set => autoClickPower = Mathf.Max(0, value); // Не допускаем отрицательное значение
    }

    public float AutoClickRate
    {
        get => autoClickRate;
        set => autoClickRate = Mathf.Max(0.1f, value); // Минимальное значение для автоклика
    }

    private void Update()
    {
        if (Time.time >= nextAutoClickTime)
        {
            nextAutoClickTime = Time.time + autoClickRate;
            ActionBus.TriggerEvent("AddMoney", autoClickPower);
        }
    }
}
