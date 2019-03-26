using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class PasswordCreatedHandler : INotificationHandler<PasswordCreatedNotification>
	{
		public async Task Handle(PasswordCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PasswordUpdatedHandler : INotificationHandler<PasswordUpdatedNotification>
	{
		public async Task Handle(PasswordUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PasswordDeletedHandler : INotificationHandler<PasswordDeletedNotification>
	{
		public async Task Handle(PasswordDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PasswordCreatedNotification : INotification
	{
		public ApiPasswordServerResponseModel Record { get; private set; }

		public PasswordCreatedNotification(ApiPasswordServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PasswordUpdatedNotification : INotification
	{
		public ApiPasswordServerResponseModel Record { get; private set; }

		public PasswordUpdatedNotification(ApiPasswordServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PasswordDeletedNotification : INotification
	{
		public int BusinessEntityID { get; private set; }

		public PasswordDeletedNotification(int businessEntityID)
		{
			this.BusinessEntityID = businessEntityID;
		}
	}
}

/*<Codenesium>
    <Hash>377af7f907c8194f3f0cbfbd3aadf61e</Hash>
</Codenesium>*/