using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTORate: AbstractDTO
	{
		public DTORate() : base()
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

		public decimal AmountPerMinute { get; set; }
		public int Id { get; set; }
		public int TeacherId { get; set; }
		public int TeacherSkillId { get; set; }
	}
}

/*<Codenesium>
    <Hash>f1eb71c93845fb4843e6731879ca6fc3</Hash>
</Codenesium>*/