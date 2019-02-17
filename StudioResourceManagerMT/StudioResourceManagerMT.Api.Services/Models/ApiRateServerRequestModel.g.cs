using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
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
		public int TeacherId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int TeacherSkillId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>1629e71b512888681eaea1ccb702c091</Hash>
</Codenesium>*/