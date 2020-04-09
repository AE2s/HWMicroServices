using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HelloWorldMicroServices.Domain.Events;
using MediatR;

namespace HelloWorldMicroServices.Domain.Handlers
{
    public class QueryNotificationHandler : INotificationHandler<QueryNotification>
    {
        public Task Handle(QueryNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("get list");
            return Task.CompletedTask;
        }
    }
}
