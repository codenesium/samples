using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class TeacherSkillCreatedHandler : INotificationHandler<TeacherSkillCreatedNotification>
	{
		public async Task Handle(TeacherSkillCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeacherSkillUpdatedHandler : INotificationHandler<TeacherSkillUpdatedNotification>
	{
		public async Task Handle(TeacherSkillUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeacherSkillDeletedHandler : INotificationHandler<TeacherSkillDeletedNotification>
	{
		public async Task Handle(TeacherSkillDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeacherSkillCreatedNotification : INotification
	{
		public ApiTeacherSkillServerResponseModel Record { get; private set; }

		public TeacherSkillCreatedNotification(ApiTeacherSkillServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TeacherSkillUpdatedNotification : INotification
	{
		public ApiTeacherSkillServerResponseModel Record { get; private set; }

		public TeacherSkillUpdatedNotification(ApiTeacherSkillServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TeacherSkillDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TeacherSkillDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>7d533533a1f40467e756f76d79c6ce30</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/