using CDListingTests.Models;
using CDListingTests.Models.Enums;
using System.Collections.Generic;

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














}
