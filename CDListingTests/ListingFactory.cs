using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace CDListingTests
{
    public class ListingFactory
    {
        public static ListingHttp listing;

        public static ListingHttp GenerateFakeListing()
        {
            listing = new ListingHttp()
            {
                Origin = new Location()
                {
                    
                }

            };
            return new ListingHttp();
        }
    }
}
