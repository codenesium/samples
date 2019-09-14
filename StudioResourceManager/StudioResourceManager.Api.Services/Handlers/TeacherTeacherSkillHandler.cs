using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class TeacherTeacherSkillCreatedHandler : INotificationHandler<TeacherTeacherSkillCreatedNotification>
	{
		public async Task Handle(TeacherTeacherSkillCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeacherTeacherSkillUpdatedHandler : INotificationHandler<TeacherTeacherSkillUpdatedNotification>
	{
		public async Task Handle(TeacherTeacherSkillUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeacherTeacherSkillDeletedHandler : INotificationHandler<TeacherTeacherSkillDeletedNotification>
	{
		public async Task Handle(TeacherTeacherSkillDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeacherTeacherSkillCreatedNotification : INotification
	{
		public ApiTeacherTeacherSkillServerResponseModel Record { get; private set; }

		public TeacherTeacherSkillCreatedNotification(ApiTeacherTeacherSkillServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TeacherTeacherSkillUpdatedNotification : INotification
	{
		public ApiTeacherTeacherSkillServerResponseModel Record { get; private set; }

		public TeacherTeacherSkillUpdatedNotification(ApiTeacherTeacherSkillServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TeacherTeacherSkillDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TeacherTeacherSkillDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1345c4cf0f6a68f06f718416bbdfba96</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/