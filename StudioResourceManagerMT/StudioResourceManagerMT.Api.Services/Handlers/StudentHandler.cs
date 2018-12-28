using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class StudentCreatedHandler : INotificationHandler<StudentCreatedNotification>
	{
		public async Task Handle(StudentCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StudentUpdatedHandler : INotificationHandler<StudentUpdatedNotification>
	{
		public async Task Handle(StudentUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StudentDeletedHandler : INotificationHandler<StudentDeletedNotification>
	{
		public async Task Handle(StudentDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StudentCreatedNotification : INotification
	{
		public BOStudent Record { get; private set; }

		public StudentCreatedNotification(BOStudent record)
		{
			this.Record = record;
		}
	}

	public class StudentUpdatedNotification : INotification
	{
		public BOStudent Record { get; private set; }

		public StudentUpdatedNotification(BOStudent record)
		{
			this.Record = record;
		}
	}

	public class StudentDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public StudentDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>bfa841b06b3c06a7820ba9ca99677583</Hash>
</Codenesium>*/