namespace CoffeeVendingMachine.Coffee
{
	public abstract class Coffee
	{
		public int TotalIngridient = 2;
		public abstract void PrepareCoffee();

		public abstract int GetPrice();

		public bool IsIngridientSufficient() => TotalIngridient > 0;

		public void RefillIngridient()
		{
			TotalIngridient = 5;
			Console.WriteLine("Ingridient Fulled");
		}

		public void InsufficientIngridient()
		{
			Console.WriteLine("Insufficient Ingridient Press R to refile");
			var r = Console.ReadLine();
			if (r == "R")
			{
				RefillIngridient();
			}
		}

		public int GetRemainigChange(int amount)
		{
			return amount - GetPrice();
		}
	}
}
