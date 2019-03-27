using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
		public int TeacherId { get; private set; }

		public TeacherTeacherSkillDeletedNotification(int teacherId)
		{
			this.TeacherId = teacherId;
		}
	}
}

/*<Codenesium>
    <Hash>65557b69f52b466065db85cbeb400143</Hash>
</Codenesium>*/