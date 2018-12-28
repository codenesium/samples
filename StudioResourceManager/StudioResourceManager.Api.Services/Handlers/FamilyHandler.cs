using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>f8e389d029b415700c9044e7ef9d2114</Hash>
</Codenesium>*/