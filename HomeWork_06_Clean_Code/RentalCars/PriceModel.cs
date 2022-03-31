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
    }
}