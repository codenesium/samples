using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class TestAllFieldTypesNullableCreatedHandler : INotificationHandler<TestAllFieldTypesNullableCreatedNotification>
	{
		public async Task Handle(TestAllFieldTypesNullableCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TestAllFieldTypesNullableUpdatedHandler : INotificationHandler<TestAllFieldTypesNullableUpdatedNotification>
	{
		public async Task Handle(TestAllFieldTypesNullableUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TestAllFieldTypesNullableDeletedHandler : INotificationHandler<TestAllFieldTypesNullableDeletedNotification>
	{
		public async Task Handle(TestAllFieldTypesNullableDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TestAllFieldTypesNullableCreatedNotification : INotification
	{
		public ApiTestAllFieldTypesNullableServerResponseModel Record { get; private set; }

		public TestAllFieldTypesNullableCreatedNotification(ApiTestAllFieldTypesNullableServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TestAllFieldTypesNullableUpdatedNotification : INotification
	{
		public ApiTestAllFieldTypesNullableServerResponseModel Record { get; private set; }

		public TestAllFieldTypesNullableUpdatedNotification(ApiTestAllFieldTypesNullableServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TestAllFieldTypesNullableDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TestAllFieldTypesNullableDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>35e0ae413e0de678f7f5448b2d0739c1</Hash>
</Codenesium>*/