using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostCreatedHandler : INotificationHandler<PostCreatedNotification>
	{
		public async Task Handle(PostCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostUpdatedHandler : INotificationHandler<PostUpdatedNotification>
	{
		public async Task Handle(PostUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostDeletedHandler : INotificationHandler<PostDeletedNotification>
	{
		public async Task Handle(PostDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostCreatedNotification : INotification
	{
		public ApiPostServerResponseModel Record { get; private set; }

		public PostCreatedNotification(ApiPostServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostUpdatedNotification : INotification
	{
		public ApiPostServerResponseModel Record { get; private set; }

		public PostUpdatedNotification(ApiPostServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PostDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>416e647709d05e25a284c74c612c650d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/