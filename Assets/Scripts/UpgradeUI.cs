using UnityEngine;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
	private enum DataType{
		ManualAmount,
		ManualMultiply,
		AutoAmount,
		AutoTime,
		AutoMultiply,
		AutoTimeMultiply,
	}
    [SerializeField] private DataType type;
	[SerializeField] private TextMeshProUGUI uiText;
	[SerializeField] private string prefix, postfix;
	
	private void OnEnable(){
		ActionBus.onUpgraded += UpdateUI;
	}
	private void OnDisable(){
		ActionBus.onUpgraded -= UpdateUI;
	}
	
	private void UpdateUI(){
		float amount = 0;
		switch (type){
			case DataType.ManualAmount:
				amount = ((float)(UpgradeManager.ManualBasicAmount + UpgradeManager.ManualAdditionalAmount)) * (1.0f+((float)UpgradeManager.ManualMultiplyAmount/100.0f));
				SetText(amount);
				break;
			case DataType.ManualMultiply:
				SetText(UpgradeManager.ManualMultiplyAmount);
				break;
			case DataType.AutoAmount:
				amount = ((float)(UpgradeManager.AutoClickValue)) * (1.0f+((float)UpgradeManager.AutolMultiplyValue/100.0f));
				SetText(amount);
				break;
			case DataType.AutoTime:
				var clickTime = ((float)(UpgradeManager.AutoClickTime)) * (1.0f+((float)UpgradeManager.AutoClickTimeMultiply/100.0f));
				SetText(clickTime);
				break;
			case DataType.AutoMultiply:
				SetText(UpgradeManager.AutolMultiplyValue);
				break;
			case DataType.AutoTimeMultiply :
				SetText(UpgradeManager.AutoClickTimeMultiply);
				break;
			default:
				uiText.text = "Not selected!";
				break;
		}
	}
	private void SetText(int someValue){
		uiText.text = $"{prefix}{someValue.ToString()}{postfix}";
	}
	private void SetText(float someValue){
		uiText.text = $"{prefix}{((int)(someValue)).ToString()}{postfix}";
	}
}
