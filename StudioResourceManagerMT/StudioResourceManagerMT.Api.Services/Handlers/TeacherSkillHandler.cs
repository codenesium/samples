using MediatR;
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
		public BOTeacherSkill Record { get; private set; }

		public TeacherSkillCreatedNotification(BOTeacherSkill record)
		{
			this.Record = record;
		}
	}

	public class TeacherSkillUpdatedNotification : INotification
	{
		public BOTeacherSkill Record { get; private set; }

		public TeacherSkillUpdatedNotification(BOTeacherSkill record)
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
    <Hash>7178e9424906eeecdaeab403205e2991</Hash>
</Codenesium>*/