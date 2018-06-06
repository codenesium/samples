using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
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
    <Hash>dfd5611563b7564c323e0db62bf553ab</Hash>
</Codenesium>*/