using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
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
		public int Id { get; private set; }

		public PersonDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>4d1245fa40394f1436bcb4c7f284e99a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/