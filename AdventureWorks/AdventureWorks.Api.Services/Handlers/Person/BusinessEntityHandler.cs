using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class BusinessEntityCreatedHandler : INotificationHandler<BusinessEntityCreatedNotification>
	{
		public async Task Handle(BusinessEntityCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BusinessEntityUpdatedHandler : INotificationHandler<BusinessEntityUpdatedNotification>
	{
		public async Task Handle(BusinessEntityUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BusinessEntityDeletedHandler : INotificationHandler<BusinessEntityDeletedNotification>
	{
		public async Task Handle(BusinessEntityDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BusinessEntityCreatedNotification : INotification
	{
		public ApiBusinessEntityServerResponseModel Record { get; private set; }

		public BusinessEntityCreatedNotification(ApiBusinessEntityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BusinessEntityUpdatedNotification : INotification
	{
		public ApiBusinessEntityServerResponseModel Record { get; private set; }

		public BusinessEntityUpdatedNotification(ApiBusinessEntityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BusinessEntityDeletedNotification : INotification
	{
		public int BusinessEntityID { get; private set; }

		public BusinessEntityDeletedNotification(int businessEntityID)
		{
			this.BusinessEntityID = businessEntityID;
		}
	}
}

/*<Codenesium>
    <Hash>a1211ca0adeaf58dfb496f0380fb1929</Hash>
</Codenesium>*/