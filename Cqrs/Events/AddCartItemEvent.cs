using Cqrs.Domain;

namespace Cqrs.Events
{
    public class AddCartItemEvent : RootEvent
    {
        public ShoppingCart Target { get; set; }
        public string Item;
        public AddCartItemEvent(ShoppingCart target, string item)
        {
            Target = target;
            Item = item;
        }
        public override string ToString()
        {
            return $"The name of the added item is {Item}";
        }
    }
}
