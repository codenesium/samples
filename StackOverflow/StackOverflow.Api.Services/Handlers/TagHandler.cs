using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class TagCreatedHandler : INotificationHandler<TagCreatedNotification>
	{
		public async Task Handle(TagCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TagUpdatedHandler : INotificationHandler<TagUpdatedNotification>
	{
		public async Task Handle(TagUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TagDeletedHandler : INotificationHandler<TagDeletedNotification>
	{
		public async Task Handle(TagDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TagCreatedNotification : INotification
	{
		public ApiTagServerResponseModel Record { get; private set; }

		public TagCreatedNotification(ApiTagServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TagUpdatedNotification : INotification
	{
		public ApiTagServerResponseModel Record { get; private set; }

		public TagUpdatedNotification(ApiTagServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TagDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TagDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>a43d0e4c011b1b60711dda09bcdc181e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/