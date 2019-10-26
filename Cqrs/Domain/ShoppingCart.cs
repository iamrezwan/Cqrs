using Cqrs.Commands;
using Cqrs.Events;
using Cqrs.Queries;
using System.Collections.Generic;

namespace Cqrs.Domain
{
    public class ShoppingCart
    {
        private readonly EventBroker eventBroker;
        private List<string> cartItems { get; set; } = new List<string>();
        public ShoppingCart(EventBroker eventBroker)
        {
            this.eventBroker = eventBroker;
            eventBroker.Commands += AddItemCommand;
            eventBroker.Queries += ViewCartItemQuery;
        }
        private void ViewCartItemQuery(object sender, RootQuery query)
        {
            if (query is ViewCartQuery q && q.Target == this)
            {
                q.Result = cartItems;
            }
        }
        private void AddItemCommand(object sender, RootCommand command)
        {
            if (command is AddCartItemCommand c && c.Target == this)
            {
                eventBroker.AllEvents.Add(new AddCartItemEvent(this, c.Item));
                cartItems.Add(c.Item);
            }

        }
    }
}
