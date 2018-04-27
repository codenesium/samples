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
			int teacherId,
			int teacherSkillId)
		{
			this.AmountPerMinute = amountPerMinute.ToDecimal();
			this.TeacherId = teacherId.ToInt();
			this.TeacherSkillId = teacherSkillId.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>949bfb743b01f6d108755c8db3811dbb</Hash>
</Codenesium>*/