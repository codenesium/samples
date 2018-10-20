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
			int teacherSkillId,
			bool isDeleted)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.IsDeleted = isDeleted;

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

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e8cb7164557cba00fe6123bbe3cacd77</Hash>
</Codenesium>*/