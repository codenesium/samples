using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiTeacherTeacherSkillServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int teacherId,
			int teacherSkillId)
		{
			this.Id = id;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int TeacherId { get; private set; }

		[JsonProperty]
		public string TeacherIdEntity { get; private set; } = RouteConstants.Teachers;

		[JsonProperty]
		public ApiTeacherServerResponseModel TeacherIdNavigation { get; private set; }

		public void SetTeacherIdNavigation(ApiTeacherServerResponseModel value)
		{
			this.TeacherIdNavigation = value;
		}

		[JsonProperty]
		public int TeacherSkillId { get; private set; }

		[JsonProperty]
		public string TeacherSkillIdEntity { get; private set; } = RouteConstants.TeacherSkills;

		[JsonProperty]
		public ApiTeacherSkillServerResponseModel TeacherSkillIdNavigation { get; private set; }

		public void SetTeacherSkillIdNavigation(ApiTeacherSkillServerResponseModel value)
		{
			this.TeacherSkillIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>a6919ab868cca18016c1e4ecc0386a40</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/