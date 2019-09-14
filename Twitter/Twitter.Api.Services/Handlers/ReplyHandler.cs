using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class ReplyCreatedHandler : INotificationHandler<ReplyCreatedNotification>
	{
		public async Task Handle(ReplyCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ReplyUpdatedHandler : INotificationHandler<ReplyUpdatedNotification>
	{
		public async Task Handle(ReplyUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ReplyDeletedHandler : INotificationHandler<ReplyDeletedNotification>
	{
		public async Task Handle(ReplyDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ReplyCreatedNotification : INotification
	{
		public ApiReplyServerResponseModel Record { get; private set; }

		public ReplyCreatedNotification(ApiReplyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ReplyUpdatedNotification : INotification
	{
		public ApiReplyServerResponseModel Record { get; private set; }

		public ReplyUpdatedNotification(ApiReplyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ReplyDeletedNotification : INotification
	{
		public int ReplyId { get; private set; }

		public ReplyDeletedNotification(int replyId)
		{
			this.ReplyId = replyId;
		}
	}
}

/*<Codenesium>
    <Hash>59b4360bc2f371fbed39a84c11ef2aef</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/