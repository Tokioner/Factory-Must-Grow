using UnityEngine;
using UnityEngine.UI;
public class AutoClicker : MonoBehaviour
{
	private float curTime = 0.0f;
	
	[SerializeField] private Image Fill;
	
	public void Update(){
		if(UpgradeManager.AutoClickValue <= 0)
			return;
		var clickTime = UpgradeManager.AutoClickTime * UpgradeManager.AutoClickTimeMultiply;
		if(curTime >= clickTime){
			var amount = UpgradeManager.AutoClickValue * UpgradeManager.AutolMultiplyValue;
			Wallet.AddAmount((int)amount);
			curTime = 0.0f;
		}else{
			curTime += Time.deltaTime;
			Fill.fillAmount = curTime/clickTime;
		}
	}
}