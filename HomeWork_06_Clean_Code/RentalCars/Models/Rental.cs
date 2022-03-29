namespace RentalCars
{
    public class Rental
    {
        public Customer Customer;
        public Car Car;
        public int _daysRented;

        public Rental(Customer customer, Car car, int daysRented)
        {
            Customer = customer;
            Car = car;
            _daysRented = daysRented;
        }
    }
}