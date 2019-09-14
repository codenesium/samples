using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostLinkCreatedHandler : INotificationHandler<PostLinkCreatedNotification>
	{
		public async Task Handle(PostLinkCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostLinkUpdatedHandler : INotificationHandler<PostLinkUpdatedNotification>
	{
		public async Task Handle(PostLinkUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostLinkDeletedHandler : INotificationHandler<PostLinkDeletedNotification>
	{
		public async Task Handle(PostLinkDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostLinkCreatedNotification : INotification
	{
		public ApiPostLinkServerResponseModel Record { get; private set; }

		public PostLinkCreatedNotification(ApiPostLinkServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostLinkUpdatedNotification : INotification
	{
		public ApiPostLinkServerResponseModel Record { get; private set; }

		public PostLinkUpdatedNotification(ApiPostLinkServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostLinkDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PostLinkDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>7cc53d6f60b0f976362aae8e89d2cbab</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/