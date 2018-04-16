using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOTeacherXTeacherSkill
	{
		public POCOTeacherXTeacherSkill()
		{}

		public POCOTeacherXTeacherSkill(
			int id,
			int teacherId,
			int teacherSkillId)
		{
			this.Id = id.ToInt();

			this.TeacherId = new ReferenceEntity<int>(teacherId,
			                                          nameof(ApiResponse.Teachers));
			this.TeacherSkillId = new ReferenceEntity<int>(teacherSkillId,
			                                               nameof(ApiResponse.TeacherSkills));
		}

		public int Id { get; set; }
		public ReferenceEntity<int> TeacherId { get; set; }
		public ReferenceEntity<int> TeacherSkillId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherIdValue { get; set; } = true;

		public bool ShouldSerializeTeacherId()
		{
			return this.ShouldSerializeTeacherIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherSkillIdValue { get; set; } = true;

		public bool ShouldSerializeTeacherSkillId()
		{
			return this.ShouldSerializeTeacherSkillIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeTeacherIdValue = false;
			this.ShouldSerializeTeacherSkillIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>65be0fea481d2a846706ae10defb8045</Hash>
</Codenesium>*/