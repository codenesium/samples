using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
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
			int studioId)
		{
			this.AmountPerMinute = amountPerMinute;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
			this.StudioId = studioId;
		}

		[Required]
		[JsonProperty]
		public decimal AmountPerMinute { get; private set; }

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
    <Hash>a6ae3ca3c61bf2ee10206434e315a3c2</Hash>
</Codenesium>*/