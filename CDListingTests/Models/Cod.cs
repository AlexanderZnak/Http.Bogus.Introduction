using CDListingTests.Models.Enums;

namespace CDListingTests.Models
{
    public class Cod
    {
        public decimal Amount { get; set; }

        public CodPaymentMethod? PaymentMethod { get; set; }

        public CodPaymentLocation? PaymentLocation { get; set; }
    }
}
