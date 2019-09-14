using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class IncludedColumnTestCreatedHandler : INotificationHandler<IncludedColumnTestCreatedNotification>
	{
		public async Task Handle(IncludedColumnTestCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class IncludedColumnTestUpdatedHandler : INotificationHandler<IncludedColumnTestUpdatedNotification>
	{
		public async Task Handle(IncludedColumnTestUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class IncludedColumnTestDeletedHandler : INotificationHandler<IncludedColumnTestDeletedNotification>
	{
		public async Task Handle(IncludedColumnTestDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class IncludedColumnTestCreatedNotification : INotification
	{
		public ApiIncludedColumnTestServerResponseModel Record { get; private set; }

		public IncludedColumnTestCreatedNotification(ApiIncludedColumnTestServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class IncludedColumnTestUpdatedNotification : INotification
	{
		public ApiIncludedColumnTestServerResponseModel Record { get; private set; }

		public IncludedColumnTestUpdatedNotification(ApiIncludedColumnTestServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class IncludedColumnTestDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public IncludedColumnTestDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>38485a8a823d75595f1e442bdd1db68f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/