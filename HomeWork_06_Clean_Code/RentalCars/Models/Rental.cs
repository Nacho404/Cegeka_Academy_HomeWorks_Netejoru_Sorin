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
            double pricePerDay = 20;// why is the price 20 euro for all car categories?
            double amount = 0;

            // determines the amount for each line
            switch (Car._priceCode)
            {
                case PriceCode.Regular:
                    amount += pricePerDay * 2;
                    if (_daysRented > 2)
                        amount += (_daysRented - 2) * pricePerDay * 0.75;
                    break;
                case PriceCode.Premium:
                    amount += _daysRented * pricePerDay * 1.5;
                    break;
                case PriceCode.Mini:
                    amount += pricePerDay * 3 * 0.75; // here is the bug
                    if (_daysRented > 3)
                        amount += (_daysRented - 3) * pricePerDay * 0.5;
                    break;
            }

            if (Customer._frequentRenterPoints >= 5)
            {
                amount = amount * 0.95;
            }


            if (Car._priceCode == PriceCode.Premium
                    && _daysRented > 1)
            {
                Customer._frequentRenterPoints++;
            }

            Customer._frequentRenterPoints++;

            return amount;
        }
    }
}