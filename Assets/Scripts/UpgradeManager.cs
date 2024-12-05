public static class UpgradeManager
{
	public enum Upgrades{
		ManualAdditionalAmount,
		ManualMultiplyAmount,
		AutoClickTime,
		AutoClickTimeMultiply,
		AutoClickValue,
		AutolMultiplyValue
	}
	public static int ManualBasicAmount = 1;
	public static int ManualAdditionalAmount = 0;
	public static int ManualMultiplyAmount = 0;
	
	public static float AutoClickTime = 10.0f;
	public static int AutoClickTimeMultiply = 0;
	
	public static int AutoClickValue = 0;
	public static int AutolMultiplyValue = 0;
}
