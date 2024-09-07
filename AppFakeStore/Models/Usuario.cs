namespace AppFakeStore.Models
{
    public class Address
    {
        public Geolocation Geolocation { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
    }

    public class Geolocation
    {
        public string Lat { get; set; }
        public string Long { get; set; }
    }

    public class Name
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class Usuario
    {
        public Address Address { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public string Phone { get; set; }
        public int V { get; set; }
    }
}
