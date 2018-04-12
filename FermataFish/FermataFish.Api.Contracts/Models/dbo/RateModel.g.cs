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
			this.AmountPerMinute = amountPerMinute;
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
    <Hash>6e3f8a6524c6dbb3e9c177da64771d3c</Hash>
</Codenesium>*/