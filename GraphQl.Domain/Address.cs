namespace GraphQl.Domain;

public class Address(string street, string city, States state, string zipCode)
{
    public string Street { get; set; } = street;
    public string City { get; set; } = city;
    public States State { get; set; } = state;
    public string ZipCode { get; set; } = zipCode;
}