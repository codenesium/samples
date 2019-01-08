using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class PersonCreatedHandler : INotificationHandler<PersonCreatedNotification>
	{
		public async Task Handle(PersonCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PersonUpdatedHandler : INotificationHandler<PersonUpdatedNotification>
	{
		public async Task Handle(PersonUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PersonDeletedHandler : INotificationHandler<PersonDeletedNotification>
	{
		public async Task Handle(PersonDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PersonCreatedNotification : INotification
	{
		public ApiPersonServerResponseModel Record { get; private set; }

		public PersonCreatedNotification(ApiPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PersonUpdatedNotification : INotification
	{
		public ApiPersonServerResponseModel Record { get; private set; }

		public PersonUpdatedNotification(ApiPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PersonDeletedNotification : INotification
	{
		public int PersonId { get; private set; }

		public PersonDeletedNotification(int personId)
		{
			this.PersonId = personId;
		}
	}
}

/*<Codenesium>
    <Hash>0c10592533aa65af62c19d122f5171bc</Hash>
</Codenesium>*/