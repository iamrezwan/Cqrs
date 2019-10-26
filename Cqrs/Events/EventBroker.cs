using Cqrs.Commands;
using Cqrs.Queries;
using System;
using System.Collections.Generic;

namespace Cqrs.Events
{
    public class EventBroker
    {
        public IList<RootEvent> AllEvents { get; set; } = new List<RootEvent>();
        public event EventHandler<RootCommand> Commands;
        public event EventHandler<RootQuery> Queries;
        public void Command(RootCommand command)
        {
            Commands?.Invoke(this, command);

        }
        public T Query<T>(RootQuery query)
        {
            Queries?.Invoke(this, query);
            return (T)query.Result;
        }
    }
}
