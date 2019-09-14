using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class OfficerCreatedHandler : INotificationHandler<OfficerCreatedNotification>
	{
		public async Task Handle(OfficerCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerUpdatedHandler : INotificationHandler<OfficerUpdatedNotification>
	{
		public async Task Handle(OfficerUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerDeletedHandler : INotificationHandler<OfficerDeletedNotification>
	{
		public async Task Handle(OfficerDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerCreatedNotification : INotification
	{
		public ApiOfficerServerResponseModel Record { get; private set; }

		public OfficerCreatedNotification(ApiOfficerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OfficerUpdatedNotification : INotification
	{
		public ApiOfficerServerResponseModel Record { get; private set; }

		public OfficerUpdatedNotification(ApiOfficerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OfficerDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public OfficerDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>cffc7f4ea0ccec265b589f27e0ee0bcd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/