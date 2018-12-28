using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class PersonRefCreatedHandler : INotificationHandler<PersonRefCreatedNotification>
	{
		public async Task Handle(PersonRefCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PersonRefUpdatedHandler : INotificationHandler<PersonRefUpdatedNotification>
	{
		public async Task Handle(PersonRefUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PersonRefDeletedHandler : INotificationHandler<PersonRefDeletedNotification>
	{
		public async Task Handle(PersonRefDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PersonRefCreatedNotification : INotification
	{
		public ApiPersonRefServerResponseModel Record { get; private set; }

		public PersonRefCreatedNotification(ApiPersonRefServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PersonRefUpdatedNotification : INotification
	{
		public ApiPersonRefServerResponseModel Record { get; private set; }

		public PersonRefUpdatedNotification(ApiPersonRefServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PersonRefDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PersonRefDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>946030a24fb39d8af6081150bef7be75</Hash>
</Codenesium>*/