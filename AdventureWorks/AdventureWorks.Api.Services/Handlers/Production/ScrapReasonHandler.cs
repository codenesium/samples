using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ScrapReasonCreatedHandler : INotificationHandler<ScrapReasonCreatedNotification>
	{
		public async Task Handle(ScrapReasonCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ScrapReasonUpdatedHandler : INotificationHandler<ScrapReasonUpdatedNotification>
	{
		public async Task Handle(ScrapReasonUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ScrapReasonDeletedHandler : INotificationHandler<ScrapReasonDeletedNotification>
	{
		public async Task Handle(ScrapReasonDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ScrapReasonCreatedNotification : INotification
	{
		public ApiScrapReasonServerResponseModel Record { get; private set; }

		public ScrapReasonCreatedNotification(ApiScrapReasonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ScrapReasonUpdatedNotification : INotification
	{
		public ApiScrapReasonServerResponseModel Record { get; private set; }

		public ScrapReasonUpdatedNotification(ApiScrapReasonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ScrapReasonDeletedNotification : INotification
	{
		public short ScrapReasonID { get; private set; }

		public ScrapReasonDeletedNotification(short scrapReasonID)
		{
			this.ScrapReasonID = scrapReasonID;
		}
	}
}

/*<Codenesium>
    <Hash>a5a460a5f267592e05b1daed060cb14c</Hash>
</Codenesium>*/