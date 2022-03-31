namespace RentalCars
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
            rentalAmount = CalculateRentalAmount();
        }

        private double CalculateRentalAmount()
        {
            string priceCode = Car.PriceModel._priceCode;
            double amount = 0;

            // determines the amount for each line
            amount = Car.PriceModel.DeterminateAmountByPriceCode(_daysRented);

            if (Customer.frequentRenterPoints >= 5)
            {
                amount = amount * 0.95;
            }

            if (priceCode == "Premium" && _daysRented > 1)
            {
                Customer.frequentRenterPoints++;
            }

            Customer.frequentRenterPoints++;

            return amount;
        }
    }
}