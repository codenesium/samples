using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class TestAllFieldTypeCreatedHandler : INotificationHandler<TestAllFieldTypeCreatedNotification>
	{
		public async Task Handle(TestAllFieldTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TestAllFieldTypeUpdatedHandler : INotificationHandler<TestAllFieldTypeUpdatedNotification>
	{
		public async Task Handle(TestAllFieldTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TestAllFieldTypeDeletedHandler : INotificationHandler<TestAllFieldTypeDeletedNotification>
	{
		public async Task Handle(TestAllFieldTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TestAllFieldTypeCreatedNotification : INotification
	{
		public ApiTestAllFieldTypeServerResponseModel Record { get; private set; }

		public TestAllFieldTypeCreatedNotification(ApiTestAllFieldTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TestAllFieldTypeUpdatedNotification : INotification
	{
		public ApiTestAllFieldTypeServerResponseModel Record { get; private set; }

		public TestAllFieldTypeUpdatedNotification(ApiTestAllFieldTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TestAllFieldTypeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TestAllFieldTypeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>cd3a390eaee24717bce8f237faf9b90e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/