using CoffeeVendingMachine.Coffee;

internal class CoffeeVendingMachineInitiator
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Please Select one of the coffee");
		var coffeeMap = new Dictionary<CoffeeType, Coffee>
		{
			{ CoffeeType.Espresso, new Espresso() },
			{ CoffeeType.Cappuccino, new Cappuccino() },
			{ CoffeeType.Latte, new Latte() }
		};



		while (true)
		{
			int items = 1;
			foreach (var coffee in coffeeMap)
			{
				Console.WriteLine($"{items++}. {coffee.Key} : ${coffee.Value.GetPrice()}");
			}
			TakeOrder(coffeeMap);
			Console.WriteLine("Enter E for Exit or ENTER to continue");
			if (Console.ReadLine() == "E")
			{
				break;
			}
		}

	}

	private static void TakeOrder(Dictionary<CoffeeType, Coffee> coffeeMap)
	{
		var input = Console.ReadLine();

		if (input == "1" && coffeeMap.TryGetValue(CoffeeType.Espresso, out var espressoCoffee))
		{
			ShowPrompts(espressoCoffee);
		}
		else if (input == "2" && coffeeMap.TryGetValue(CoffeeType.Cappuccino, out var cappuccinoCoffee))
		{
			ShowPrompts(cappuccinoCoffee);

		}
		else if (input == "3" && coffeeMap.TryGetValue(CoffeeType.Latte, out var latteCoffee))
		{
			ShowPrompts(latteCoffee);

		}
	}

	private static void ShowPrompts(Coffee espressoCoffee)
	{
		espressoCoffee.PrepareCoffee();
		Console.WriteLine($"Your cost is ${espressoCoffee.GetPrice()}");
		Console.Write($"Amount Paid: ");
		var amountPaid = Console.ReadLine();
		Console.WriteLine(amountPaid);
		if (int.TryParse(amountPaid, out var amount) && amount >= espressoCoffee.GetPrice())
		{
			Console.WriteLine($"Amount Returned : {espressoCoffee.GetRemainigChange(amount)}");
		}
		else
		{
			Console.WriteLine("Not sufficient amount or Amount Format Not Correct");
		}
	}
}