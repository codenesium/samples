using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiRateClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			decimal amountPerMinute,
			int teacherId,
			int teacherSkillId)
		{
			this.Id = id;
			this.AmountPerMinute = amountPerMinute;
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		[JsonProperty]
		public decimal AmountPerMinute { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int TeacherId { get; private set; }

		[JsonProperty]
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f9cf79941c9296b07f7d1a5f754fe90b</Hash>
</Codenesium>*/