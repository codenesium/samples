using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class RetweetCreatedHandler : INotificationHandler<RetweetCreatedNotification>
	{
		public async Task Handle(RetweetCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RetweetUpdatedHandler : INotificationHandler<RetweetUpdatedNotification>
	{
		public async Task Handle(RetweetUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RetweetDeletedHandler : INotificationHandler<RetweetDeletedNotification>
	{
		public async Task Handle(RetweetDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RetweetCreatedNotification : INotification
	{
		public ApiRetweetServerResponseModel Record { get; private set; }

		public RetweetCreatedNotification(ApiRetweetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class RetweetUpdatedNotification : INotification
	{
		public ApiRetweetServerResponseModel Record { get; private set; }

		public RetweetUpdatedNotification(ApiRetweetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class RetweetDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public RetweetDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>456d9478ccbc29cacfda8e753ddd5cc3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/