using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>9a7f4bc947ee0568da6a8a50eefc23bb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/