using UnityEngine;
using TMPro;
public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;
	
	private void OnEnable(){
		ActionBus.onWalletChanged += UpdateText;
	}
	private void OnDisable(){
		ActionBus.onWalletChanged -= UpdateText;
	}
	private void UpdateText(){
		currencyText.text = Wallet.GetAmount().ToString();
	}
}
