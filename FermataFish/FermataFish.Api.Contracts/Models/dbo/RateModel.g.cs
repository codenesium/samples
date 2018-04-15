using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class RateModel
	{
		public RateModel()
		{}

		public RateModel(
			decimal amountPerMinute,
			int teacherSkillId,
			int teacherId)
		{
			this.AmountPerMinute = amountPerMinute.ToDecimal();
			this.TeacherSkillId = teacherSkillId.ToInt();
			this.TeacherId = teacherId.ToInt();
		}

		private decimal amountPerMinute;

		[Required]
		public decimal AmountPerMinute
		{
			get
			{
				return this.amountPerMinute;
			}

			set
			{
				this.amountPerMinute = value;
			}
		}

		private int teacherSkillId;

		[Required]
		public int TeacherSkillId
		{
			get
			{
				return this.teacherSkillId;
			}

			set
			{
				this.teacherSkillId = value;
			}
		}

		private int teacherId;

		[Required]
		public int TeacherId
		{
			get
			{
				return this.teacherId;
			}

			set
			{
				this.teacherId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8f3661593364858d7f951af290ba26f6</Hash>
</Codenesium>*/