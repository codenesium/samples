using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiTeacherXTeacherSkillModel: AbstractModel
	{
		public ApiTeacherXTeacherSkillModel() : base()
		{}

		public ApiTeacherXTeacherSkillModel(
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
    <Hash>8bc4927dc9a1940c72464e949ee2a69f</Hash>
</Codenesium>*/