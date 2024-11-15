using UnityEngine;

public abstract class BaseUpgrade : ScriptableObject
{
    [SerializeField] private string upgradeName;
    [SerializeField] private int cost;

    public string UpgradeName => upgradeName;
    public int Cost => cost;

    public abstract void ApplyUpgrade(GameObject target);
}
