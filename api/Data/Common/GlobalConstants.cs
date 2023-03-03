namespace api.Data.Common
{
    public static class GlobalConst
    {
        public const string CONNECTION_STRING = "WebApiDatabase";

        public const string TYPE_DELIVERED = "Delivered";
        public const string TYPE_READY_TO_BE_DELIVERED = "Ready to be delivered";
        public const string TYPE_IN_PREPARATION = "In preparation";
        public const string TYPE_REGISTERED = "Registered";

        public class PizzasConst
        {
            public const string MinPrice = "1";
            public const string MaxPrice = "100000";
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;
            public const int MaxDescriptionLength = 1000;
        }

        public class CustomersConst
        {
            public const int MaxAddressLength = 25;
            public const int MinPhoneNumberLength = 10;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"[0-9]*";
        }

        public class OrdersConst
        {
            public const int MinQuantity = 1;
            public const int MaxQuantity = int.MaxValue;
        }
    }
}
