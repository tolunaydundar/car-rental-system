using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDTO : IDTO
    {
        public int Id { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int CustomerPhoneNumber { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int CarDailyPrice { get; set; }
    }
}
