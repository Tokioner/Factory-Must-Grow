using UnityEngine;
using UnityEngine.UI;
public class AutoClicker : MonoBehaviour
{
	private float curTime = 0.0f;
	
	[SerializeField] private Image Fill;
	
	public void Update(){
		if(UpgradeManager.AutoClickValue <= 0)
			return;
		var clickTime = ((float)(UpgradeManager.AutoClickTime)) * (1.0f+((float)UpgradeManager.AutoClickTimeMultiply/100.0f));
		if(curTime >= clickTime){
			var amount = ((float)(UpgradeManager.AutoClickValue)) * (1.0f+((float)UpgradeManager.AutolMultiplyValue/100.0f));
			Wallet.AddAmount((int)amount);
			curTime = 0.0f;
		}else{
			curTime += Time.deltaTime;
			Fill.fillAmount = curTime/clickTime;
		}
	}
}