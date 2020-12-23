using CDListingTests.Models.Enums;

namespace CDListingTests.Models
{
    public class Vehicle
    {
        public string Id { get; set; }

        public int? Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int? Qty { get; set; }

        public bool WideLoad { get; set; }

        public VehicleType? VehicleType { get; set; }
    }
}
