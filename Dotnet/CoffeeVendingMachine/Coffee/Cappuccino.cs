namespace CoffeeVendingMachine.Coffee
{
	internal class Cappuccino : Coffee
	{

		public override int GetPrice()
		{
			return 10;
		}

		public override void PrepareCoffee()
		{
			if (IsIngridientSufficient())
			{
				TotalIngridient--;
				Console.WriteLine("Praparing Cappuccino coffee");
			}
			else
			{
				InsufficientIngridient();
			}
		}
	}
}
