using UnityEngine;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
	private enum DataType{
		Manual,
		Auto
	}
    [SerializeField] private DataType type;
	[SerializeField] private TextMeshProUGUI uiText;
	
	private void OnEnable(){
		ActionBus.onUpgraded += UpdateUI;
	}
	private void OnDisable(){
		ActionBus.onUpgraded -= UpdateUI;
	}
	
	private void UpdateUI(){
		float amount = 0;
		switch (type){
			case DataType.Manual:
				amount = (UpgradeManager.ManualBasicAmount + UpgradeManager.ManualAdditionalAmount) * UpgradeManager.ManualMultiplyAmount;
		uiText.text = $"+{((int)(amount)).ToString()}";
				break;
			case DataType.Auto:
				amount = UpgradeManager.AutoClickValue * UpgradeManager.AutolMultiplyValue;
				uiText.text = $"+{((int)(amount)).ToString()}/цикл";
				break;
			default:
				uiText.text = "Not selected!";
				break;
		}
	}
}
