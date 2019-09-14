using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class BucketCreatedHandler : INotificationHandler<BucketCreatedNotification>
	{
		public async Task Handle(BucketCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BucketUpdatedHandler : INotificationHandler<BucketUpdatedNotification>
	{
		public async Task Handle(BucketUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BucketDeletedHandler : INotificationHandler<BucketDeletedNotification>
	{
		public async Task Handle(BucketDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BucketCreatedNotification : INotification
	{
		public ApiBucketServerResponseModel Record { get; private set; }

		public BucketCreatedNotification(ApiBucketServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BucketUpdatedNotification : INotification
	{
		public ApiBucketServerResponseModel Record { get; private set; }

		public BucketUpdatedNotification(ApiBucketServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BucketDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public BucketDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>520d3c377b75a912bbdb160c701d6d7b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/