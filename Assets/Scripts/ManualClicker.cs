using UnityEngine;

public class ManualClicker : MonoBehaviour
{
	public void Click(){
		var amount = ((float)(UpgradeManager.ManualBasicAmount + UpgradeManager.ManualAdditionalAmount)) * (1.0f+((float)UpgradeManager.ManualMultiplyAmount/100.0f));
		Wallet.AddAmount((int)(amount));
	}
}
