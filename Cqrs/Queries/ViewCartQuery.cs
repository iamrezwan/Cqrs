using Cqrs.Domain;

namespace Cqrs.Queries
{
    public class ViewCartQuery : RootQuery
    {
        public ShoppingCart Target { get; set; }
    }
}
