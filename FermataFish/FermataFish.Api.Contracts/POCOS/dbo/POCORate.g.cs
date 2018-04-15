using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCORate
	{
		public POCORate()
		{}

		public POCORate(
			int id,
			decimal amountPerMinute,
			int teacherSkillId,
			int teacherId)
		{
			this.Id = id.ToInt();
			this.AmountPerMinute = amountPerMinute.ToDecimal();

			this.TeacherSkillId = new ReferenceEntity<int>(teacherSkillId,
			                                               nameof(ApiResponse.TeacherSkills));
			this.TeacherId = new ReferenceEntity<int>(teacherId,
			                                          nameof(ApiResponse.Teachers));
		}

		public int Id { get; set; }
		public decimal AmountPerMinute { get; set; }
		public ReferenceEntity<int> TeacherSkillId { get; set; }
		public ReferenceEntity<int> TeacherId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAmountPerMinuteValue { get; set; } = true;

		public bool ShouldSerializeAmountPerMinute()
		{
			return this.ShouldSerializeAmountPerMinuteValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherSkillIdValue { get; set; } = true;

		public bool ShouldSerializeTeacherSkillId()
		{
			return this.ShouldSerializeTeacherSkillIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherIdValue { get; set; } = true;

		public bool ShouldSerializeTeacherId()
		{
			return this.ShouldSerializeTeacherIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeAmountPerMinuteValue = false;
			this.ShouldSerializeTeacherSkillIdValue = false;
			this.ShouldSerializeTeacherIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>a12929495d407ec8687c52f7337ee29e</Hash>
</Codenesium>*/