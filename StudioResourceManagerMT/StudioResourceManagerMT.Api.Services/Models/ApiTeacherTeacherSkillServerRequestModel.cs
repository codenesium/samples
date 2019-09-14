using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiTeacherTeacherSkillServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTeacherTeacherSkillServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int teacherId,
			int teacherSkillId)
		{
			this.TeacherId = teacherId;
			this.TeacherSkillId = teacherSkillId;
		}

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; }

		[Required]
		[JsonProperty]
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>280293ef72405b9f7d37c3de2a046935</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/