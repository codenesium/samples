using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class SelfReferenceCreatedHandler : INotificationHandler<SelfReferenceCreatedNotification>
	{
		public async Task Handle(SelfReferenceCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SelfReferenceUpdatedHandler : INotificationHandler<SelfReferenceUpdatedNotification>
	{
		public async Task Handle(SelfReferenceUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SelfReferenceDeletedHandler : INotificationHandler<SelfReferenceDeletedNotification>
	{
		public async Task Handle(SelfReferenceDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SelfReferenceCreatedNotification : INotification
	{
		public ApiSelfReferenceServerResponseModel Record { get; private set; }

		public SelfReferenceCreatedNotification(ApiSelfReferenceServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SelfReferenceUpdatedNotification : INotification
	{
		public ApiSelfReferenceServerResponseModel Record { get; private set; }

		public SelfReferenceUpdatedNotification(ApiSelfReferenceServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SelfReferenceDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SelfReferenceDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>fe20e5ba716d57a9a55c2931b03cf022</Hash>
</Codenesium>*/