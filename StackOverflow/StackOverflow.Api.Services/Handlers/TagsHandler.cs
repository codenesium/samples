using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class TagsCreatedHandler : INotificationHandler<TagsCreatedNotification>
	{
		public async Task Handle(TagsCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TagsUpdatedHandler : INotificationHandler<TagsUpdatedNotification>
	{
		public async Task Handle(TagsUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TagsDeletedHandler : INotificationHandler<TagsDeletedNotification>
	{
		public async Task Handle(TagsDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TagsCreatedNotification : INotification
	{
		public ApiTagsServerResponseModel Record { get; private set; }

		public TagsCreatedNotification(ApiTagsServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TagsUpdatedNotification : INotification
	{
		public ApiTagsServerResponseModel Record { get; private set; }

		public TagsUpdatedNotification(ApiTagsServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TagsDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TagsDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>cedc0b7b3bb2c65d9e58e258abb00c65</Hash>
</Codenesium>*/