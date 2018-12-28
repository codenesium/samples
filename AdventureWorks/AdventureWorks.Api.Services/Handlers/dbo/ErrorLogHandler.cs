using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ErrorLogCreatedHandler : INotificationHandler<ErrorLogCreatedNotification>
	{
		public async Task Handle(ErrorLogCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ErrorLogUpdatedHandler : INotificationHandler<ErrorLogUpdatedNotification>
	{
		public async Task Handle(ErrorLogUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ErrorLogDeletedHandler : INotificationHandler<ErrorLogDeletedNotification>
	{
		public async Task Handle(ErrorLogDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ErrorLogCreatedNotification : INotification
	{
		public ApiErrorLogServerResponseModel Record { get; private set; }

		public ErrorLogCreatedNotification(ApiErrorLogServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ErrorLogUpdatedNotification : INotification
	{
		public ApiErrorLogServerResponseModel Record { get; private set; }

		public ErrorLogUpdatedNotification(ApiErrorLogServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ErrorLogDeletedNotification : INotification
	{
		public int ErrorLogID { get; private set; }

		public ErrorLogDeletedNotification(int errorLogID)
		{
			this.ErrorLogID = errorLogID;
		}
	}
}

/*<Codenesium>
    <Hash>2f95600f539ecf19f70b0b6511caaf90</Hash>
</Codenesium>*/