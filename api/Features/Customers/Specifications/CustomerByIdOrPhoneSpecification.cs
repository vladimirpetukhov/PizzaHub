using api.Data.Models;
using api.Infrastructure.Common;
using LinqKit;
using System.Linq.Expressions;

namespace api.Features.Customers.Specifications
{
    public class CustomerByIdOrPhoneSpecification : Specification<Customer>
    {
        private readonly string _phone;

        public CustomerByIdOrPhoneSpecification(string phone)
        {
            _phone = phone;
        }

        protected override bool Include => !string.IsNullOrWhiteSpace(_phone);

        public override Expression<Func<Customer, bool>> ToExpression()
        {

            if (Include)
            {
                return customer => customer.Phone == _phone;
            }

            return customer => true;
        }
    }
}
