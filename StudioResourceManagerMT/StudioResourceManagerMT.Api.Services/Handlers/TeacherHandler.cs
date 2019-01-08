using MediatR;
using System;
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
		public ApiTeacherServerResponseModel Record { get; private set; }

		public TeacherCreatedNotification(ApiTeacherServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TeacherUpdatedNotification : INotification
	{
		public ApiTeacherServerResponseModel Record { get; private set; }

		public TeacherUpdatedNotification(ApiTeacherServerResponseModel record)
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
    <Hash>5af1b88b7542c01dc76e14265774f8f0</Hash>
</Codenesium>*/