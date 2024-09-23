namespace CoffeeVendingMachine.Coffee
{
	public class Espresso : Coffee
	{
		public override int GetPrice()
		{
			return 20;
		}

		public override void PrepareCoffee()
		{
			if (IsIngridientSufficient())
			{
				TotalIngridient--;
				Console.WriteLine("Preparing Espresso Coffee");
			}
			else
			{
				InsufficientIngridient();
			}
		}
	}
}
