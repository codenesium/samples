using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class MessageCreatedHandler : INotificationHandler<MessageCreatedNotification>
	{
		public async Task Handle(MessageCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MessageUpdatedHandler : INotificationHandler<MessageUpdatedNotification>
	{
		public async Task Handle(MessageUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MessageDeletedHandler : INotificationHandler<MessageDeletedNotification>
	{
		public async Task Handle(MessageDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MessageCreatedNotification : INotification
	{
		public ApiMessageServerResponseModel Record { get; private set; }

		public MessageCreatedNotification(ApiMessageServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class MessageUpdatedNotification : INotification
	{
		public ApiMessageServerResponseModel Record { get; private set; }

		public MessageUpdatedNotification(ApiMessageServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class MessageDeletedNotification : INotification
	{
		public int MessageId { get; private set; }

		public MessageDeletedNotification(int messageId)
		{
			this.MessageId = messageId;
		}
	}
}

/*<Codenesium>
    <Hash>7469cccea721c64dbb4de7291f16bdd2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/