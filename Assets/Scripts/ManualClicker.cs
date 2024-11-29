using UnityEngine;

public class ManualClicker : MonoBehaviour
{
	public void Click(){
		var amount = (UpgradeManager.ManualBasicAmount + UpgradeManager.ManualAdditionalAmount) * UpgradeManager.ManualMultiplyAmount;
		Wallet.AddAmount((int)(amount));
	}
}
