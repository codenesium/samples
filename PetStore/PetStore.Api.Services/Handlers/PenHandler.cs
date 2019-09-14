using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class PenCreatedHandler : INotificationHandler<PenCreatedNotification>
	{
		public async Task Handle(PenCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PenUpdatedHandler : INotificationHandler<PenUpdatedNotification>
	{
		public async Task Handle(PenUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PenDeletedHandler : INotificationHandler<PenDeletedNotification>
	{
		public async Task Handle(PenDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PenCreatedNotification : INotification
	{
		public ApiPenServerResponseModel Record { get; private set; }

		public PenCreatedNotification(ApiPenServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PenUpdatedNotification : INotification
	{
		public ApiPenServerResponseModel Record { get; private set; }

		public PenUpdatedNotification(ApiPenServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PenDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PenDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>d508b9eda46ea02f8533470f05d370ef</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/