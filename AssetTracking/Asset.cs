using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyMiniProject
{


    public class Asset : IComparable
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float Price { get; set; }
        public float LocalPrice { get; set; }
        public Location Office { get; set; }
        public Asset(Location office, string brand, string model, DateTime purchaseDate, float price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price has to be greater than 0.");
            }
            Office = office;
            Price = price;
            switch (Office)
            {
                case Location.Sweden:
                    LocalPrice = Price * 9.5f;
                    break;

                case Location.Germany:
                    LocalPrice = Price * 0.85f;
                    break;

                default:
                    LocalPrice = price;
                    break;
            }
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;




        }

        public override string ToString()
        {
            return $"{Office}".PadRight(15) + $"{this.GetType().Name}".PadRight(15) + $"{Brand}".PadRight(15) + $"{Model}".PadRight(15) + $"{Price}".PadRight(15) + $"{LocalPrice}".PadRight(15) + $"{PurchaseDate}".PadRight(15);
        }

        public int CompareTo(object obj)
        {

            Asset otherAsset = (Asset)obj; //Try casting obj to Asset.

            if (this.GetType().Name[0] > otherAsset.GetType().Name[0])
            {
                return 1;
                //If the first name of the class
            }
            else if (this.GetType().Name[0] < otherAsset.GetType().Name[0])
            {
                return -1;
            }
            else
            {
                if (this.PurchaseDate > otherAsset.PurchaseDate)
                {
                    return 1;
                }
                else if (this.PurchaseDate < otherAsset.PurchaseDate)
                {
                    return -1;
                }
                else { return 0; }
            }

        }
    }
        public class Computer : Asset
    {
        public AssetType AssetType { get; set; }

        public Computer(Location office, string brand, string model, DateTime purchaseDate, float price) : base(office, brand, model, purchaseDate, price)
        { }

    }

    public class MobilePhone : Asset
    {

        public MobilePhone(Location office, string brand, string model, DateTime purchaseDate, float price) : base(office,brand, model, purchaseDate, price)
        { }

    }


    public enum AssetType
    {
        Computer,
        MobilePhone,
    }

    public enum Location
    {
        Germany,
        Sweden,
        UnitedStates,
    }
}
