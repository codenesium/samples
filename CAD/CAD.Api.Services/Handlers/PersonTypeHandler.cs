using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class PersonTypeCreatedHandler : INotificationHandler<PersonTypeCreatedNotification>
	{
		public async Task Handle(PersonTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PersonTypeUpdatedHandler : INotificationHandler<PersonTypeUpdatedNotification>
	{
		public async Task Handle(PersonTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PersonTypeDeletedHandler : INotificationHandler<PersonTypeDeletedNotification>
	{
		public async Task Handle(PersonTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PersonTypeCreatedNotification : INotification
	{
		public ApiPersonTypeServerResponseModel Record { get; private set; }

		public PersonTypeCreatedNotification(ApiPersonTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PersonTypeUpdatedNotification : INotification
	{
		public ApiPersonTypeServerResponseModel Record { get; private set; }

		public PersonTypeUpdatedNotification(ApiPersonTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PersonTypeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PersonTypeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>df0ff9c2a7d04904bccd7ee20038be05</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/