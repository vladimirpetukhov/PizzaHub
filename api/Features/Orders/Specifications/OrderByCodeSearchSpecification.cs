using api.Data.Models;
using api.Infrastructure.Common;
using System.Linq.Expressions;

namespace api.Features.Orders.Specifications
{
    public class OrderByCodeSearchSpecification: Specification<Order>
    {
        private readonly string code;

        internal OrderByCodeSearchSpecification(string code) => this.code = code;
        protected override bool Include => !string.IsNullOrEmpty(code);

        public override Expression<Func<Order, bool>> ToExpression()
        {
            if (Include)
            {
                return order => order.OrderCode.ToString().Contains(this.code);
            }

            return order => true;
        }
    }
}
