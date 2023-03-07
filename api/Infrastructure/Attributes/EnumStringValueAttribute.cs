using System.ComponentModel.DataAnnotations;

namespace api.Infrastructure.Attributes
{
    public class EnumStringValueAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public EnumStringValueAttribute(Type enumType)
        {
            _enumType = enumType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (!Enum.IsDefined(_enumType, value))
                {
                    return new ValidationResult($"{validationContext.DisplayName} must be a valid {_enumType.Name} value.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
