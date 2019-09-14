using MediatR;
using System;
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
		public ApiStudentServerResponseModel Record { get; private set; }

		public StudentCreatedNotification(ApiStudentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class StudentUpdatedNotification : INotification
	{
		public ApiStudentServerResponseModel Record { get; private set; }

		public StudentUpdatedNotification(ApiStudentServerResponseModel record)
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
    <Hash>26207af2b63df0be67e1f4ade3571c5c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/