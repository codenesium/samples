using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiRateModel
	{
		public ApiRateModel()
		{}

		public ApiRateModel(
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
    <Hash>52d164e36df0343af6aa364689776e55</Hash>
</Codenesium>*/