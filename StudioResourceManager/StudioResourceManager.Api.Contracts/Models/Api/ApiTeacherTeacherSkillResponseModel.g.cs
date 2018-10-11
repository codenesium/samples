using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiTeacherTeacherSkillResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int teacherId,
			int teacherSkillId)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;

			this.TeacherIdEntity = nameof(ApiResponse.Teachers);
			this.TeacherSkillIdEntity = nameof(ApiResponse.TeacherSkills);
		}

		[JsonProperty]
		public int TeacherId { get; private set; }

		[JsonProperty]
		public string TeacherIdEntity { get; set; }

		[JsonProperty]
		public int TeacherSkillId { get; private set; }

		[JsonProperty]
		public string TeacherSkillIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>2bde5d39ced589c2cd9281ccbfde871f</Hash>
</Codenesium>*/