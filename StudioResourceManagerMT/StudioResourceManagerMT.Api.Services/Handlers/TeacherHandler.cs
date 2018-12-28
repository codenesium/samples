using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class TeacherCreatedHandler : INotificationHandler<TeacherCreatedNotification>
	{
		public async Task Handle(TeacherCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeacherUpdatedHandler : INotificationHandler<TeacherUpdatedNotification>
	{
		public async Task Handle(TeacherUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeacherDeletedHandler : INotificationHandler<TeacherDeletedNotification>
	{
		public async Task Handle(TeacherDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeacherCreatedNotification : INotification
	{
		public BOTeacher Record { get; private set; }

		public TeacherCreatedNotification(BOTeacher record)
		{
			this.Record = record;
		}
	}

	public class TeacherUpdatedNotification : INotification
	{
		public BOTeacher Record { get; private set; }

		public TeacherUpdatedNotification(BOTeacher record)
		{
			this.Record = record;
		}
	}

	public class TeacherDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TeacherDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>f84befef0f64636593a6dda93dc5bf84</Hash>
</Codenesium>*/