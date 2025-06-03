// See https://aka.ms/new-console-template for more information



using WeeklyMiniProject;

List<Asset> assets = new List<Asset>();


while (true){


    Console.WriteLine("Enter office location:");
    string officeinput = Console.ReadLine();

    if (Enum.TryParse<Location>(officeinput, out Location office))
    {
        Console.WriteLine($"Parsed successfully: {office}");
    }
    else
    {
        Console.WriteLine("Invalid input.");
    }

    Console.WriteLine("Enter asset type:");

    string input = Console.ReadLine();
    if (Enum.TryParse<AssetType>(input, out AssetType asset))
    {
        Console.WriteLine($"Parsed successfully: {asset}");
    }
    else
    {
        Console.WriteLine("Invalid input.");
    }


    Console.WriteLine("Enter brand:");
    string? brand = Console.ReadLine();

    Console.WriteLine("Enter Model:");
    string? model = Console.ReadLine();


    Console.WriteLine("Enter Purchase date (MM/dd/yyyy):");
    string enteredString = Console.ReadLine();
    DateTime purchaseDate = DateTime.Parse(enteredString);

    Console.WriteLine("Enter Purchase price:");
    float price = float.Parse(Console.ReadLine());


    
    switch (asset)
    {
        case AssetType.Computer:
            var computer = new Computer(office, brand, model, purchaseDate, price);
            assets.Add(computer);
            break;


        case AssetType.MobilePhone:
            var phone = new MobilePhone(office, brand, model, purchaseDate, price);
            assets.Add(phone);
            break;

        default:
            throw new ArgumentOutOfRangeException();

    }

    Console.WriteLine("Enter another product? y/n");

    if (Console.ReadLine() != "y")
    {
        break;
    }
}


Console.WriteLine("Office".PadRight(15) + "Asset".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Price (USD)".PadRight(15) + "Local price".PadRight(15) + "PurchaseDate".PadRight(15));

assets.Sort(); //Since we have implemented the compareTo-method of the IComparable interface in the Asset-class this works.


foreach (var asset in assets)
{
    DateTime threshold = asset.PurchaseDate.AddYears(3);
    TimeSpan timeUntilThreeYears = threshold - DateTime.Now;

    if (timeUntilThreeYears.TotalDays <= 90 && timeUntilThreeYears.TotalDays >= 0)
    {
        // Less than 3 months to 3-year mark
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(asset);
        Console.ResetColor();
    }
    else if (timeUntilThreeYears.TotalDays <= 180 && timeUntilThreeYears.TotalDays > 90)
    {
        // Between 3–6 months to 3-year mark
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(asset);
        Console.ResetColor();
    }
    else
    {
        // More than 6 months away or already passed 3 years
        Console.WriteLine(asset);
    }
}



Console.WriteLine("Press any key to exit.");
Console.ReadKey();



