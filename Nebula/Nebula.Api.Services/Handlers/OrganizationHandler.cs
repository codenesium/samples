using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class OrganizationCreatedHandler : INotificationHandler<OrganizationCreatedNotification>
	{
		public async Task Handle(OrganizationCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OrganizationUpdatedHandler : INotificationHandler<OrganizationUpdatedNotification>
	{
		public async Task Handle(OrganizationUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OrganizationDeletedHandler : INotificationHandler<OrganizationDeletedNotification>
	{
		public async Task Handle(OrganizationDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OrganizationCreatedNotification : INotification
	{
		public ApiOrganizationServerResponseModel Record { get; private set; }

		public OrganizationCreatedNotification(ApiOrganizationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OrganizationUpdatedNotification : INotification
	{
		public ApiOrganizationServerResponseModel Record { get; private set; }

		public OrganizationUpdatedNotification(ApiOrganizationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OrganizationDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public OrganizationDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>548c8d755246b99b473f50a995eff004</Hash>
</Codenesium>*/