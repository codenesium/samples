using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class CultureCreatedHandler : INotificationHandler<CultureCreatedNotification>
	{
		public async Task Handle(CultureCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CultureUpdatedHandler : INotificationHandler<CultureUpdatedNotification>
	{
		public async Task Handle(CultureUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CultureDeletedHandler : INotificationHandler<CultureDeletedNotification>
	{
		public async Task Handle(CultureDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CultureCreatedNotification : INotification
	{
		public ApiCultureServerResponseModel Record { get; private set; }

		public CultureCreatedNotification(ApiCultureServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CultureUpdatedNotification : INotification
	{
		public ApiCultureServerResponseModel Record { get; private set; }

		public CultureUpdatedNotification(ApiCultureServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CultureDeletedNotification : INotification
	{
		public string CultureID { get; private set; }

		public CultureDeletedNotification(string cultureID)
		{
			this.CultureID = cultureID;
		}
	}
}

/*<Codenesium>
    <Hash>d720513984c6bed999d219126cb2d84c</Hash>
</Codenesium>*/