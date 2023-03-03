using api.Data.Models;
using api.Infrastructure.Common;
using System.Linq.Expressions;

namespace api.Features.Pizzas.Specifications
{
    internal class PizzaByTypeNameSpecification : Specification<PizzaType>
    {
        private readonly string name;

        internal PizzaByTypeNameSpecification(string name) => this.name = name;

        protected override bool Include => !string.IsNullOrEmpty(name);

        public override Expression<Func<PizzaType, bool>> ToExpression()
        {
            if ( Include)
            {
                return product => product.Name.ToLower().Contains(this.name.ToLower());
            }

            return product => true;
        }
           
    }
}
