using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiTeacherTeacherSkillRequestModel : AbstractApiRequestModel
	{
		public ApiTeacherTeacherSkillRequestModel()
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
    <Hash>2a0192e86a4ad749af087c0167893c79</Hash>
</Codenesium>*/