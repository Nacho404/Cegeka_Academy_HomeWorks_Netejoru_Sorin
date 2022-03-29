namespace RentalCars
{
    public class Car
    {
        public PriceCode _priceCode;
        public string _model;

        public Car(PriceCode priceCode, string model)
        {
            _priceCode = priceCode;
            _model = model;
        }
    }
}