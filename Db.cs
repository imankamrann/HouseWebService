namespace RealEstate.DB
{
    public record Property
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }  // Property image URL
        public string? ListingTime { get; set; }
        public string? MLSNumber { get; set; }
        public string? RealtyCompany { get; set; }
    }

    public class PropertyDB
    {
        private static List<Property> _properties = new List<Property>()
        {
            new Property
            {
                Id = 1,
                Address = "36 Prosperity Pathway, Toronto, ON - Malvern",
                Bedrooms = 4,
                Bathrooms = 4,
                Price = 849900,
                ImageUrl = "https://images.pexels.com/photos/106399/pexels-photo-106399.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                ListingTime = "1 hour",
                MLSNumber = "E1919069",
                RealtyCompany = "HOMELIFE/FUTURE REALTY INC."
            },
            new Property
            {
                Id = 2,
                Address = "47 Eighth Street, Toronto, ON - New Toronto",
                Bedrooms = 3,
                Bathrooms = 4,
                Price = 2288000,
                ImageUrl = "https://media.istockphoto.com/id/1026205392/photo/beautiful-luxury-home-exterior-at-twilight.jpg?s=612x612&w=0&k=20&c=HOCqYY0noIVxnp5uQf1MJJEVpsH_d4WtVQ6-OwVoeDo=",
                ListingTime = "2 hours",
                MLSNumber = "W1919021",
                RealtyCompany = "CENTURY 21 ATRIA REALTY INC."
            }
        };

        public static List<Property> GetProperties()
        {
            return _properties;
        }

        public static Property? GetProperty(int id)
        {
            return _properties.SingleOrDefault(property => property.Id == id);
        }

        public static Property CreateProperty(Property property)
        {
            _properties.Add(property);
            return property;
        }

        public static Property UpdateProperty(Property update)
        {
            _properties = _properties.Select(property =>
            {
                if (property.Id == update.Id)
                {
                    property.Address = update.Address;
                    property.Bedrooms = update.Bedrooms;
                    property.Bathrooms = update.Bathrooms;
                    property.Price = update.Price;
                    property.ImageUrl = update.ImageUrl;
                    property.ListingTime = update.ListingTime;
                    property.MLSNumber = update.MLSNumber;
                    property.RealtyCompany = update.RealtyCompany;
                }
                return property;
            }).ToList();
            return update;
        }

        public static void RemoveProperty(int id)
        {
            _properties = _properties.FindAll(property => property.Id != id).ToList();
        }
    }
}
