using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiTeacherTeacherSkillServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTeacherTeacherSkillServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int teacherSkillId)
		{
			this.TeacherSkillId = teacherSkillId;
		}

		[Required]
		[JsonProperty]
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b5ef1d3494a4d99e1e642bc52aaf284b</Hash>
</Codenesium>*/