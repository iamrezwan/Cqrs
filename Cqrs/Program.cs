using Cqrs.Commands;
using Cqrs.Domain;
using Cqrs.Events;
using Cqrs.Queries;
using System;
using System.Collections.Generic;
namespace Cqrs
{
    class Program
    {
        static void Main(string[] args)
        {
            var eb = new EventBroker();
            var shoppingCart = new ShoppingCart(eb);
            eb.Command(new AddCartItemCommand(shoppingCart, "Mobile Phone"));
            eb.Command(new AddCartItemCommand(shoppingCart, "Tv"));
            var i = 0;
            foreach (var v in eb.AllEvents)
            {
                Console.WriteLine($"SL. {++i} {v.ToString()} added by the command");
            }
            Console.WriteLine($"Query Part----------------The cart contains");
            var itemsInTheCart = eb.Query<List<string>>(new ViewCartQuery { Target = shoppingCart });
            i = 0;
            foreach (var v in itemsInTheCart)
            {
                Console.WriteLine($"SL.{++i} {v.ToString()}");
            }
            Console.ReadLine();
        }
    }
}
