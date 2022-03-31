namespace RentalCars
{
    public class PriceModel
    {
        public string _priceCode;
        public double _pricePerDay;

        public PriceModel(string priceCode, double pricePerDay)
        {
            _priceCode = priceCode;
            _pricePerDay = pricePerDay;
        }

        public double DeterminateAmountByPriceCode(int daysRented)
        {
            double amount = 0;

            switch (_priceCode)
            {
                case "Mini":
                    amount += _pricePerDay * 3;
                    if (daysRented > 3)
                        amount += (daysRented - 3) * (_pricePerDay - 5);
                    break;
                case "Regular":
                    amount += _pricePerDay * 2;
                    if (daysRented > 2)
                        amount += (daysRented - 2) * (_pricePerDay - 5);
                    break;
                case "Premium":
                    amount += daysRented * _pricePerDay;
                    break;
                case "Luxury":
                    amount += daysRented * _pricePerDay;
                    break;
            }

            return amount;
        }
    }
}