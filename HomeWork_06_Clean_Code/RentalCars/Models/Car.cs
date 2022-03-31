namespace RentalCars
{
    public class Car
    {
        public PriceCode _priceCode;
        public string _model;
        public string _chassisSeries;

        public Car(PriceCode priceCode, string model, string chassisSeries)
        {
            _priceCode = priceCode;
            _model = model;
            _chassisSeries = chassisSeries;
        }
    }
}