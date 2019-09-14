using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class TimestampCheckCreatedHandler : INotificationHandler<TimestampCheckCreatedNotification>
	{
		public async Task Handle(TimestampCheckCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TimestampCheckUpdatedHandler : INotificationHandler<TimestampCheckUpdatedNotification>
	{
		public async Task Handle(TimestampCheckUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TimestampCheckDeletedHandler : INotificationHandler<TimestampCheckDeletedNotification>
	{
		public async Task Handle(TimestampCheckDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TimestampCheckCreatedNotification : INotification
	{
		public ApiTimestampCheckServerResponseModel Record { get; private set; }

		public TimestampCheckCreatedNotification(ApiTimestampCheckServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TimestampCheckUpdatedNotification : INotification
	{
		public ApiTimestampCheckServerResponseModel Record { get; private set; }

		public TimestampCheckUpdatedNotification(ApiTimestampCheckServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TimestampCheckDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TimestampCheckDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>35f753ee2a48c61f02bab15777220835</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/