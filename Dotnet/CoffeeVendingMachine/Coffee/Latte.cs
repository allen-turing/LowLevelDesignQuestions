namespace CoffeeVendingMachine.Coffee
{
	public class Latte : Coffee
	{
		public override int GetPrice()
		{
			return 30;
		}

		public override void PrepareCoffee()
		{
			if (IsIngridientSufficient())
			{
				TotalIngridient--;
				Console.WriteLine("Preparing Coffee Latte");
			}
			else
			{
				InsufficientIngridient();
			}
		}

	}
}
