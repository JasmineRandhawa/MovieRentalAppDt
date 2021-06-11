namespace MovieRentalApp.Dtos
{
    public class MembershipTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DurationInMonths { get; set; }

        public int Price { get; set; }

        public short DiscountRate { get; set; }

    }
}