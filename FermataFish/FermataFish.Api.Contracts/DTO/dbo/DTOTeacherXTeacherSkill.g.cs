using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOTeacherXTeacherSkill: AbstractDTO
	{
		public DTOTeacherXTeacherSkill() : base()
		{}

		public void SetProperties(int id,
		                          int teacherId,
		                          int teacherSkillId)
		{
			this.Id = id.ToInt();
			this.TeacherId = teacherId.ToInt();
			this.TeacherSkillId = teacherSkillId.ToInt();
		}

		public int Id { get; set; }
		public int TeacherId { get; set; }
		public int TeacherSkillId { get; set; }
	}
}

/*<Codenesium>
    <Hash>65973d35e751a5509124cb8e2b735e39</Hash>
</Codenesium>*/