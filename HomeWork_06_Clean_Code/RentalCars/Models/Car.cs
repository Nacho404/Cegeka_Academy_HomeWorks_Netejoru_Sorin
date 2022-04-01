namespace RentalCars.Models
{
    public class Car
    {
        public PriceModel PriceModel;
        public string _model;
        public string _chassisSeries;

        public Car(PriceModel priceModel, string model, string chassisSeries)
        {
            PriceModel = priceModel;
            _model = model;
            _chassisSeries = chassisSeries;
        }
    }
}