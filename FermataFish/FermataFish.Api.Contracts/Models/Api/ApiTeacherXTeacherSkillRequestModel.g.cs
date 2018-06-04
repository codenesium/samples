using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiTeacherXTeacherSkillRequestModel: AbstractApiRequestModel
	{
		public ApiTeacherXTeacherSkillRequestModel() : base()
		{}

		public void SetProperties(
			int teacherId,
			int teacherSkillId)
		{
			this.TeacherId = teacherId.ToInt();
			this.TeacherSkillId = teacherSkillId.ToInt();
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
    <Hash>02691bbdff6d4f0fb662a81f8a241b1a</Hash>
</Codenesium>*/