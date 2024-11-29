using UnityEngine;

public static class Wallet
{
	public static int AmountCurrency;
	
	public static void SetAmount(int amount){
		AmountCurrency = amount;
		ActionBus.onWalletChanged?.Invoke();
	}
	
	public static void AddAmount(int amount){
		AmountCurrency += amount;
		ActionBus.onWalletChanged?.Invoke();
	}
	
	public static void ReduceAmount(int amount){
		AmountCurrency -= amount;
		ActionBus.onWalletChanged?.Invoke();
	}
	
	public static bool Validate(int amount){
		return AmountCurrency >= amount;
	}
	
	public static int GetAmount(){
		return AmountCurrency;
	}
}
