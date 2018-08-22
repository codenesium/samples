using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiTeacherXTeacherSkillRequestModel : AbstractApiRequestModel
	{
		public ApiTeacherXTeacherSkillRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int teacherId,
			int teacherSkillId,
			int studioId)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.StudioId = studioId;
		}

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; }

		[Required]
		[JsonProperty]
		public int TeacherSkillId { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c668d5f2e6093ed0d82f9d0750b8c973</Hash>
</Codenesium>*/