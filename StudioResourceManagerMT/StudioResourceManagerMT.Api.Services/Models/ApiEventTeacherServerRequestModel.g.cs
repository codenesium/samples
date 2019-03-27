using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiEventTeacherServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiEventTeacherServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int teacherId)
		{
			this.TeacherId = teacherId;
		}

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>38990c08141f025464a7b007c56a1c42</Hash>
</Codenesium>*/