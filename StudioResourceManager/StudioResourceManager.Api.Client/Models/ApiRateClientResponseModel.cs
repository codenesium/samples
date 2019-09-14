using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiRateClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			decimal amountPerMinute,
			int teacherId,
			int teacherSkillId)
		{
			this.Id = id;
			this.AmountPerMinute = amountPerMinute;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;

			this.TeacherIdEntity = nameof(ApiResponse.Teachers);

			this.TeacherSkillIdEntity = nameof(ApiResponse.TeacherSkills);
		}

		[JsonProperty]
		public ApiTeacherClientResponseModel TeacherIdNavigation { get; private set; }

		public void SetTeacherIdNavigation(ApiTeacherClientResponseModel value)
		{
			this.TeacherIdNavigation = value;
		}

		[JsonProperty]
		public ApiTeacherSkillClientResponseModel TeacherSkillIdNavigation { get; private set; }

		public void SetTeacherSkillIdNavigation(ApiTeacherSkillClientResponseModel value)
		{
			this.TeacherSkillIdNavigation = value;
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
	}
}

/*<Codenesium>
    <Hash>fd42adda4e40287eac913d62f0359563</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/