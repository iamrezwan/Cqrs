using Cqrs.Domain;
namespace Cqrs.Commands
{
    public class AddCartItemCommand : RootCommand
    {
        public ShoppingCart Target { get; set; }
        public string Item { get; set; }
        public AddCartItemCommand(ShoppingCart shoppingCart, string item)
        {
            Target = shoppingCart;
            Item = item;
        }
    }
}
