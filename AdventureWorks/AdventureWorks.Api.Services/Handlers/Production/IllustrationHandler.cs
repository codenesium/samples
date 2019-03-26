using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class IllustrationCreatedHandler : INotificationHandler<IllustrationCreatedNotification>
	{
		public async Task Handle(IllustrationCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class IllustrationUpdatedHandler : INotificationHandler<IllustrationUpdatedNotification>
	{
		public async Task Handle(IllustrationUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class IllustrationDeletedHandler : INotificationHandler<IllustrationDeletedNotification>
	{
		public async Task Handle(IllustrationDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class IllustrationCreatedNotification : INotification
	{
		public ApiIllustrationServerResponseModel Record { get; private set; }

		public IllustrationCreatedNotification(ApiIllustrationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class IllustrationUpdatedNotification : INotification
	{
		public ApiIllustrationServerResponseModel Record { get; private set; }

		public IllustrationUpdatedNotification(ApiIllustrationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class IllustrationDeletedNotification : INotification
	{
		public int IllustrationID { get; private set; }

		public IllustrationDeletedNotification(int illustrationID)
		{
			this.IllustrationID = illustrationID;
		}
	}
}

/*<Codenesium>
    <Hash>a3fee60781c1ab789fd032c457212ee6</Hash>
</Codenesium>*/