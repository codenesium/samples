using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostTypeCreatedHandler : INotificationHandler<PostTypeCreatedNotification>
	{
		public async Task Handle(PostTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostTypeUpdatedHandler : INotificationHandler<PostTypeUpdatedNotification>
	{
		public async Task Handle(PostTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostTypeDeletedHandler : INotificationHandler<PostTypeDeletedNotification>
	{
		public async Task Handle(PostTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostTypeCreatedNotification : INotification
	{
		public ApiPostTypeServerResponseModel Record { get; private set; }

		public PostTypeCreatedNotification(ApiPostTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostTypeUpdatedNotification : INotification
	{
		public ApiPostTypeServerResponseModel Record { get; private set; }

		public PostTypeUpdatedNotification(ApiPostTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostTypeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PostTypeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>acf17cf918dc9d3c5230a6df8208310f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/