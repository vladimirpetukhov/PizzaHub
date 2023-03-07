namespace api.Infrastructure
{
    internal class ErrorMessages
    {
        public const string StringLengthErrorMessage
                = "The {0} must be at least {2} and at max {1} characters long.";

        public const string OutsideRangeErrorMessage
                = "The {0} must be at range {2} and at max {1} big.";
    }
}
