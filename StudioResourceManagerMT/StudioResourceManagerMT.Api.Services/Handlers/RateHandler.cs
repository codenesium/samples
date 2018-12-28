using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class RateCreatedHandler : INotificationHandler<RateCreatedNotification>
	{
		public async Task Handle(RateCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RateUpdatedHandler : INotificationHandler<RateUpdatedNotification>
	{
		public async Task Handle(RateUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RateDeletedHandler : INotificationHandler<RateDeletedNotification>
	{
		public async Task Handle(RateDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RateCreatedNotification : INotification
	{
		public BORate Record { get; private set; }

		public RateCreatedNotification(BORate record)
		{
			this.Record = record;
		}
	}

	public class RateUpdatedNotification : INotification
	{
		public BORate Record { get; private set; }

		public RateUpdatedNotification(BORate record)
		{
			this.Record = record;
		}
	}

	public class RateDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public RateDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>23de24289ef0d22a08eea2211e02d62c</Hash>
</Codenesium>*/