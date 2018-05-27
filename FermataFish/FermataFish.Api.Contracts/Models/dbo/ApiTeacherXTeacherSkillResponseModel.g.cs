using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiTeacherXTeacherSkillResponseModel: AbstractApiResponseModel
	{
		public ApiTeacherXTeacherSkillResponseModel() : base()
		{}

		public void SetProperties(
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
    <Hash>63cbc6937432a1991834f0295326515c</Hash>
</Codenesium>*/