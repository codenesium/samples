using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
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
		public int TeacherId { get; private set; } = default(int);

		[JsonProperty]
		public int TeacherSkillId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>b3768fc676c74b6f178fd3d7adc52c64</Hash>
</Codenesium>*/