namespace api.Features.Customers.Models
{
    public class CustomerSearchResponseModel
    {
        public CustomerSearchResponseModel(IEnumerable<CustomerListingResponseModel> customers)
        {

            Customers = customers;

        }

        public IEnumerable<CustomerListingResponseModel> Customers { get; }
    }
}
