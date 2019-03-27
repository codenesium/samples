using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiTeacherTeacherSkillClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTeacherTeacherSkillClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int teacherSkillId)
		{
			this.TeacherSkillId = teacherSkillId;
		}

		[JsonProperty]
		public int TeacherSkillId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>190d8fb95baf0a86cf71089b81283168</Hash>
</Codenesium>*/