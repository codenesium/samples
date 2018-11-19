using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiRateClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiRateClientRequestModel()
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

		[JsonProperty]
		public decimal AmountPerMinute { get; private set; } = default(decimal);

		[JsonProperty]
		public int TeacherId { get; private set; }

		[JsonProperty]
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>47a303d294a420b80210065c6d1dcfbd</Hash>
</Codenesium>*/