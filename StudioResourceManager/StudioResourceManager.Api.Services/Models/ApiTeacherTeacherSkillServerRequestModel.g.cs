using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiTeacherTeacherSkillServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTeacherTeacherSkillServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int teacherId,
			int teacherSkillId)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; }

		[Required]
		[JsonProperty]
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4b76713ba4a29b94ff7910cd51eeab7e</Hash>
</Codenesium>*/