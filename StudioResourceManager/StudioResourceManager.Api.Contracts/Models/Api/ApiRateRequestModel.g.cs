using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiRateRequestModel : AbstractApiRequestModel
	{
		public ApiRateRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal amountPerMinute,
			int teacherId,
			int teacherSkillId,
			bool isDeleted)
		{
			this.AmountPerMinute = amountPerMinute;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public decimal AmountPerMinute { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int TeacherSkillId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>c7f454466a2b09261125deff3c3edfca</Hash>
</Codenesium>*/