using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiRateServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiRateServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal amountPerMinute,
			int teacherId,
			int teacherSkillId)
		{
			this.AmountPerMinute = amountPerMinute;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		[Required]
		[JsonProperty]
		public decimal AmountPerMinute { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; }

		[Required]
		[JsonProperty]
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7baeca1ff13887d117efd97788ec40c6</Hash>
</Codenesium>*/