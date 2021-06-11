using System.Collections.Generic;
using MovieRentalApp.Models;
namespace MovieRentalApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}