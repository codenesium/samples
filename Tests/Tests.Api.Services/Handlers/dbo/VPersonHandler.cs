using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class VPersonCreatedHandler : INotificationHandler<VPersonCreatedNotification>
	{
		public async Task Handle(VPersonCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VPersonUpdatedHandler : INotificationHandler<VPersonUpdatedNotification>
	{
		public async Task Handle(VPersonUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VPersonDeletedHandler : INotificationHandler<VPersonDeletedNotification>
	{
		public async Task Handle(VPersonDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VPersonCreatedNotification : INotification
	{
		public ApiVPersonServerResponseModel Record { get; private set; }

		public VPersonCreatedNotification(ApiVPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VPersonUpdatedNotification : INotification
	{
		public ApiVPersonServerResponseModel Record { get; private set; }

		public VPersonUpdatedNotification(ApiVPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VPersonDeletedNotification : INotification
	{
		public int PersonId { get; private set; }

		public VPersonDeletedNotification(int personId)
		{
			this.PersonId = personId;
		}
	}
}

/*<Codenesium>
    <Hash>88394b6ff4205548912569e0891fd5e6</Hash>
</Codenesium>*/