namespace RentalCars.Models
{
    public class Rental
    {
        public Customer Customer;
        public Car Car;
        public int _daysRented;
        public double rentalAmount;


        public Rental(Customer customer, Car car, int daysRented)
        {
            Customer = customer;
            Car = car;
            _daysRented = daysRented;
            rentalAmount = GetAmountAndSetCustomerPoints();
            SetTotalPriceOfPriceCodePreference();
        }

        private double GetAmountAndSetCustomerPoints()
        {
            string priceCode = Car.PriceModel._priceCode;
            double amount;

            amount = Car.PriceModel.DeterminateAmountByPriceCode(_daysRented);

            if (Customer.frequentRenterPoints >= 5)
            {
                amount = amount * 0.95;
            }

            Customer.SetCustomerPoints(priceCode, _daysRented);

            return amount;
        }

        public void SetTotalPriceOfPriceCodePreference()
        {
            Car.PriceModel.totalPriceOfPriceCodePreference += rentalAmount;
        }
    }
}