using System;

namespace GraphQl.Domain;

public class Location(int id, string code, string name, Address address)
{
    public int Id { get; set; } = id;
    public string Code { get; set; } = code;
    public string Name { get; set; } = name;
    public Address Address { get; set; } = address;
}