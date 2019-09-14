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
		public int TeacherId { get; private set; }

		[JsonProperty]
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ef98fa81f8a29d159628617eaab1bba9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/