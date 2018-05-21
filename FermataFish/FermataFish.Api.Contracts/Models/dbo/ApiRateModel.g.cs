using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiRateModel: AbstractModel
	{
		public ApiRateModel() : base()
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
    <Hash>8bb1cdb1646ace4cbe9b6209799ff1d5</Hash>
</Codenesium>*/