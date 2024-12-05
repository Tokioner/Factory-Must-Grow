using UnityEngine;

public class Upgrader : MonoBehaviour
{
	[SerializeField] private UpgradeManager.Upgrades upgradeType;
	
	[SerializeField] private float baseUpgradeValue;
	[SerializeField] private float baseUpgradeCost;
	
	[SerializeField] private float upgradeValueMultiply = 1.0f;
	[SerializeField] private float upgradeCostMultiply = 1.5f;
	
	private float curValue;
	private float curCost;
	
	private BuyButton buyButton;
	
	private void Start(){
		buyButton = GetComponent<BuyButton>();
		curValue = baseUpgradeValue;
		curCost = baseUpgradeCost;
		buyButton.SetPrice((int)curCost);
	}
	
	public void Upgrade(){
		int upgradeValue = (int)curValue;
		switch(upgradeType){
			case UpgradeManager.Upgrades.ManualAdditionalAmount:
				UpgradeManager.ManualAdditionalAmount += upgradeValue;
				break;
			case UpgradeManager.Upgrades.ManualMultiplyAmount:
				UpgradeManager.ManualMultiplyAmount += upgradeValue;
				break;
			case UpgradeManager.Upgrades.AutoClickTime:
				UpgradeManager.AutoClickTime -= upgradeValue;
				break;
			case UpgradeManager.Upgrades.AutoClickTimeMultiply:
				UpgradeManager.AutoClickTimeMultiply += upgradeValue;
				break;
			case UpgradeManager.Upgrades.AutoClickValue:
				UpgradeManager.AutoClickValue += upgradeValue;
				break;
			case UpgradeManager.Upgrades.AutolMultiplyValue:
				UpgradeManager.AutolMultiplyValue += upgradeValue;
				break;
			default:
				Debug.Log("Upgrade not select!");
				break;
		}
		curValue = curValue * upgradeValueMultiply;
		curCost = curCost * upgradeCostMultiply;
		ActionBus.onUpgraded?.Invoke();
		buyButton.SetPrice((int)curCost);
	}
}