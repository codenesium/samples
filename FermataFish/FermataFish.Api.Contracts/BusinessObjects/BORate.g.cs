using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class BORate:AbstractBusinessObject
	{
		public BORate() : base()
		{}

		public void SetProperties(int id,
		                          decimal amountPerMinute,
		                          int teacherId,
		                          int teacherSkillId)
		{
			this.AmountPerMinute = amountPerMinute.ToDecimal();
			this.Id = id.ToInt();
			this.TeacherId = teacherId.ToInt();
			this.TeacherSkillId = teacherSkillId.ToInt();
		}

		public decimal AmountPerMinute { get; private set; }
		public int Id { get; private set; }
		public int TeacherId { get; private set; }
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>54b4c0912b10bbab69c1ca68bd2ab9b6</Hash>
</Codenesium>*/