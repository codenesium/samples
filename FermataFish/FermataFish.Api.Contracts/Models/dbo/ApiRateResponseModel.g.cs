using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiRateResponseModel: AbstractApiResponseModel
	{
		public ApiRateResponseModel() : base()
		{}

		public void SetProperties(
			decimal amountPerMinute,
			int id,
			int teacherId,
			int teacherSkillId)
		{
			this.AmountPerMinute = amountPerMinute.ToDecimal();
			this.Id = id.ToInt();

			this.TeacherId = new ReferenceEntity<int>(teacherId,
			                                          nameof(ApiResponse.Teachers));
			this.TeacherSkillId = new ReferenceEntity<int>(teacherSkillId,
			                                               nameof(ApiResponse.TeacherSkills));
		}

		public decimal AmountPerMinute { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> TeacherId { get; set; }
		public ReferenceEntity<int> TeacherSkillId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAmountPerMinuteValue { get; set; } = true;

		public bool ShouldSerializeAmountPerMinute()
		{
			return this.ShouldSerializeAmountPerMinuteValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherIdValue { get; set; } = true;

		public bool ShouldSerializeTeacherId()
		{
			return this.ShouldSerializeTeacherIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherSkillIdValue { get; set; } = true;

		public bool ShouldSerializeTeacherSkillId()
		{
			return this.ShouldSerializeTeacherSkillIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAmountPerMinuteValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeTeacherIdValue = false;
			this.ShouldSerializeTeacherSkillIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>0bdbbe6845bf08b2e77af6ca3d6b19f9</Hash>
</Codenesium>*/