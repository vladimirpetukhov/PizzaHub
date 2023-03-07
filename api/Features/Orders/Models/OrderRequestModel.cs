using api.Data.Models;
using api.Data.Models.Enums;
using api.Infrastructure;
using api.Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations;

namespace api.Features.Orders.Models
{
    public class OrderRequestModel
    {
        [Required]
        [Range(0, 100, ErrorMessage = ErrorMessages.OutsideRangeErrorMessage)]
        public int Quantity { get; set; }

        [EnumStringValue(typeof(OrderStatus))]
        public string Status { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public int PizzaType{ get; set; }
    }
}