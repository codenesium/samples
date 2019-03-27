using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiTeacherTeacherSkillServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int teacherId,
			int teacherSkillId)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

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
    <Hash>31b2cd21c4a3bda5152165efb4a5776a</Hash>
</Codenesium>*/