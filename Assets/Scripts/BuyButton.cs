using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{
	public int Price;
	[SerializeField] private TextMeshProUGUI priceText;
	[SerializeField] private UnityEvent onBuy;
	
	private Button button;
	
	private void Start(){
		button = GetComponent<Button>();
	}
	
	private void OnEnable(){
		ActionBus.onWalletChanged += CheckValid;
	}
	
	private void OnDisable(){
		ActionBus.onWalletChanged -= CheckValid;
	}
	
	public void Buy(){
		Wallet.ReduceAmount(Price);
		onBuy?.Invoke();
	}
	
	public void SetPrice(int newPrice){
		Price = newPrice;
		UpdateUI();
	}
	
	private void UpdateUI(){
		priceText.text = Price.ToString();
	}
	
	private void CheckValid(){
		button.interactable = Wallet.Validate(Price);
	}
}