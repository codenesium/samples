using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class TicketStatuCreatedHandler : INotificationHandler<TicketStatuCreatedNotification>
	{
		public async Task Handle(TicketStatuCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TicketStatuUpdatedHandler : INotificationHandler<TicketStatuUpdatedNotification>
	{
		public async Task Handle(TicketStatuUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TicketStatuDeletedHandler : INotificationHandler<TicketStatuDeletedNotification>
	{
		public async Task Handle(TicketStatuDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TicketStatuCreatedNotification : INotification
	{
		public ApiTicketStatuServerResponseModel Record { get; private set; }

		public TicketStatuCreatedNotification(ApiTicketStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TicketStatuUpdatedNotification : INotification
	{
		public ApiTicketStatuServerResponseModel Record { get; private set; }

		public TicketStatuUpdatedNotification(ApiTicketStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TicketStatuDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TicketStatuDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>8a343cdd58bfbbbbf8ab3899b2f871eb</Hash>
</Codenesium>*/