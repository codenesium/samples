using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ClaspCreatedHandler : INotificationHandler<ClaspCreatedNotification>
	{
		public async Task Handle(ClaspCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ClaspUpdatedHandler : INotificationHandler<ClaspUpdatedNotification>
	{
		public async Task Handle(ClaspUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ClaspDeletedHandler : INotificationHandler<ClaspDeletedNotification>
	{
		public async Task Handle(ClaspDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ClaspCreatedNotification : INotification
	{
		public ApiClaspServerResponseModel Record { get; private set; }

		public ClaspCreatedNotification(ApiClaspServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ClaspUpdatedNotification : INotification
	{
		public ApiClaspServerResponseModel Record { get; private set; }

		public ClaspUpdatedNotification(ApiClaspServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ClaspDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public ClaspDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>b462fd0c92bd286d0a3e81dd74a4c4e8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/