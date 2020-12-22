using System;
using System.Collections.Generic;
using System.Text;

namespace CDListingTests
{
    public class ListingHttp
    {
        public Location Origin { get; set; }

        public Location Destination { get; set; }

        public string PartnerReferenceId { get; set; }

        public TrailerType? TrailerType { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public bool HasInOpVehicle { get; set; }

        public string AvailableDate { get; set; }

        public string DesiredDeliveryDate { get; set; }

        public Price Price { get; set; }
    }

    public class Price
    {
        public decimal Total { get; set; }

        public Cod Cod { get; set; }

    }

    public class Cod
    {
        public decimal Amount { get; set; }

        public CodPaymentMethod? PaymentMethod { get; set; }

        public CodPaymentLocation? PaymentLocation { get; set; }
    }

    public enum CodPaymentMethod
    {
        CASH_CERTIFIED_FUNDS,
        CHECK
    }

    public enum CodPaymentLocation
    {
        PICKUP,
        DELIVERY
    }

    public class Location
    {
        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }

    public enum TrailerType
    {
        OPEN,
        ENCLOSED,
        DRIVEAWAY
    }

    public class Vehicle
    {
        public string Id { get; set; }

        public int? Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int? Qty { get; set; }

        public bool WideLoad { get; set; }
    }
}
