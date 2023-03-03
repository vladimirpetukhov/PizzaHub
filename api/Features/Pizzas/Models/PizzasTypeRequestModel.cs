using System.ComponentModel.DataAnnotations;

namespace api.Features.Pizzas.Models
{
    public class PizzasTypeRequestModel
    {
        [Required]
        [StringLength(
            PizzasConst.MaxNameLength,
            MinimumLength = PizzasConst.MinNameLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; }

        [Range(typeof(decimal), PizzasConst.MinPrice, PizzasConst.MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(PizzasConst.MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
