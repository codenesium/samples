using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class QuoteTweetCreatedHandler : INotificationHandler<QuoteTweetCreatedNotification>
	{
		public async Task Handle(QuoteTweetCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class QuoteTweetUpdatedHandler : INotificationHandler<QuoteTweetUpdatedNotification>
	{
		public async Task Handle(QuoteTweetUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class QuoteTweetDeletedHandler : INotificationHandler<QuoteTweetDeletedNotification>
	{
		public async Task Handle(QuoteTweetDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class QuoteTweetCreatedNotification : INotification
	{
		public ApiQuoteTweetServerResponseModel Record { get; private set; }

		public QuoteTweetCreatedNotification(ApiQuoteTweetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class QuoteTweetUpdatedNotification : INotification
	{
		public ApiQuoteTweetServerResponseModel Record { get; private set; }

		public QuoteTweetUpdatedNotification(ApiQuoteTweetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class QuoteTweetDeletedNotification : INotification
	{
		public int QuoteTweetId { get; private set; }

		public QuoteTweetDeletedNotification(int quoteTweetId)
		{
			this.QuoteTweetId = quoteTweetId;
		}
	}
}

/*<Codenesium>
    <Hash>065f2a0b7f5d547b3cb0d8267675c22c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/