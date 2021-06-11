namespace MovieRentalApp.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DurationInMonths { get; set; }

        public int Price { get; set; }

        public short DiscountRate { get; set; }

    }
}