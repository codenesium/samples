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
			int teacherSkillId,
			bool isDeleted)
		{
			this.TeacherSkillId = teacherSkillId;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public int TeacherSkillId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>2dda5da67a2589975aad2ab51dd47621</Hash>
</Codenesium>*/