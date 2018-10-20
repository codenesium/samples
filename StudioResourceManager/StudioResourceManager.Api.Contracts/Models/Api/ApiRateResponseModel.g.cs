using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiRateResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			decimal amountPerMinute,
			int teacherId,
			int teacherSkillId,
			bool isDeleted)
		{
			this.Id = id;
			this.AmountPerMinute = amountPerMinute;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.IsDeleted = isDeleted;

			this.TeacherIdEntity = nameof(ApiResponse.Teachers);
			this.TeacherSkillIdEntity = nameof(ApiResponse.TeacherSkills);
		}

		[JsonProperty]
		public decimal AmountPerMinute { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

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
    <Hash>82ebf6d9d8469c27da9b69d01668dd0a</Hash>
</Codenesium>*/