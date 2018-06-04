using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class BOTeacherXTeacherSkill: AbstractBusinessObject
	{
		public BOTeacherXTeacherSkill() : base()
		{}

		public void SetProperties(int id,
		                          int teacherId,
		                          int teacherSkillId)
		{
			this.Id = id.ToInt();
			this.TeacherId = teacherId.ToInt();
			this.TeacherSkillId = teacherSkillId.ToInt();
		}

		public int Id { get; private set; }
		public int TeacherId { get; private set; }
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bda5b57689e339989203330173d1dce2</Hash>
</Codenesium>*/