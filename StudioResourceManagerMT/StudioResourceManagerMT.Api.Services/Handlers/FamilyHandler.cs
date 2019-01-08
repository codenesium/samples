using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class FamilyCreatedHandler : INotificationHandler<FamilyCreatedNotification>
	{
		public async Task Handle(FamilyCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FamilyUpdatedHandler : INotificationHandler<FamilyUpdatedNotification>
	{
		public async Task Handle(FamilyUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FamilyDeletedHandler : INotificationHandler<FamilyDeletedNotification>
	{
		public async Task Handle(FamilyDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FamilyCreatedNotification : INotification
	{
		public ApiFamilyServerResponseModel Record { get; private set; }

		public FamilyCreatedNotification(ApiFamilyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FamilyUpdatedNotification : INotification
	{
		public ApiFamilyServerResponseModel Record { get; private set; }

		public FamilyUpdatedNotification(ApiFamilyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FamilyDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public FamilyDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1d3d93321d363a773142a702fa2f340a</Hash>
</Codenesium>*/